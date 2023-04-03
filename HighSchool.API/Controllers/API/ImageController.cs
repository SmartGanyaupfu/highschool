using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using HighSchool.API.ActionFilters;
using HighSchool.API.Extensions;
using HighSchool.Contracts;
using HighSchool.Entities.Models;
using HighSchool.Shared.DTOs;
using HighSchool.Shared.RequestFeatures;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Org.BouncyCastle.Crypto;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HighSchool.API.Controllers.API
{
    [Route("api/media")]

    public class ImageController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IWebHostEnvironment _environment;
        private readonly IMapper _mapper;

        //private readonly IMapper _mapper;
        //private readonly IImageUploader _imageService;
        //private readonly IServiceManager _service;

        public ImageController(IRepositoryManager repository, IWebHostEnvironment environment, IMapper mapper)
        {
            _repository = repository;
            _environment = environment;
            _mapper = mapper;

        }
        [HttpGet]
        public async Task<IActionResult> GetImages([FromQuery] RequestParameters requestParameters)
        {

            var imagesFromDb = await _repository.Image.GetAllImagesAsync(requestParameters, trackChanges: false);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(imagesFromDb.MetaData));
            var imagesToReturn = _mapper.Map<IEnumerable<ImageDto>>(imagesFromDb);
            return Ok(imagesToReturn);
        }

        // GET api/values/5
        [HttpGet("{imageId}", Name = "imagesId")]
        public async Task<IActionResult> GetImageById(int imageId)
        {
            var imageFromDb = await _repository.Image.GetImageByIdAsync(imageId, trackChanges: false);
            if (imageFromDb is null)
                return NotFound($"Image with id {imageId} is not found.");
            //var imageToReturn = _mapper.Map<ImageDto>(imageFromDb);
            return Ok(imageFromDb);
        }
       // [Authorize]
        [HttpPost("add-image")]
        public async Task<IActionResult> AddImage(IFormFile[] files)
        {
            // Fix the filename and set max file size
            var userId = User.GetUserId();

            var images = new List<Image>();
            var messages = new List<string>();
            var uploadResult = new ImageUploadDto();

            foreach (var item in files)
            {

                if (item.FileName == null || item.FileName.Length == 0)
                {
                    return Content("File not selected");
                }

                if (item.Length> 2097152)
                {
                    var msg = item.FileName + " could not be uploaded it exceeds 2mb limit.";

                    messages.Add(msg);
                    continue;
                }
                var path = Path.Combine(_environment.WebRootPath, "Resources/", item.FileName.Trim('"'));

                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    await item.CopyToAsync(stream);
                    stream.Close();
                }

                var image = new Image()
                {
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    AuthorId= userId,
                    Deleted = false,
                    ImageUrl = path
                };

                images.Add(image);
            }

            uploadResult.Images = images;
            uploadResult.ErrorMessages = messages;
          



            //var imageEntity = _mapper.Map<Image>(image);
            _repository.Image.CreateImagesAsync(images);

            await _repository.SaveAsync();

           // var imagesToReturn = _mapper.Map<IEnumerable<ImageDto>>(images);


            //return CreatedAtRoute("imagesId", new { imageId = imageToReturn.ImageId }, imageToReturn);
            return Ok(uploadResult);
        }

       //[Authorize]

        [HttpPut("{imageId}")]

        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateImage(int imageId, [FromBody] ImageForUpdateDto image)
        {


            var imageEntity = await _repository.Image.GetImageByIdAsync(imageId, trackChanges: true);
            if (imageEntity is null)
                return NotFound($"Image with id {imageId} does not exist.");


            _mapper.Map(image, imageEntity);
            await _repository.SaveAsync();

            return NoContent();
        }

        //[Authorize]

        [HttpDelete("{imageId}")]
        public async Task<IActionResult> DeleteImage(int imageId)
        {


            var imageEntity = await _repository.Image.GetImageByIdAsync(imageId, trackChanges: true);
            if (imageEntity is null)
                return NotFound($"Image with id {imageId} does not exist.");

           /* if (imageEntity.PublicId != null)
            {
                var result = await _imageService.DeleteImageAsync(imageEntity.PublicId);
                if (result.Error != null)
                    return BadRequest(result.Error.Message);
            }*/


            _repository.Image.DeleteImageAsync(imageEntity);

            await _repository.SaveAsync();

            return NoContent();
        }
    }
}


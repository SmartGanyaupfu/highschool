﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using HighSchool.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Crypto;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HighSchool.API.Controllers.API
{
    [Route("api/media")]

    public class ImageController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        //private readonly IMapper _mapper;
        //private readonly IImageUploader _imageService;
        //private readonly IServiceManager _service;

        public ImageController(IRepositoryManager repository)
        {
            _repository = repository;
           /* _mapper = mapper;
            _imageService = imageService;
            _service = service;*/
        }
        /*// GET: api/values
        [HttpGet]
        public async Task<IActionResult> GetImages([FromQuery] RequestParameters requestParameters)
        {

            var imagesFromDb = await _repository.Image.GetAllImagesAsync(requestParameters, trackChanges: false);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(imagesFromDb.MetaData));
            var imagesToReturn = _mapper.Map<IEnumerable<ImageDto>>(imagesFromDb);
            return Ok(imagesToReturn);
        }*/

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
       /* [Authorize]
        [HttpPost("add-image")]
        public async Task<IActionResult> AddImage(IFormFile[] files)
        {

           // var userId = User.GetUserId();

            var images = new List<Image>();

            var results = await _imageService.AddImageAsync(files);
            foreach (var result in results)
            {
                if (result.Error != null)
                    return BadRequest(result.Error.Message);

                var image = new Image()
                {
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    Deleted = false,
                    PublicId = result.PublicId,
                    ImageUrl = result.SecureUrl.AbsoluteUri,
                    AuthorId = userId
                };

                images.Add(image);
            }



            //var imageEntity = _mapper.Map<Image>(image);
            _repository.Image.CreateImagesAsync(images);

            await _repository.SaveAsync();

            var imagesToReturn = _mapper.Map<IEnumerable<ImageDto>>(images);


            //return CreatedAtRoute("imagesId", new { imageId = imageToReturn.ImageId }, imageToReturn);
            return Ok(images);
        }*/

       /* [Authorize]

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
        }*/

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


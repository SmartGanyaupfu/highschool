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
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HighSchool.API.Controllers.API.settings
{
    [Route("api/fee-categories")]
    public class FeeCategoriesController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        // private readonly IImageUploader _imageService;

        public FeeCategoriesController(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        // GET: api/fee-categories
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            var feeCategories = await _repository.FeeCategory.GetAllFeeCategoriesAsync( trackChanges: false);
           


            return Ok(feeCategories);
        }
        // GET: api/fee-categories/published
        [HttpGet("published")]
        public async Task<IActionResult> GetAllPublished()
        {

            var feeCategories = await _repository.FeeCategory.GetAllPublishedFeeCategoriesAsync(trackChanges: false);



            return Ok(feeCategories);
        }
        // GET: api/fee-categories/draft
        [HttpGet("draft")]
        public async Task<IActionResult> GetAllDraft()
        {

            var feeCategories = await _repository.FeeCategory.GetAllDraftFeeCategoriesAsync(trackChanges: false);



            return Ok(feeCategories);
        }

        //  api/fee-categories/1
        [HttpGet("{feeCategoryId}", Name = "feeCategoryIdRoute")]
        public async Task<IActionResult> GetFeeCategoryById(int feeCategoryId)
        {
            var feeCategory = await _repository.FeeCategory.GetFeeCategoryByIdAsync(feeCategoryId,trackChanges: false);
            if (feeCategory is null)
                return NotFound();


            return Ok(feeCategory);
        }




        //* [Authorize]
        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateFeeCategory([FromBody] FeeCategoryForCreationDto feeCategory)
        {

            feeCategory.AuthorId = User.GetUserId();

            var feeCatEntity = _mapper.Map<FeeCategory>(feeCategory);
            _repository.FeeCategory.CreateFeeCategoryAsync(feeCatEntity);
            await _repository.SaveAsync();
            var catToReturn = _mapper.Map<FeeCategoryDto>(feeCatEntity);


            return CreatedAtRoute("feeCategoryIdRoute", new { feeCategoryId = feeCatEntity.FeeCategoryId }, catToReturn);

           // return Ok(blockEntity);
        }

        //[Authorize]
        [HttpPut("{feeCategoryId}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Update(int feeCategoryId, [FromBody] FeeCategoryForUpdateDto feeCategoryForUpdate)
        {

            feeCategoryForUpdate.AuthorId = User.GetUserId();
            feeCategoryForUpdate.DateUpdated = DateTime.Now;
            var feeCatEntity = await _repository.FeeCategory.GetFeeCategoryByIdAsync(feeCategoryId, trackChanges: true);
            if (feeCatEntity is null)
                return NotFound($"Fee Cat with id {feeCategoryId} does not exist");



            _mapper.Map(feeCategoryForUpdate, feeCatEntity);

            await _repository.SaveAsync();
            return NoContent();
        }
        //[Authorize]
        // Page is set to delete only
        [HttpPut("delete/{feeCategoryId}")]
        public async Task<IActionResult> MoveToBin(int feeCategoryId)
        {


            var feeCatEntity = await _repository.FeeCategory.GetFeeCategoryByIdAsync(feeCategoryId, trackChanges: false);
            if (feeCatEntity is null)
                return NotFound($"Fee Cat with id {feeCategoryId} does not exist");
            feeCatEntity.AuthorId = User.GetUserId();

            _repository.FeeCategory.MoveToTrash(feeCatEntity);

            await _repository.SaveAsync();

            return NoContent();
        }

        [HttpPut("set-draft/{feeCategoryId}")]
        public async Task<IActionResult> MoveToDraft(int feeCategoryId)
        {


            var feeCatEntity = await _repository.FeeCategory.GetFeeCategoryByIdAsync(feeCategoryId, trackChanges: false);
            if (feeCatEntity is null)
                return NotFound($"Fee Cat with id {feeCategoryId} does not exist");

            feeCatEntity.AuthorId = User.GetUserId();
            _repository.FeeCategory.SetToDraft(feeCatEntity);

            await _repository.SaveAsync();

            return NoContent();
        }

        [HttpPut("publish/{feeCategoryId}")]
        public async Task<IActionResult> Publish(int feeCategoryId)
        {


            var feeCatEntity = await _repository.FeeCategory.GetFeeCategoryByIdAsync(feeCategoryId, trackChanges: false);
            if (feeCatEntity is null)
                return NotFound($"Fee Cat with id {feeCategoryId} does not exist");

            feeCatEntity.AuthorId = User.GetUserId();
            _repository.FeeCategory.Publish(feeCatEntity);

            await _repository.SaveAsync();

            return NoContent();
        }

        [HttpPut("perm-delete/{feeCategoryId}")]
        public async Task<IActionResult> MoveToDraftft(int feeCategoryId)
        {


            var feeCatEntity = await _repository.FeeCategory.GetFeeCategoryByIdAsync(feeCategoryId, trackChanges: false);
            if (feeCatEntity is null)
                return NotFound($"Fee Cat with id {feeCategoryId} does not exist");


            _repository.FeeCategory.PermanentDelete(feeCatEntity);

            await _repository.SaveAsync();

            return NoContent();
        }
    }
}


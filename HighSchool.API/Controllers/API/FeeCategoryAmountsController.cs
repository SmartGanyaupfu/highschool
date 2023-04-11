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

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HighSchool.API.Controllers.API
{
    [Route("api/fee-category-amounts")]
    public class FeeCategoryAmountsController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        // private readonly IImageUploader _imageService;

        public FeeCategoryAmountsController(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        // GET: api/fee-category-amounts
        [HttpGet("by-level/{studentLevelId}")]
        public async Task<IActionResult> GetAll(int studentLevelId)
        {

            var feeCategories = await _repository.FeeCategoryAmount.GetAllFeeCategoryAmountsAsync(studentLevelId,trackChanges: false);



            return Ok(feeCategories);
        }
        // GET: api/fee-category-amounts/published
        [HttpGet("published/{studentLevelId}")]
        public async Task<IActionResult> GetAllPublished( int studentLevelId)
        {


            var feeCategories = await _repository.FeeCategoryAmount.GetAllPublishFeeCategoryAmountsAsync(studentLevelId, trackChanges: false);



            return Ok(feeCategories);
        }
        // GET: api/fee-category-amounts/draft
        [HttpGet("draft/{studentLevelId}")]
        public async Task<IActionResult> GetAllDraft(int studentLevelId)
        {

            var feeCategories = await _repository.FeeCategoryAmount.GetAllDraftFeeCategoryAmountsAsync(studentLevelId, trackChanges: false);



            return Ok(feeCategories);
        }

        //  api/fee-category-amounts/1
        [HttpGet("{feeCategoryAmountId}", Name = "feeCategoryAmountIdRoute")]
        public async Task<IActionResult> GetFeeCategoryAmountById(int feeCategoryAmountId)
        {
            var feeCategoryAmount = await _repository.FeeCategoryAmount.GetFeeCategoryAmountByIdAsync(feeCategoryAmountId, trackChanges: false);
            if (feeCategoryAmount is null)
                return NotFound();


            return Ok(feeCategoryAmount);
        }




        //* [Authorize]
        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateFeeCategoryAmount([FromBody] FeeCategoryAmountForCreationDto feeCategoryAmount)
        {

            feeCategoryAmount.AuthorId = User.GetUserId();

            var feeAmountEntity = _mapper.Map<FeeCategoryAmount>(feeCategoryAmount);
            _repository.FeeCategoryAmount.CreateFeeCategoryAmountAsync(feeAmountEntity);
            await _repository.SaveAsync();
            var amountToReturn = _mapper.Map<FeeCategoryAmountDto>(feeAmountEntity);


            return CreatedAtRoute("feeCategoryAmountIdRoute", new { feeCategoryAmountId = feeAmountEntity.FeeCategoryId }, amountToReturn);

            // return Ok(blockEntity);
        }

        //[Authorize]
        [HttpPut("{feeCategoryAmountId}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Update(int feeCategoryAmountId, [FromBody] FeeCategoryAmountForUpdateDto feeCategoryAmountForUpdate)
        {

            feeCategoryAmountForUpdate.AuthorId = User.GetUserId();
            feeCategoryAmountForUpdate.DateUpdated = DateTime.Now;
            var feeAmountEntity = await _repository.FeeCategoryAmount.GetFeeCategoryAmountByIdAsync(feeCategoryAmountId, trackChanges: true);
            if (feeAmountEntity is null)
                return NotFound($"Fee Amount with id {feeCategoryAmountId} does not exist");



            _mapper.Map(feeCategoryAmountForUpdate, feeAmountEntity);

            await _repository.SaveAsync();
            return NoContent();
        }
        //[Authorize]
        // Page is set to delete only
        [HttpPut("delete/{feeCategoryAmountId}")]
        public async Task<IActionResult> MoveToBin(int feeCategoryAmountId)
        {


            var feeAmountEntity = await _repository.FeeCategoryAmount.GetFeeCategoryAmountByIdAsync(feeCategoryAmountId, trackChanges: true);
            if (feeAmountEntity is null)
                return NotFound($"Fee Amount with id {feeCategoryAmountId} does not exist");
            feeAmountEntity.AuthorId = User.GetUserId();

            _repository.FeeCategoryAmount.MoveToTrash(feeAmountEntity);

            await _repository.SaveAsync();

            return NoContent();
        }

        [HttpPut("set-draft/{feeCategoryAmountId}")]
        public async Task<IActionResult> MoveToDraft(int feeCategoryAmountId)
        {


            var feeAmountEntity = await _repository.FeeCategoryAmount.GetFeeCategoryAmountByIdAsync(feeCategoryAmountId, trackChanges: true);
            if (feeAmountEntity is null)
                return NotFound($"Fee Amount with id {feeCategoryAmountId} does not exist");
            feeAmountEntity.AuthorId = User.GetUserId();

            _repository.FeeCategoryAmount.SetToDraft(feeAmountEntity);

            await _repository.SaveAsync();

            return NoContent();
        }

        [HttpPut("publish/{feeCategoryAmountId}")]
        public async Task<IActionResult> Publish(int feeCategoryAmountId)
        {



            var feeAmountEntity = await _repository.FeeCategoryAmount.GetFeeCategoryAmountByIdAsync(feeCategoryAmountId, trackChanges: true);
            if (feeAmountEntity is null)
                return NotFound($"Fee Amount with id {feeCategoryAmountId} does not exist");
            feeAmountEntity.AuthorId = User.GetUserId();

            _repository.FeeCategoryAmount.Publish(feeAmountEntity);

            await _repository.SaveAsync();

            return NoContent();
        }

        [HttpPut("perm-delete/{feeCategoryAmountId}")]
        public async Task<IActionResult> MoveToDraftft(int feeCategoryAmountId)
        {


            var feeAmountEntity = await _repository.FeeCategoryAmount.GetFeeCategoryAmountByIdAsync(feeCategoryAmountId, trackChanges: true);
            if (feeAmountEntity is null)
                return NotFound($"Fee Amount with id {feeCategoryAmountId} does not exist");

            _repository.FeeCategoryAmount.PermanentDelete(feeAmountEntity);

            await _repository.SaveAsync();

            return NoContent();
        }

    }
}


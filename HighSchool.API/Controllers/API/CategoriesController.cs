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
    [Route("api/categories")]
    public class CategoriesController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        // private readonly IImageUploader _imageService;

        public CategoriesController(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        // GET: api/values
        [HttpGet]
        public async Task<IActionResult> GeCategories()
        {

            var categories = await _repository.Category.GetAllCategoriesAsync(trackChanges: false);
            var categoriesToReturn = _mapper.Map<IEnumerable<CategoryDto>>(categories);

         
            return Ok(categoriesToReturn);
        }

        // GET api/values/5
        [HttpGet("{categoryId}", Name = "categoriesId")]
        public async Task<IActionResult> GetCategoryById(int categoryId)
        {
            var category = await _repository.Category.GetCategoryIdAsync(categoryId, trackChanges: false);
            if (category is null)
                return NotFound();
            var categoryToReturn = _mapper.Map<CategoryDto>(category);

           
            return Ok(categoryToReturn);
        }
        [HttpGet("slug/{categorySlug}")]
        public async Task<IActionResult> GetCategoryBySlug(string categorySlug)
        {
            var category = await _repository.Category.GetCategorySlugAsync(categorySlug, trackChanges: false);
            if (category is null)
                return NotFound();
            var categoryToReturn = _mapper.Map<CategoryDto>(category);

           
            return Ok(categoryToReturn);
        }



        //* [Authorize]
        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateCategory([FromBody] CategoryForCreationDto category)
        {
            var categoryFromDb = await _repository.Category.GetCategorySlugAsync(category.Slug, trackChanges: false);

            if (categoryFromDb != null)
            {
                category.Slug += "-copy";
            }
            category.AuthorId = User.GetUserId();

            var categoryEntity = _mapper.Map<Category>(category);
            _repository.Category.CreateCategoryAsync(categoryEntity);
            await _repository.SaveAsync();
            var categoryToReturn = _mapper.Map<CategoryDto>(categoryEntity);

            //var votesToReturn = await _serviceManager.QualificationService.CreateQualificationForStudyOptionAsync(studyOptionId, qualification, trackChanges: false);
            return CreatedAtRoute("categoriesId", new { categoryId = categoryToReturn.CategoryId }, categoryToReturn);
        }
       
        //[Authorize]
        [HttpPut("{categoryId}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateCategoryById(int categoryId, [FromBody] CategoryForUpdateDto category)
        {
            var categoryFromDb = await _repository.Category.GetCategorySlugAsync(category.Slug, trackChanges: false);

            if (categoryFromDb != null && categoryFromDb.CategoryId !=categoryId )
            {
                category.Slug += "-copy";
            }
            category.AuthorId = User.GetUserId();

            var categoryEntity = await _repository.Category.GetCategoryIdAsync(categoryId, trackChanges: true);
            if (categoryEntity is null)
                return NotFound($"Category with id {categoryId} does not exist");



            _mapper.Map(category, categoryEntity);

            await _repository.SaveAsync();
            return NoContent();
        }
        //[Authorize]
        // Page is set to delete only
        [HttpDelete("{categoryId}")]
        public async Task<IActionResult> DeleteValue(int categoryId)
        {


            var categoryEntity = await _repository.Category.GetCategoryIdAsync(categoryId, trackChanges: true);
            if (categoryEntity is null)
                return NotFound($"Category with id {categoryId} does not exist");



            _repository.Category.DeleteCategoryAsync(categoryEntity);

            await _repository.SaveAsync();

            return NoContent();
        }

   
    }
}


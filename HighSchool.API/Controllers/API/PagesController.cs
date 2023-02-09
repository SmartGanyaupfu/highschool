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
using Microsoft.AspNetCore.Mvc.RazorPages;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HighSchool.API.Controllers.API
{
    [Route("api/pages")]

    public class PageController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        // private readonly IImageUploader _imageService;

        public PageController(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
         // GET: api/values
         [HttpGet]
         public async Task<IActionResult> GetPages([FromQuery] RequestParameters requestParameters)
         {

             var pages = await _repository.Page.GetAllPagesAsync(requestParameters, trackChanges: false);
             Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pages.MetaData));
             var pagesToReturn = _mapper.Map<IEnumerable<PageDto>>(pages);

             foreach (var post in pagesToReturn)
             {

                 Image image;


                 if (post.FeatureImageId != null)
                 {
                     image = await _repository.Image.GetImageByIdAsync((int)post.FeatureImageId, trackChanges: false);
                     post.Image = _mapper.Map<ImageDto>(image);
                 }
                /* Gallery gallery;
                 if (post.SgGalleryId != null)
                 {
                     gallery = await _repository.Gallery.GetGalleryByIdAsync((int)post.SgGalleryId, trackChanges: false);
                     post.Gallery = _mapper.Map<GalleryDto>(gallery);
                 }*/
             }
             return Ok(pagesToReturn);
         }
        
        // GET api/values/5
        [HttpGet("{pageId}", Name = "pagesId")]
        public async Task<IActionResult> GetPageById(Guid pageId)
        {
            var page = await _repository.Page.GetPageByIdAsync(pageId, trackChanges: false);
            if (page is null)
                return NotFound();
             var pageToReturn = _mapper.Map<PageDto>(page);

             Image image;


             if (page.FeatureImageId != null)
             {
                 image = await _repository.Image.GetImageByIdAsync((int)page.FeatureImageId, trackChanges: false);
                 pageToReturn.Image = _mapper.Map<ImageDto>(image);
             }
            /* Gallery gallery;
             if (page.SgGalleryId != null)
             {
                 gallery = await _repository.Gallery.GetGalleryByIdAsync((int)page.SgGalleryId, trackChanges: false);
                 pageToReturn.Gallery = _mapper.Map<GalleryDto>(gallery);
             }*/
            return Ok(pageToReturn);
        }
        [HttpGet("slug/{pageSlug}")]
        public async Task<IActionResult> GetPageBySlug(string pageSlug)
        {
            var page = await _repository.Page.GetPageBySlugNameAsync(pageSlug, trackChanges: false);
            if (page is null)
                return NotFound();
            var pageToReturn = _mapper.Map<PageDto>(page);

            Image image;


            if (page.FeatureImageId != null)
            {
                image = await _repository.Image.GetImageByIdAsync((int)page.FeatureImageId, trackChanges: false);
                pageToReturn.Image = _mapper.Map<ImageDto>(image);
            }
            /* Gallery gallery;
             if (page.SgGalleryId != null)
             {
                 gallery = await _repository.Gallery.GetGalleryByIdAsync((int)page.SgGalleryId, trackChanges: false);
                 pageToReturn.Gallery = _mapper.Map<GalleryDto>(gallery);
             }*/
            return Ok(pageToReturn);
        }



        //* [Authorize]
         [HttpPost]
         [ServiceFilter(typeof(ValidationFilterAttribute))]
         public async Task<IActionResult> CreatePage([FromBody] PageForCreationDto page)
         {
             var pagesFromDb = await _repository.Page.GetPageBySlugNameAsync(page.Slug, trackChanges: false);

             if (pagesFromDb != null)
             {
                 page.Slug += "-copy";
             }
             page.AuthorId = User.GetUserId();

             var pageEntity = _mapper.Map<Entities.Models.Page>(page);
             _repository.Page.CreatePageAsync(pageEntity);
             await _repository.SaveAsync();
             var pageToReturn = _mapper.Map<PageDto>(pageEntity);

             //var votesToReturn = await _serviceManager.QualificationService.CreateQualificationForStudyOptionAsync(studyOptionId, qualification, trackChanges: false);
             return CreatedAtRoute("pagesId", new { pageId = pageToReturn.PageId }, pageToReturn);
         }
        /*
        [Authorize]
         [HttpPost("{pageId}/add-block")]
         public async Task<IActionResult> AddBlock([FromBody] ContentBlockForCreationDto contentBlock, int pageId)
         {
             var pageEntity = await _repository.Page.GetPageByIdAsync(pageId: pageId, trackChanges: false);
             if (pageEntity is null)
                 return NotFound($"page with id {pageId} does not exist");


             var blockEntity = _mapper.Map<ContentBlock>(contentBlock);
             _repository.ContentBlock.CreateContentBlockAsync(blockEntity);

             await _repository.SaveAsync();

             var pageToReturn = _mapper.Map<PageDto>(pageEntity);


             return CreatedAtRoute("pagesId", new { pageId = pageToReturn.PageId }, pageToReturn);
         }
        */
        //[Authorize]
         [HttpPut("{pageId}")]
         [ServiceFilter(typeof(ValidationFilterAttribute))]
         public async Task<IActionResult> UpdatePageById(Guid pageId, [FromBody] PageForUpdateDto page)
         {
             var pageFromDb = await _repository.Page.GetPageBySlugNameAsync(page.Slug, trackChanges: false);

             if (pageFromDb != null && pageFromDb.PageId != pageId)
             {
                 page.Slug += "-copy";
             }
             page.AuthorId = User.GetUserId();

             var pageEntity = await _repository.Page.GetPageByIdAsync(pageId, trackChanges: true);
             if (pageEntity is null)
                 return NotFound($"page with id {pageId} does not exist");



             _mapper.Map(page, pageEntity);

             await _repository.SaveAsync();
             return NoContent();
         }
        //[Authorize]
        // Page is set to delete only
        [HttpDelete("{pageId}")]
        public async Task<IActionResult> DeleteValue(Guid pageId)
        {


            var pageEntity = await _repository.Page.GetPageByIdAsync(pageId: pageId, trackChanges: false);
            if (pageEntity is null)
                return NotFound($"page with id {pageId} does not exist");



            _repository.Page.MoveToTrash(pageEntity);

            await _repository.SaveAsync();

            return NoContent();
        }

        [HttpDelete("permanentDelete/{pageId}")]

        public async Task<IActionResult> DeletePostPermanently(Guid pageId)
        {
            var pageEntity = await _repository.Page.GetPageByIdAsync(pageId, trackChanges: false);

            if (pageEntity is null)
                return NotFound($"Page with id {pageId} does not exist");

            _repository.Page.PermanentDelete(pageEntity);
            await _repository.SaveAsync();

            return NoContent();
        }

        [HttpPut("publish/{pageId}")]
        public async Task<IActionResult> PublishPost(Guid pageId)
        {
            var pageEntity = await _repository.Page.GetPageByIdAsync(pageId: pageId, trackChanges: false);
            if (pageEntity is null)
                return NotFound($"Page with id {pageId} does not exist");

            _repository.Page.Publish(pageEntity);

            await _repository.SaveAsync();

            return NoContent();
        }

        [HttpPut("save-draft/{pageId}")]
        public async Task<IActionResult> SetPageToDraft(Guid pageId)
        {
            var pageEntity = await _repository.Page.GetPageByIdAsync(pageId: pageId, trackChanges: false);
            if (pageEntity is null)
                return NotFound($"Page with id {pageId} does not exist");

            _repository.Page.SetToDraft(pageEntity);

            await _repository.SaveAsync();

            return NoContent();
        }
    }
}


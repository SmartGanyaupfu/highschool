using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using HighSchool.API.ActionFilters;
using HighSchool.API.Extensions;
using HighSchool.API.Migrations;
using HighSchool.Contracts;
using HighSchool.Entities.Models;
using HighSchool.Shared.DTOs;
using HighSchool.Shared.RequestFeatures;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Crypto;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HighSchool.API.Controllers.API
{
    [Route("api/posts")]

    public class PostsController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public PostsController(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        // GET: api/values
        [HttpGet]
        public async Task<IActionResult> GetPosts([FromQuery] PostParameters postParameters)
        {

            var posts = await _repository.Post.GetAllPostsAsync(postParameters, trackChanges: false);


            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(posts.MetaData));
            var postsToReturn = _mapper.Map<IEnumerable<PostMVDto>>(posts);
            foreach (var post in postsToReturn)
            {
               // Category category;
                Image image;

         
                if (post.Post.FeatureImageId != null)
                {
                    image = await _repository.Image.GetImageByIdAsync((int)post.Post.FeatureImageId, trackChanges: false);
                    post.Post.Image = _mapper.Map<ImageDto>(image);
                }
                /*Gallery gallery;
                if (post.SgGalleryId != null)
                {
                    gallery = await _repository.Gallery.GetGalleryByIdAsync((int)post.SgGalleryId, trackChanges: false);
                    post.Gallery = _mapper.Map<GalleryDto>(gallery);
                }*/
            }
            return Ok(postsToReturn);
        }

        // GET api/values/5
        [HttpGet("{postId}", Name = "postsId")]
        public async Task<IActionResult> GetPageById(Guid postId)
        {
            var post = await _repository.Post.GetPostByIdAsync(postId, trackChanges: false);
            if (post is null)
                return NotFound();
            
            Image image;
            //Gallery gallery;
            var postToReturn = _mapper.Map<PostMVDto>(post);
            
            if (post.Post.FeatureImageId != null)
            {
                image = await _repository.Image.GetImageByIdAsync((int)post.Post.FeatureImageId, trackChanges: false);
                postToReturn.Post.Image = _mapper.Map<ImageDto>(image);
            }
            /*  if (post.SgGalleryId != null)
           {
               gallery = await _repository.Gallery.GetGalleryByIdAsync((int)post.SgGalleryId, trackChanges: false);
               postToReturn.Gallery = _mapper.Map<GalleryDto>(gallery);
           }
           var pageToReturn = _mapper.Map<PostDto>(post);*/



            return Ok(postToReturn);
        }
        [HttpGet("slug/{postSlug}")]
        public async Task<IActionResult> GetPostBySlug(string postSlug)
        {
            var post = await _repository.Post.GetPostBySlugNameAsync(postSlug, trackChanges: false);
            if (post is null)
                return NotFound();
        
            Image image;
          
            //Gallery gallery;
            var postToReturn = _mapper.Map<PostMVDto>(post);

            if (post.Post.FeatureImageId != null)
            {
                image = await _repository.Image.GetImageByIdAsync((int)post.Post.FeatureImageId, trackChanges: false);
                postToReturn.Post.Image = _mapper.Map<ImageDto>(image);
            }
            /*  if (post.SgGalleryId != null)
           {
               gallery = await _repository.Gallery.GetGalleryByIdAsync((int)post.SgGalleryId, trackChanges: false);
               postToReturn.Gallery = _mapper.Map<GalleryDto>(gallery);
           }
           var pageToReturn = _mapper.Map<PostDto>(post);*/
            return Ok(postToReturn);
        }
        

        //[Authorize]
        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreatePost([FromBody] PostForCreationDto post)
        {
            var postsFromDb = await _repository.Post.GetPostBySlugNameAsync(post.Slug, trackChanges: false);

            if (postsFromDb != null)
            {
                Guid g = Guid.NewGuid();
                post.Slug += g+"-copy";
            }

            post.AuthorId = User.GetUserId();

            var postEntity = _mapper.Map<Post>(post);
            _repository.Post.CreatePostAsync(postEntity);
            await _repository.SaveAsync();

            foreach( var categoryId in post.CategoryIds)
            {
                var postCat = new PostCat()
                {
                    PostId = postEntity.PostId,
                    CategoryId = categoryId
                };
                _repository.PostCat.CreatePostCatAsync(postCat);
                await _repository.SaveAsync();

            }
            var postToReturn = _mapper.Map<PostDto>(postEntity);

            var postFromDb = await _repository.Post.GetPostByIdAsync(postToReturn.PostId, trackChanges: false);
            if (post is null)
                return NotFound("Post created,but could not be found.");

            Image image;
            //Gallery gallery;
            var postFromDbToReturn = _mapper.Map<PostMVDto>(postFromDb);

            if (postFromDb.Post.FeatureImageId != null)
            {
                image = await _repository.Image.GetImageByIdAsync((int)postFromDb.Post.FeatureImageId, trackChanges: false);
                postFromDbToReturn.Post.Image = _mapper.Map<ImageDto>(image);
            }

            //var votesToReturn = await _serviceManager.QualificationService.CreateQualificationForStudyOptionAsync(studyOptionId, qualification, trackChanges: false);
            return Ok(postFromDbToReturn);
        }
        /* [Authorize]
      [HttpPost("{postId}/add-block")]
      public async Task<IActionResult> AddBlock([FromBody] ContentBlockForCreationDto contentBlock, Guid postId)
      {
          var postEntity = await _repository.Post.GetPostByIdAsync(postId, trackChanges: false);
          if (postEntity is null)
              return NotFound($"Post with id {postId} does not exist.");

          var blockEntity = _mapper.Map<ContentBlock>(contentBlock);
          _repository.ContentBlock.CreateContentBlockAsync(blockEntity);

          await _repository.SaveAsync();

          var postToReturn = _mapper.Map<PostDto>(postEntity);


          return CreatedAtRoute("postsId", new { postId = postToReturn.PostId }, postToReturn);
      }
        */
   //[Authorize]
      [HttpPut("{postId}")]
      [ServiceFilter(typeof(ValidationFilterAttribute))]
      public async Task<IActionResult> UpdatePostById(Guid postId, [FromBody] PostForUpdateDto post)
      {
          var postFromDb = await _repository.Post.GetPostBySlugNameAsync(post.Slug, trackChanges: false);

          if (postFromDb != null && postFromDb.Post.PostId != postId)
          {
              post.Slug += "-copy";
          }
          post.AuthorId = User.GetUserId();

          var postEntity = await _repository.Post.GetPostByIdAsync(postId, trackChanges: true);
          if (postEntity is null)
              return NotFound($"Post with id {postId} does not exist");



          _mapper.Map(post, postEntity.Post);

          await _repository.SaveAsync();
            if (post.CategoryIds.Count > 0)
            {
                var postCats = await _repository.PostCat.GetAllPostsAsync(postEntity.Post.PostId, trackChanges: false);

                //delete the postcats before adding new ones

                foreach( var postCat in postCats)
                {
                    _repository.PostCat.DeletePostCatAsync(postCat);
                    await _repository.SaveAsync();
                }

                //adding new categories
                foreach (var categoryId in post.CategoryIds)
                {
                    var postCat = new PostCat()
                    {
                        PostId = postEntity.Post.PostId,
                        CategoryId = categoryId
                    };
                    _repository.PostCat.CreatePostCatAsync(postCat);
                    await _repository.SaveAsync();
                }
            }
            return NoContent();
      }
        //[Authorize]
        [HttpDelete("{postId}")]
        public async Task<IActionResult> MovePostToTrash(Guid postId)
        {


            var postEntity = await _repository.Post.GetPostByIdAsync(postId: postId, trackChanges: false);
            if (postEntity is null)
                return NotFound($"Post with id {postId} does not exist");




            _repository.Post.MoveToTrash(postEntity.Post);

            await _repository.SaveAsync();

            return NoContent();
        }

        [HttpDelete("permanentDelete/{postId}")]

        public async Task<IActionResult> DeletePostPermanently(Guid postId)
        {
            var postEntity = await _repository.Post.GetPostByIdAsync(postId, trackChanges: false);

            if (postEntity is null)
                return NotFound($"Post with id {postId} does not exist");

            _repository.Post.PermanentDelete(postEntity.Post);
            await _repository.SaveAsync();

            return NoContent();
        }

        [HttpPut("publish/{postId}")]
        public async Task<IActionResult> PublishPost( Guid postId)
        {
            var postEntity = await _repository.Post.GetPostByIdAsync(postId: postId, trackChanges: false);
            if (postEntity is null)
                return NotFound($"Post with id {postId} does not exist");

            _repository.Post.Publish(postEntity.Post);

            await _repository.SaveAsync();

            return NoContent();
        }

        [HttpPut("save-draft/{postId}")]
        public async Task<IActionResult> SetPostToDraft(Guid postId)
        {
            var postEntity = await _repository.Post.GetPostByIdAsync(postId: postId, trackChanges: false);
            if (postEntity is null)
                return NotFound($"Post with id {postId} does not exist");

            _repository.Post.SetToDraft(postEntity.Post);

            await _repository.SaveAsync();

            return NoContent();
        }
    }
}



using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text.Json;
using System.Threading.Tasks;
using HighSchool.Contracts;
using HighSchool.Entities.Models;
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

        public PostsController(IRepositoryManager repository)
        {
            _repository = repository;
        }
      /*  // GET: api/values
        [HttpGet]
        public async Task<IActionResult> GetPosts([FromQuery] PostParameters postParameters)
        {

            var posts = await _repository.Post.GetAllPostsAsync(postParameters, trackChanges: false);


            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(posts.MetaData));
            var postsToReturn = _mapper.Map<IEnumerable<PostDto>>(posts);
            foreach (var post in postsToReturn)
            {
                Category category;
                Image image;

                if (post.SgCategoryId != null)
                {


                    category = await _repository.Category.GetCategoryByIdAsync((int)post.SgCategoryId, trackChanges: false);
                    post.Category = _mapper.Map<CategoryDto>(category);
                }
                if (post.SgImageId != null)
                {
                    image = await _repository.Image.GetImageByIdAsync((int)post.SgImageId, trackChanges: false);
                    post.Image = _mapper.Map<ImageDto>(image);
                }
                Gallery gallery;
                if (post.SgGalleryId != null)
                {
                    gallery = await _repository.Gallery.GetGalleryByIdAsync((int)post.SgGalleryId, trackChanges: false);
                    post.Gallery = _mapper.Map<GalleryDto>(gallery);
                }
            }
            return Ok(postsToReturn);
        }*/

        // GET api/values/5
        [HttpGet("{postId}", Name = "postsId")]
        public async Task<IActionResult> GetPageById(Guid postId)
        {
            var post = await _repository.Post.GetPostByIdAsync(postId, trackChanges: false);
            if (post is null)
                return NotFound();
           /* int catId;

            Category category;
            Image image;
            var postToReturn = _mapper.Map<PostDto>(post);
            if (post.SgCategoryId != null)
            {
                catId = (int)post.SgCategoryId;

                category = await _repository.Category.GetCategoryByIdAsync(catId, trackChanges: false);
                postToReturn.Category = _mapper.Map<CategoryDto>(category);
            }
            if (post.SgImageId != null)
            {
                image = await _repository.Image.GetImageByIdAsync((int)post.SgImageId, trackChanges: false);
                postToReturn.Image = _mapper.Map<ImageDto>(image);
            }
            Gallery gallery;
            if (post.SgGalleryId != null)
            {
                gallery = await _repository.Gallery.GetGalleryByIdAsync((int)post.SgGalleryId, trackChanges: false);
                postToReturn.Gallery = _mapper.Map<GalleryDto>(gallery);
            }*/



            return Ok(post);
        }
        [HttpGet("slug/{postSlug}")]
        public async Task<IActionResult> GetPostBySlug(string postSlug)
        {
            var post = await _repository.Post.GetPostBySlugNameAsync(postSlug, trackChanges: false);
            if (post is null)
                return NotFound();
           /* int catId;

            Category category;
            Image image;
            Gallery gallery;
            var postToReturn = _mapper.Map<PostDto>(post);
            if (post.SgCategoryId != null)
            {
                catId = (int)post.SgCategoryId;

                category = await _repository.Category.GetCategoryByIdAsync(catId, trackChanges: false);
                postToReturn.Category = _mapper.Map<CategoryDto>(category);
            }
            if (post.SgImageId != null)
            {
                image = await _repository.Image.GetImageByIdAsync((int)post.SgImageId, trackChanges: false);
                postToReturn.Image = _mapper.Map<ImageDto>(image);
            }
            if (post.SgGalleryId != null)
            {
                gallery = await _repository.Gallery.GetGalleryByIdAsync((int)post.SgGalleryId, trackChanges: false);
                postToReturn.Gallery = _mapper.Map<GalleryDto>(gallery);
            }
            var pageToReturn = _mapper.Map<PostDto>(post);*/
            return Ok(post);
        }


        /*[Authorize]
        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreatePost([FromBody] PostForCreationDto post)
        {
            var postsFromDb = await _repository.Post.GetPostBySlugNameAsync(post.Slug, trackChanges: false);

            if (postsFromDb != null)
            {
                post.Slug += "-copy";
            }

            post.AuthorId = User.GetUserId();

            var postEntity = _mapper.Map<Post>(post);
            _repository.Post.CreatePostAsync(postEntity);
            await _repository.SaveAsync();
            var postToReturn = _mapper.Map<PostDto>(postEntity);

            //var votesToReturn = await _serviceManager.QualificationService.CreateQualificationForStudyOptionAsync(studyOptionId, qualification, trackChanges: false);
            return CreatedAtRoute("postsId", new { PostId = postToReturn.PostId }, postToReturn);
        }
        [Authorize]
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

        [Authorize]
        [HttpPut("{postId}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdatePostById(Guid postId, [FromBody] PostForUpdateDto post)
        {
            var postFromDb = await _repository.Post.GetPostBySlugNameAsync(post.Slug, trackChanges: false);

            if (postFromDb != null && postFromDb.PostId != postId)
            {
                post.Slug += "-copy";
            }
            post.AuthorId = User.GetUserId();

            var postEntity = await _repository.Post.GetPostByIdAsync(postId, trackChanges: true);
            if (postEntity is null)
                return NotFound($"Post with id {postId} does not exist");



            _mapper.Map(post, postEntity);

            await _repository.SaveAsync();
            return NoContent();
        }*/
        [Authorize]
        [HttpDelete("{postId}")]
        public async Task<IActionResult> DeletePost(Guid postId)
        {


            var postEntity = await _repository.Post.GetPostByIdAsync(postId: postId, trackChanges: false);
            if (postEntity is null)
                return NotFound($"Post with id {postId} does not exist");




            _repository.Post.DeletePostAsync(postEntity);

            await _repository.SaveAsync();

            return NoContent();
        }
    }
}



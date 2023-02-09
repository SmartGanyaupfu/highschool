using System;
using HighSchool.Contracts;
using HighSchool.Entities.Models;
using HighSchool.Shared.RequestFeatures;
using Microsoft.EntityFrameworkCore;

namespace HighSchool.Repository
{
    public class PostRepository : GenericRepositoryBase<Post>, IPostRepository
    {
        public PostRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreatePostAsync(Post post)
        {
            Create(post);
        }

        public void MoveToTrash(Post post)
        {
            post.Deleted = true;
            post.DateUpdated = DateTime.Now;
            post.Published = false;
         
            Update(post);
        }

        public async Task<PagedList<PostMV>> GetAllPostsAsync(PostParameters postParameters, bool trackChanges)
        {
            //var posts = await FindAll(trackChanges).Search(postParameters.SearchTerm).FilterPostsByAuthor(postParameters.Author).FilterPostsByCategory(postParameters.SgCategoryId)
            //  .OrderByDescending(p => p.DateCreated).ToListAsync();
            var posts = await FindAll(trackChanges)
            .OrderByDescending(p => p.DateCreated).Select(p => new PostMV()
            {
                Post = p,
                Categories = p.PostCats.Select(c => c.Category).ToList()
            }).ToListAsync();
            return PagedList<PostMV>.ToPagedList(posts, postParameters.PageNumber, postParameters.PageSize);
        }

        public async Task<PostMV> GetPostByIdAsync(Guid postId, bool trackChanges)
        {
            return await FindByCondition(p => p.PostId.Equals(postId), trackChanges).Select(p => new PostMV()
            {
                Post = p,
                Categories = p.PostCats.Select(c => c.Category).ToList()
            }) .SingleOrDefaultAsync();
        }

        public async Task<PostMV> GetPostBySlugNameAsync(string slug, bool trackChanges)
        {
            return await FindByCondition(p => p.Slug.Equals(slug), trackChanges).Select(p => new PostMV()
            {
                Post = p,
                Categories = p.PostCats.Select(c => c.Category).ToList()
            }).SingleOrDefaultAsync();
        }

        public void UpdatePostAsync(Post post)
        {
            Update(post);
        }

        public void SetToDraft(Post post)
        {
            
            post.DateUpdated = DateTime.Now;
            post.Published = false;

            Update(post);
        }

        public void Publish(Post post)
        {
            post.DateUpdated = DateTime.Now;
            post.DatePublished = DateTime.Now;
            post.Published = true;

            Update(post);
        }

        public void PermanentDelete(Post post)
        {
            Delete(post);
        }
    }
}


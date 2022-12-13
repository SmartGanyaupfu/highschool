using System;
using HighSchool.Contracts;
using HighSchool.Entities.Models;
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

        public void DeletePostAsync(Post post)
        {
            Delete(post);
        }

       /* public async Task<PagedList<Post>> GetAllPostsAsync(PostParameters postParameters, bool trackChanges)
        {
            var posts = await FindAll(trackChanges).Search(postParameters.SearchTerm).FilterPostsByAuthor(postParameters.Author).FilterPostsByCategory(postParameters.SgCategoryId)
                .OrderByDescending(p => p.DateCreated).ToListAsync();
            return PagedList<Post>.ToPagedList(posts, postParameters.PageNumber, postParameters.PageSize);
        }*/

        public async Task<Post> GetPostByIdAsync(Guid postId, bool trackChanges)
        {
            return await FindByCondition(p => p.PostId.Equals(postId), trackChanges)
                .SingleOrDefaultAsync();
        }

        public async Task<Post> GetPostBySlugNameAsync(string slug, bool trackChanges)
        {
            return await FindByCondition(p => p.Slug.Equals(slug), trackChanges)
                .SingleOrDefaultAsync();
        }

        public void UpdatePostAsync(Post post)
        {
            Update(post);
        }
    }
}


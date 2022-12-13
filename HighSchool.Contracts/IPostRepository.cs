using System;
using HighSchool.Entities.Models;

namespace HighSchool.Contracts
{
    public interface IPostRepository
    {
       // Task<PagedList<Post>> GetAllPostsAsync(PostParameters postParameters, bool trackChanges);
        Task<Post> GetPostByIdAsync(Guid postId, bool trackChanges);
        Task<Post> GetPostBySlugNameAsync(string slug, bool trackChanges);
        void CreatePostAsync(Post post);
        void DeletePostAsync(Post post);
        void UpdatePostAsync(Post post);
    }
}


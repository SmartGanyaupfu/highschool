using System;
using HighSchool.Entities.Models;
using HighSchool.Shared.RequestFeatures;

namespace HighSchool.Contracts
{
    public interface IPostCatRepository
    {
        Task<IEnumerable<PostCat>> GetAllPostsAsync(Guid postId, bool trackChanges);
        Task<PostCat> GetPostCatByIdAsync(int postCatId, bool trackChanges);
        void CreatePostCatAsync(PostCat postCat);
        void DeletePostCatAsync(PostCat postCat);
        void UpdatePostCatAsync(PostCat postCat);
    }
}


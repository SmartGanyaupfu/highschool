using System;
using HighSchool.Entities.Models;
using HighSchool.Shared.RequestFeatures;

namespace HighSchool.Contracts
{
    public interface IPostRepository
    {
        Task<PagedList<PostMV>> GetAllPostsAsync(PostParameters postParameters, bool trackChanges);
        Task<PostMV> GetPostByIdAsync(Guid postId, bool trackChanges);
        Task<PostMV> GetPostBySlugNameAsync(string slug, bool trackChanges);
        void CreatePostAsync(Post post);
        void MoveToTrash(Post post);
        void SetToDraft(Post post);
        void Publish(Post post);
        void UpdatePostAsync(Post post);
        void PermanentDelete(Post post);
    }
}


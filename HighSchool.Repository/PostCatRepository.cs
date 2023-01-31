using System;
using HighSchool.Contracts;
using HighSchool.Entities.Models;
using HighSchool.Shared.RequestFeatures;
using Microsoft.EntityFrameworkCore;

namespace HighSchool.Repository
{
    public class PostCatRepository : GenericRepositoryBase<PostCat>, IPostCatRepository
    {
        public PostCatRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }

        public void CreatePostCatAsync(PostCat postCat)
        {
            Create(postCat);
        }

        public void DeletePostCatAsync(PostCat postCat)
        {
            Delete(postCat);
        }

        public async Task<IEnumerable<PostCat>> GetAllPostsAsync(Guid postId,bool trackChanges)
        {
            var postCats = await FindByCondition(pc=>pc.PostId.Equals(postId),trackChanges).ToListAsync();

            return postCats;
        }

        public async Task<PostCat> GetPostCatByIdAsync(int postCatId, bool trackChanges)
        {
            return await FindByCondition(p => p.PostCatId.Equals(postCatId), trackChanges).FirstOrDefaultAsync();
        }

        public void UpdatePostCatAsync(PostCat postCat)
        {
            Update(postCat);
        }
    }
}


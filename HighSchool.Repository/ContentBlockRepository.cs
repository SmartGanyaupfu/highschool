using System;
using HighSchool.Contracts;
using HighSchool.Entities.Models;
using HighSchool.Shared.RequestFeatures;
using Microsoft.EntityFrameworkCore;

namespace HighSchool.Repository
{
    public class ContentBlockRepository : GenericRepositoryBase<ContentBlock>, IContentBlockRepository
    {
        public ContentBlockRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }

        public void CreateContentBlockAsync(ContentBlock contentBlock)
        {
            contentBlock.Published = true;
            contentBlock.DatePublished = DateTime.Now;
            Create(contentBlock);
        }

        public async Task<PagedList<ContentBlock>> GetAllStaffAsync(RequestParameters requestParameters, bool trackChanges)
        {
            var contentBlocks = await FindByCondition(s => s.Deleted.Equals(false), trackChanges).OrderByDescending(p => p.DateCreated).ToListAsync();

            return PagedList<ContentBlock>.ToPagedList(contentBlocks, requestParameters.PageNumber, requestParameters.PageSize);
        }

        public async Task<ContentBlock> GetContentBlockByIdAsync(int contentBlockId, bool trackChanges)
        {
            return await FindByCondition(p => p.ContentBlockId.Equals(contentBlockId) && p.Deleted == false, trackChanges).SingleOrDefaultAsync();
        }

      

        public void MoveToTrash(ContentBlock contentBlock)
        {
            contentBlock.Deleted = true;
            contentBlock.DateUpdated = DateTime.Now;
            contentBlock.Published = false;
            Update(contentBlock);
        }


        public void UpdateContentBlockAsync(ContentBlock contentBlock)
        {
            Update(contentBlock);
        }
    }
}


using System;
using HighSchool.Contracts;
using HighSchool.Entities.Models;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using HighSchool.Shared.RequestFeatures;

namespace HighSchool.Repository
{
    public class PageRepository : GenericRepositoryBase<Page>, IPageRepository
    {
        public PageRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }

        public void CreatePageAsync(Page page)
        {
            page.Published = true;
            page.DatePublished = DateTime.Now;
            Create(page);
        }
        public void DeletePageAsync(Page page)
        {
            page.Deleted = true;
            page.DateUpdated = DateTime.Now;
            page.Published = false;
            Update(page);
        }

      

        public async Task<Page> GetPageByIdAsync(Guid pageId, bool trackChanges)
        {
            return await FindByCondition(p => p.PageId.Equals(pageId)&& p.Deleted==false, trackChanges).SingleOrDefaultAsync();
        }

        public void UpdatePageAsync(Page page)
        {
            Update(page);
        }

        public async Task<Page> GetPageBySlugNameAsync(string slug, bool trackChanges)
        {
            return await FindByCondition(p => p.Slug.Equals(slug), trackChanges)
                .SingleOrDefaultAsync();
        }

        public async Task<PagedList<Page>> GetAllPagesAsync(RequestParameters requestParameters, bool trackChanges)
        {
            var pages = await FindByCondition(p=>p.Deleted.Equals(false),trackChanges).OrderByDescending(p=>p.DateCreated).ToListAsync();

            return PagedList<Page>.ToPagedList(pages, requestParameters.PageNumber, requestParameters.PageSize);
        }
    }
}


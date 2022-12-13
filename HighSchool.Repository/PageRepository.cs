using System;
using HighSchool.Contracts;
using HighSchool.Entities.Models;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;

namespace HighSchool.Repository
{
    public class PageRepository : GenericRepositoryBase<Page>, IPageRepository
    {
        public PageRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }

        public void CreatePageAsync(Page page)
        {
            Create(page);
        }
        public void DeletePageAsync(Page page)
        {
            Delete(page);
        }

        /*public async Task<PagedList<Page>> GetAllPagesAsync(PageParameters pageParameters, bool trackChanges)
        {
            var pages = await FindAll(trackChanges).Search(pageParameters.SearchTerm).Include(b => b.ContentBlocks)
                .OrderByDescending(p => p.DateCreated).ToListAsync();
            var pr = PagedList<Page>.ToPagedList(pages, pageParameters.PageNumber, pageParameters.PageSize);
            return pr;
        }*/

        public async Task<Page> GetPageByIdAsync(Guid pageId, bool trackChanges)
        {
            return await FindByCondition(p => p.PageId.Equals(pageId), trackChanges).SingleOrDefaultAsync();
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

       
    }
}


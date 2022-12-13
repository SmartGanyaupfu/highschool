using System;
using System.Security.Cryptography;
using HighSchool.Entities.Models;

namespace HighSchool.Contracts
{
    public interface IPageRepository
    {

        //Task<PagedList<Page>> GetAllPagesAsync(PageParameters pageParameters, bool trackChanges);
        Task<Page> GetPageByIdAsync(Guid pageId, bool trackChanges);
        Task<Page> GetPageBySlugNameAsync(string slug, bool trackChanges);
        void CreatePageAsync(Page page);
        void DeletePageAsync(Page page);
        void UpdatePageAsync(Page page);
    }
}


﻿using System;
using System.Security.Cryptography;
using HighSchool.Entities.Models;
using HighSchool.Shared.RequestFeatures;

namespace HighSchool.Contracts
{
    public interface IPageRepository
    {

        Task<PagedList<Page>> GetAllPagesAsync(RequestParameters requestParameters, bool trackChanges);
        Task<Page> GetPageByIdAsync(Guid pageId, bool trackChanges);
        Task<Page> GetPageBySlugNameAsync(string slug, bool trackChanges);
        void CreatePageAsync(Page page);
        void MoveToTrash(Page page);
        void SetToDraft(Page page);
        void Publish(Page page);
        void UpdatePageAsync(Page page);
        void PermanentDelete(Page page);
    }
}


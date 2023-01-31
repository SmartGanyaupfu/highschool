using System;
using HighSchool.Entities.Models;
using HighSchool.Shared.RequestFeatures;

namespace HighSchool.Contracts
{
    public interface IContentBlockRepository
    {
        Task<PagedList<ContentBlock>> GetAllStaffAsync(RequestParameters requestParameters, bool trackChanges);
        Task<ContentBlock> GetContentBlockByIdAsync(int contentBlockId, bool trackChanges);
        void CreateContentBlockAsync(ContentBlock contentBlock);
        void MoveToTrash(ContentBlock contentBlock);
        
        void UpdateContentBlockAsync(ContentBlock contentBlock);

    }
}


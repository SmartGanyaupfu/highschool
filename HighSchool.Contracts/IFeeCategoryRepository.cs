using System;
using HighSchool.Entities.Models;
using HighSchool.Shared.RequestFeatures;

namespace HighSchool.Contracts
{
    public interface IFeeCategoryRepository
    {
        Task<IEnumerable<FeeCategory>> GetAllFeeCategoriesAsync( bool trackChanges);
        Task<IEnumerable<FeeCategory>> GetAllDraftFeeCategoriesAsync(bool trackChanges);
        Task<IEnumerable<FeeCategory>> GetAllPublishedFeeCategoriesAsync(bool trackChanges);
        Task<FeeCategory> GetFeeCategoryByIdAsync(int feeCategoryId, bool trackChanges);
        void CreateFeeCategoryAsync(FeeCategory feeCategory);
        void MoveToTrash(FeeCategory feeCategory);
        void SetToDraft(FeeCategory feeCategory);
        void Publish(FeeCategory feeCategory);
        void UpdateAsync(FeeCategory feeCategory);
        void PermanentDelete(FeeCategory feeCategory);
    }
}


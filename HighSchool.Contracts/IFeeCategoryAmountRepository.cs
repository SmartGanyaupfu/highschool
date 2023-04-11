using System;
using HighSchool.Entities.Models;
using HighSchool.Shared.RequestFeatures;

namespace HighSchool.Contracts
{
    public interface IFeeCategoryAmountRepository
    {

        Task<IEnumerable<FeeCategoryAmount>> GetAllFeeCategoryAmountsAsync(int studentLevelId,  bool trackChanges);
        Task<IEnumerable<FeeCategoryAmount>> GetAllDraftFeeCategoryAmountsAsync(int studentLevelId,bool trackChanges);
        Task<IEnumerable<FeeCategoryAmount>> GetAllPublishFeeCategoryAmountsAsync(int studentLevelId, bool trackChanges);
        Task<FeeCategoryAmount> GetFeeCategoryAmountByIdAsync(int feeCategoryAmountId, bool trackChanges);
        void CreateFeeCategoryAmountAsync(FeeCategoryAmount feeCategoryAmount);
        void MoveToTrash(FeeCategoryAmount feeCategoryAmount);
        void SetToDraft(FeeCategoryAmount feeCategoryAmount);
        void Publish(FeeCategoryAmount feeCategoryAmount);
        void UpdateAsync(FeeCategoryAmount feeCategoryamount);
        void PermanentDelete(FeeCategoryAmount feeCategoryAmount);
    }
}


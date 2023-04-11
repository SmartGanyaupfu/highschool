using System;
using HighSchool.Contracts;
using HighSchool.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace HighSchool.Repository
{
    public class FeeCategoryAmountRepository : GenericRepositoryBase<FeeCategoryAmount>, IFeeCategoryAmountRepository
    {

        public FeeCategoryAmountRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateFeeCategoryAmountAsync( FeeCategoryAmount feeCategoryAmount)
        {
            feeCategoryAmount.Published = false;
            feeCategoryAmount.DateCreated = DateTime.Now;
            feeCategoryAmount.Deleted = false;
            feeCategoryAmount.DateUpdated = DateTime.Now;
            Create(feeCategoryAmount);
        }

        public  async Task<IEnumerable<FeeCategoryAmount>> GetAllDraftFeeCategoryAmountsAsync(int studentLevelId, bool trackChanges)
        {
            return await FindByCondition(l => l.Published.Equals(false)&& l.StudentLevelId.Equals(studentLevelId), trackChanges).
                Include(s=>s.StudentLevel).Include(f=>f.FeeCategory).ToListAsync();
        }

        public async Task<IEnumerable<FeeCategoryAmount>> GetAllFeeCategoryAmountsAsync(int studentLevelId, bool trackChanges)
        {
            return await FindByCondition(l =>  l.StudentLevelId.Equals(studentLevelId), trackChanges).
               Include(s => s.StudentLevel).Include(f => f.FeeCategory).ToListAsync();
        }

        public async Task<IEnumerable<FeeCategoryAmount>> GetAllPublishFeeCategoryAmountsAsync(int studentLevelId, bool trackChanges)
        {
            return await FindByCondition(l => l.Published.Equals(true) && l.StudentLevelId.Equals(studentLevelId), trackChanges).
                Include(s => s.StudentLevel).Include(f => f.FeeCategory).ToListAsync();
        }

        public async Task<FeeCategoryAmount> GetFeeCategoryAmountByIdAsync(int feeCategoryAmountId, bool trackChanges)
        {
            return await FindByCondition(l => l.FeeCategoryAmountId.Equals(feeCategoryAmountId), trackChanges).SingleOrDefaultAsync();
        }

        public void MoveToTrash(FeeCategoryAmount feeCategoryAmount)
        {
            feeCategoryAmount.Deleted = true;
            feeCategoryAmount.DateUpdated = DateTime.Now;
            Update(feeCategoryAmount);
        }

        public void PermanentDelete(FeeCategoryAmount feeCategoryAmount)
        {
            Delete(feeCategoryAmount);
        }

        public void Publish(FeeCategoryAmount feeCategoryAmount)
        {
            feeCategoryAmount.Deleted = false;
            feeCategoryAmount.DateUpdated = DateTime.Now;
            feeCategoryAmount.DatePublished = DateTime.Now;
            feeCategoryAmount.Published = true;
            Update(feeCategoryAmount);
        }

        public void SetToDraft(FeeCategoryAmount feeCategoryAmount)
        {
            feeCategoryAmount.Deleted = false;
            feeCategoryAmount.DateUpdated = DateTime.Now;
            feeCategoryAmount.Published = false;
            Update(feeCategoryAmount);
        }

        public void UpdateAsync(FeeCategoryAmount feeCategoryamount)
        {
            Update(feeCategoryamount);
        }
    }
}


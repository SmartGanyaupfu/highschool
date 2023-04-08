using System;
using HighSchool.Contracts;
using HighSchool.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace HighSchool.Repository
{
    public class FeeCategoryRepository : GenericRepositoryBase<FeeCategory>, IFeeCategoryRepository
    {

        public FeeCategoryRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateFeeCategoryAsync(FeeCategory feeCategory)
        {
            feeCategory.Published = false;
            feeCategory.DateCreated = DateTime.Now;
            feeCategory.Deleted = false;
            feeCategory.DateUpdated = DateTime.Now;
            Create(feeCategory);
        }

        public async Task<IEnumerable<FeeCategory>> GetAllDraftFeeCategoriesAsync(bool trackChanges)
        {
            return await FindByCondition(l => l.Published.Equals(false), trackChanges).ToListAsync();
        }

        public async Task<IEnumerable<FeeCategory>> GetAllFeeCategoriesAsync(bool trackChanges)
        {
            return await FindAll( trackChanges).ToListAsync();
        }

        public async Task<IEnumerable<FeeCategory>> GetAllPublishedFeeCategoriesAsync(bool trackChanges)
        {
            return await FindByCondition(l => l.Published.Equals(true), trackChanges).ToListAsync();
        }

        public async Task<FeeCategory> GetFeeCategoryByIdAsync(int feeCategoryId, bool trackChanges)
        {
            return await FindByCondition(l => l.FeeCategoryId.Equals(feeCategoryId), trackChanges).SingleOrDefaultAsync();
        }

        public void MoveToTrash(FeeCategory feeCategory)
        {
            feeCategory.Deleted = true;
            feeCategory.DateUpdated = DateTime.Now;
            Update(feeCategory);
        }

        public void PermanentDelete(FeeCategory feeCategory)
        {
            Delete(feeCategory);
        }

        public void Publish(FeeCategory feeCategory)
        {
            feeCategory.Deleted = false;
            feeCategory.DateUpdated = DateTime.Now;
            feeCategory.DatePublished = DateTime.Now;
            feeCategory.Published = true;
            Update(feeCategory);
        }

        public void SetToDraft(FeeCategory feeCategory)
        {
            feeCategory.Deleted = false;
            feeCategory.DateUpdated = DateTime.Now;
            feeCategory.Published = false;
            Update(feeCategory);
        }

        public void UpdateAsync(FeeCategory feeCategory)
        {
            Update(feeCategory);
        }
    }
}


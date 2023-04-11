using System;
using HighSchool.Contracts;
using HighSchool.Entities.Models;
using HighSchool.Shared.RequestFeatures;
using Microsoft.EntityFrameworkCore;

namespace HighSchool.Repository
{
    public class SchoolTermRepository : GenericRepositoryBase<SchoolTerm>, ISchoolTermRepository
    {

        public SchoolTermRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

      

        public void CreateAsync(SchoolTerm schoolTerm)
        {
            schoolTerm.Published = false;
            schoolTerm.Deleted = false;
            schoolTerm.DateCreated = DateTime.Now;
            schoolTerm.DateUpdated = DateTime.Now;
            Create(schoolTerm);
        }

        public async Task<IEnumerable<SchoolTerm>> GetAllDraftSchoolTermsAsync(bool trackChanges)
        {
            return await FindByCondition(l => l.Published.Equals(false), trackChanges).ToListAsync();
        }

        public async Task<IEnumerable<SchoolTerm>> GetAllPublishedSchoolTermsAsync(bool trackChanges)
        {
            return await FindByCondition(l => l.Published.Equals(true), trackChanges).ToListAsync();
        }

      

        public async Task<IEnumerable<SchoolTerm>> GetAllSchoolTermsAsync(bool trackChanges)
        {
            return await FindAll(trackChanges).ToListAsync();
        }

        public async Task<SchoolTerm> GetSchoolTermByIdAsync(int schoolTermId, bool trackChanges)
        {
            return await FindByCondition(l => l.SchoolTermId.Equals(schoolTermId), trackChanges).SingleOrDefaultAsync();
        }

        public void MoveToTrash(SchoolTerm schoolTerm)
        {
            schoolTerm.Deleted = true;
            schoolTerm.DateUpdated = DateTime.Now;
            Update(schoolTerm);
        }

        public void PermanentDelete(SchoolTerm schoolTerm)
        {
            Delete(schoolTerm);
        }

        public void Publish(SchoolTerm schoolTerm)
        {
            schoolTerm.Deleted = false;
            schoolTerm.DateUpdated = DateTime.Now;
            schoolTerm.DatePublished = DateTime.Now;
            schoolTerm.Published = true;
            Update(schoolTerm);

        }

        public void SetToDraft(SchoolTerm schoolTerm)
        {
            schoolTerm.Deleted = false;
            schoolTerm.DateUpdated = DateTime.Now;
            schoolTerm.Published = false;
            Update(schoolTerm);
        }

        public void UpdateAsync(SchoolTerm schoolTerm)
        {
            Update(schoolTerm);
        }

        
    }
}


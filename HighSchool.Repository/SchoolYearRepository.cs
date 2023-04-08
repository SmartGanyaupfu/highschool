using System;
using HighSchool.Contracts;
using HighSchool.Entities.Models;
using HighSchool.Shared.RequestFeatures;
using Microsoft.EntityFrameworkCore;

namespace HighSchool.Repository
{
    public class SchoolYearRepository : GenericRepositoryBase<SchoolYear>, ISchoolYearRepository
    {

        public SchoolYearRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateAsync(SchoolYear schoolYear)
        {
            schoolYear.Published = false;
            schoolYear.DateCreated = DateTime.Now;
            schoolYear.Deleted = false;
            schoolYear.DateUpdated = DateTime.Now;
            Create(schoolYear);
        }

        public async Task<PagedList<SchoolYear>> GetAllDraftSchoolYearsAsync(RequestParameters requestParameters, bool trackChanges)
        {
          var  schoolYears=  await FindByCondition(l => l.Published.Equals(false), trackChanges).ToListAsync();
            return PagedList<SchoolYear>.ToPagedList(schoolYears, requestParameters.PageNumber, requestParameters.PageSize);
        }

        public async Task<PagedList<SchoolYear>> GetAllPublishedSchoolYearsAsync(RequestParameters requestParameters,bool trackChanges)
        {
            var schoolYears = await FindByCondition(l => l.Published.Equals(true), trackChanges).ToListAsync();
            return PagedList<SchoolYear>.ToPagedList(schoolYears, requestParameters.PageNumber, requestParameters.PageSize);
        }

        public async Task<PagedList<SchoolYear>> GetAllSchoolYearsAsync(RequestParameters requestParameters,bool trackChanges)
        {
            var schoolYears = await FindAll( trackChanges).ToListAsync();
            return PagedList<SchoolYear>.ToPagedList(schoolYears, requestParameters.PageNumber, requestParameters.PageSize);
        }

        public async Task<SchoolYear> GetSchoolYearByIdAsync(int schoolYearId, bool trackChanges)
        {
            return await FindByCondition(l => l.SchoolYearId.Equals(schoolYearId), trackChanges).SingleOrDefaultAsync();
        }

        public void MoveToTrash(SchoolYear schoolYear)
        {
            schoolYear.Deleted = true;
            schoolYear.DateUpdated = DateTime.Now;
            Update(schoolYear);
        }

        public void PermanentDelete(SchoolYear schoolYear)
        {
            Delete(schoolYear);
        }

        public void Publish(SchoolYear schoolYear)
        {
            schoolYear.Deleted = false;
            schoolYear.DateUpdated = DateTime.Now;
            schoolYear.DatePublished = DateTime.Now;
            schoolYear.Published = true;
            Update(schoolYear);
        }

        public void SetToDraft(SchoolYear schoolYear)
        {
            schoolYear.Deleted = false;
            schoolYear.DateUpdated = DateTime.Now;
            schoolYear.Published = false;
            Update(schoolYear);
        }

        public void UpdateAsync(SchoolYear schoolYear)
        {
            Update(schoolYear);
        }
    }
}


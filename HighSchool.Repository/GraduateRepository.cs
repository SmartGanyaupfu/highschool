using System;
using System.Diagnostics;
using HighSchool.Contracts;
using HighSchool.Entities.Models;
using HighSchool.Shared.RequestFeatures;
using Microsoft.EntityFrameworkCore;

namespace HighSchool.Repository
{
    public class GraduateRepository : GenericRepositoryBase<Graduate>, IGraduateRepository
    {
        public GraduateRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }

        public void CreateGraduateAsync( Graduate graduate)
        {
           
            Create(graduate);
        }

        public async Task<Graduate> GetGraduateByIdAsync(int graduateId, bool trackChanges)
        {
            return await FindByCondition(c => c.GraduateId.Equals(graduateId), trackChanges)
               .SingleOrDefaultAsync();
        }

        public async Task<PagedList<Graduate>> GetGraduatesAsync(RequestParameters requestParameters, bool trackChanges)
        {
            var graduates = await FindAll(trackChanges)
                .ToListAsync();

            return PagedList<Graduate>.ToPagedList(graduates, requestParameters.PageNumber, requestParameters.PageNumber);
        }

        public void MoveToTrash(Graduate graduate)
        {
            graduate.Deleted = true;
            graduate.DateUpdated = DateTime.Now;
            Update(graduate);
        }

        public void UpdateGradeAsync(Graduate graduate)
        {
            Update(graduate);
        }
    }
}


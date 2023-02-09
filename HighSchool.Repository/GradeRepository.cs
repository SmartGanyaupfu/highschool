using System;
using HighSchool.Contracts;
using HighSchool.Entities.Models;
using HighSchool.Shared.RequestFeatures;
using Microsoft.EntityFrameworkCore;

namespace HighSchool.Repository
{
    public class HClassRepository : GenericRepositoryBase<Grade>, IGradeRepository
    {
        public HClassRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }

        public void CreateClassAsync(Guid staffId, Grade grade)
        {
            grade.StaffId = staffId;
            Create(grade);
        }

        public async Task<Grade> GetClassByIdAsync(int gradeId, bool trackChanges)
        {
            return await FindByCondition(c => c.GradeId.Equals(gradeId), trackChanges).SingleOrDefaultAsync();
        }

        public async Task<PagedList<Grade>> GetClassesAsync(RequestParameters requestParameters, bool trackChanges)
        {
            var classes = await FindAll(trackChanges).ToListAsync();

            return PagedList<Grade>.ToPagedList(classes, requestParameters.PageNumber, requestParameters.PageNumber);
        }

        public void MoveToTrash(Grade grade)
        {
            grade.Deleted = true;
            grade.DateUpdated = DateTime.Now;
            Update(grade);
        }

        public void UpdateClassAsync(Grade grade)
        {
            Update(grade);
        }
    }
}


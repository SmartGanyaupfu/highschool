using System;
using HighSchool.Contracts;
using HighSchool.Entities.Models;
using HighSchool.Shared.RequestFeatures;
using Microsoft.EntityFrameworkCore;

namespace HighSchool.Repository
{
    public class GradeRepository : GenericRepositoryBase<StudentClass>, IGradeRepository
    {
        public GradeRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }

        public void CreateGradeAsync(StudentClass grade)
        {
            
            Create(grade);
        }

        public async Task<StudentClass> GetGradeByIdAsync(int gradeId, bool trackChanges)
        {
            return await FindByCondition(c => c.StudentClassId.Equals(gradeId), trackChanges).SingleOrDefaultAsync();
        }

        public async Task<PagedList<StudentClass>> GetGradesAsync(RequestParameters requestParameters, bool trackChanges)
        {
            var classes = await FindAll(trackChanges)
                 .ToListAsync();

            return PagedList<StudentClass>.ToPagedList(classes, requestParameters.PageNumber, requestParameters.PageSize);
        }

        public void MoveToTrash(StudentClass grade)
        {
            grade.Deleted = true;
            grade.DateUpdated = DateTime.Now;
            Update(grade);
        }

        public void UpdateGradeAsync(StudentClass grade)
        {
            Update(grade);
        }
    }
}


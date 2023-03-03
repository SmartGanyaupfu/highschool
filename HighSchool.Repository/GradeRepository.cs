using System;
using HighSchool.Contracts;
using HighSchool.Entities.Models;
using HighSchool.Shared.RequestFeatures;
using Microsoft.EntityFrameworkCore;

namespace HighSchool.Repository
{
    public class GradeRepository : GenericRepositoryBase<Grade>, IGradeRepository
    {
        public GradeRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }

        public void CreateGradeAsync(Guid staffId, Grade grade)
        {
            grade.StaffId = staffId;
            Create(grade);
        }

        public async Task<GradeMV> GetGradeByIdAsync(int gradeId, bool trackChanges)
        {
            return await FindByCondition(c => c.GradeId.Equals(gradeId), trackChanges)
                .Select(g => new GradeMV()
                {
                    Grade = g,
                    Students= g.StudentGrades.Select(g => g.Student).ToList()
                })
                .SingleOrDefaultAsync();
        }

        public async Task<PagedList<GradeMV>> GetGradesAsync(RequestParameters requestParameters, bool trackChanges)
        {
            var classes = await FindAll(trackChanges)
                 .Select(g => new GradeMV()
                 {
                     Grade = g,
                     Students = g.StudentGrades.Select(g => g.Student).ToList()
                 }).ToListAsync();

            return PagedList<GradeMV>.ToPagedList(classes, requestParameters.PageNumber, requestParameters.PageNumber);
        }

        public void MoveToTrash(Grade grade)
        {
            grade.Deleted = true;
            grade.DateUpdated = DateTime.Now;
            Update(grade);
        }

        public void UpdateGradeAsync(Grade grade)
        {
            Update(grade);
        }
    }
}


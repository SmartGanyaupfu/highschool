using System;
using HighSchool.Contracts;
using HighSchool.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace HighSchool.Repository
{
    public class StudentGradeRepository : GenericRepositoryBase<StudentGrade>, IStudentGradeRepository
    {
        public StudentGradeRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }

        public void CreateAsync(StudentGrade studentGrade)
        {
            Create(studentGrade);
        }

        public void DeleteAsync(StudentGrade studentGrade)
        {
            Delete(studentGrade);
        }

       /* public async Task<IEnumerable<StudentGrade>> GetAllStudentGradesByGradeIdAsync(Guid gradeId, bool trackChanges)
        {
          //  return await FindByCondition(sd => sd.GradeId.Equals(gradeId), trackChanges).ToListAsync();
        }

        public async Task<IEnumerable<StudentGrade>> GetAllStudentGradesByStudentIdAsync(Guid studentId, bool trackChanges)
        {
            return await FindByCondition(sd => sd.StudentId.Equals(studentId), trackChanges).ToListAsync();
        }*/

        public async Task<StudentGrade> GetStudentGradeByIdAsync(int studentGradeId, bool trackChanges)
        {
            return await FindByCondition(sd => sd.StudentGradeId.Equals(studentGradeId), trackChanges).SingleOrDefaultAsync();
        }

        public void UpdateAsync(StudentGrade studentGrade)
        {
            Update(studentGrade);
        }
    }
}


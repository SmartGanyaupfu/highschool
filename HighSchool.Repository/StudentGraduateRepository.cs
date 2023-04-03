using System;
using HighSchool.Contracts;
using HighSchool.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace HighSchool.Repository
{
    public class StudentGraduateRepository : GenericRepositoryBase<StudentGraduate>, IStudentGraduateRepository
    {
        public StudentGraduateRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }

        public void CreateAsync(StudentGraduate studentGraduate)
        {
            Create(studentGraduate);
        }

        public void DeleteAsync(StudentGraduate studentGraduate)
        {
            Delete(studentGraduate);
        }

       /* public async Task<IEnumerable<StudentGraduate>> GetAllStudentGraduatesByGradeIdAsync(Guid graduateId, bool trackChanges)
        {
            return await FindByCondition(sg => sg.GraduateId.Equals(graduateId), trackChanges).ToListAsync();
        }

        public async Task<IEnumerable<StudentGraduate>> GetAllStudentGraduatesByStudentIdAsync(Guid studentId, bool trackChanges)
        {
            return await FindByCondition(sg => sg.StudentId.Equals(studentId), trackChanges).ToListAsync();
        }

        public async Task<StudentGraduate> GetStudentGraduateByIdAsync(int studentGraduateId, bool trackChanges)
        {
            return await FindByCondition(sd => sd.StudentGraduateId.Equals(studentGraduateId), trackChanges).SingleOrDefaultAsync();
        }*/

        public void UpdateAsync(StudentGraduate studentGraduate)
        {
            Update(studentGraduate);
        }
    }
}


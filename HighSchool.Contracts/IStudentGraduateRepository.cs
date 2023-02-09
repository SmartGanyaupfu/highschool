using System;
using HighSchool.Entities.Models;

namespace HighSchool.Contracts
{
    public interface IStudentGraduateRepository
    {
        Task<IEnumerable<StudentGraduate>> GetAllStudentGraduatesByStudentIdAsync(Guid studentId, bool trackChanges);
        Task<IEnumerable<StudentGraduate>> GetAllStudentGraduatesByGradeIdAsync(Guid graduateId, bool trackChanges);
        Task<StudentGraduate> GetStudentGraduateByIdAsync(int studentGraduateId, bool trackChanges);
        void CreateAsync(StudentGraduate studentGraduate);
        void DeleteAsync(StudentGraduate studentGraduate);
        void UpdateAsync(StudentGraduate studentGraduate);
    }
}


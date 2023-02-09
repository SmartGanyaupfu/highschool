using System;
using HighSchool.Entities.Models;

namespace HighSchool.Contracts
{
    public interface IStudentGradeRepository
    {
        Task<IEnumerable<StudentGrade>> GetAllStudentGradesByStudentIdAsync(Guid studentId, bool trackChanges);
        Task<IEnumerable<StudentGrade>> GetAllStudentGradesByGradeIdAsync(Guid gradeId, bool trackChanges);
        Task<StudentGrade> GetStudentGradeByIdAsync(int studentGradeId, bool trackChanges);
        void CreateAsync(StudentGrade studentGrade);
        void DeleteAsync(StudentGrade studentGrade);
        void UpdateAsync(StudentGrade studentGrade);
    }
}


using System;
using HighSchool.Entities.Models;
using HighSchool.Shared.RequestFeatures;

namespace HighSchool.Contracts
{
    public interface IStudentClassRepository
    {

        Task<IEnumerable<StudentClass>> GetAllStudentClassesAsync( bool trackChanges);
        Task<IEnumerable<StudentClass>> GetAllDraftStudentClassesAsync(bool trackChanges);
        Task<IEnumerable<StudentClass>> GetAllPublishedStudentClassesAsync(bool trackChanges);
        Task<StudentClass> GetStudentClassByIdAsync(int studentClassId, bool trackChanges);
        void CreateStudentClassAsync(int levelId,StudentClass studentClass);
        void MoveToTrash(StudentClass studentClass);
        void SetToDraft(StudentClass studentClass);
        void Publish(StudentClass studentClass);
        void UpdateAsync(StudentClass studentClass);
    }
}


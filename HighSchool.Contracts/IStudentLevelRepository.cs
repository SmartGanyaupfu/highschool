using System;
using HighSchool.Entities.Models;
using HighSchool.Shared.RequestFeatures;

namespace HighSchool.Contracts
{
    public interface IStudentLevelRepository
    {

        Task<IEnumerable<StudentLevel>> GetAllStudentLevelsAsync( bool trackChanges);
        Task<IEnumerable<StudentLevel>> GetAllPublishedStudentLevelsAsync(bool trackChanges);
        Task<IEnumerable<StudentLevel>> GetAllDraftStudentLevelsAsync(bool trackChanges);
        Task<StudentLevel> GetStudentLevelByIdAsync(int studentLevelId, bool trackChanges);
        void CreateStudentLevelAsync(StudentLevel studentLevel);
        void MoveToTrash(StudentLevel studentLevel);
        void SetToDraft(StudentLevel studentLevel);
        void Publish(StudentLevel studentLevel);
        void UpdateAsync(StudentLevel studentLevel);
        void PermanentDelete(StudentLevel studentLevel);

    }
}


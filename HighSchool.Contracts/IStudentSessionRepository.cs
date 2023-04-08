using System;
using HighSchool.Entities.Models;
using HighSchool.Shared.RequestFeatures;

namespace HighSchool.Contracts
{
    public interface IStudentSessionRepository
    {

        Task<IEnumerable<StudentSession>> GetAllStudentSessionsAsync( bool trackChanges);
        Task<IEnumerable<StudentSession>> GetAllDrafStudentSessionsAsync(bool trackChanges);
        Task<IEnumerable<StudentSession>> GetAllPublishedStudentSessionsAsync(bool trackChanges);
        Task<StudentSession> GetStudentSessionByIdAsync(int studentSessionId, bool trackChanges);
        void CreateStudentSessionAsync(StudentSession studentSession);
        void MoveToTrash(StudentSession studentSession);
        void SetToDraft(StudentSession studentSession);
        void Publish(StudentSession studentSession);
        void UpdateAsync(StudentSession studentSession);
        void PermanentDelete(StudentSession studentSession);

    }
}


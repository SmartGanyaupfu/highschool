using System;
using HighSchool.Entities.Models;
using HighSchool.Shared.RequestFeatures;

namespace HighSchool.Contracts
{
    public interface IStudentRegistrationRepository
    {

        Task<PagedList<StudentRegistration>> GetAllStudentRegistrationsByYearAsync(int schoolYearId,RequestParameters requestParameters, bool trackChanges);
        Task<PagedList<StudentRegistration>> GetAllStudentRegistrationsByYearAndLevelAsync(int schoolYearId, int studentLevelId, RequestParameters requestParameters, bool trackChanges);
        Task<PagedList<StudentRegistration>> GetAllStudentRegistrationsByYearAndClassAsync(int schoolYearId,  int studentClassId, RequestParameters requestParameters, bool trackChanges);
        Task<PagedList<StudentRegistration>> GetAllDraftStudentRegistrationsByYearAsync(int schoolYearId, RequestParameters requestParameters, bool trackChanges);
        Task<IEnumerable< StudentRegistration>> GetStudentRegistrationByStudentIdAsync(int schoolYearId,Guid StudentId, bool trackChanges);
        Task<StudentRegistration> GetStudentRegistrationByIdAsync(int studentRegistrationId, bool trackChanges);
        void CreateStudentRegistrationAsync( StudentRegistration studentRegistration);
        void MoveToTrash( StudentRegistration studentRegistration);
        void SetToDraft( StudentRegistration studentRegistration);
        void Publish(StudentRegistration studentRegistration);
        void UpdateAsync( StudentRegistration studentRegistration);
        void PermanentDelete( StudentRegistration studentRegistration);

    }
}


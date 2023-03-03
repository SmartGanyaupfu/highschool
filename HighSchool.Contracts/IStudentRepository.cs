using System;
using HighSchool.Entities.Models;
using HighSchool.Shared.RequestFeatures;

namespace HighSchool.Contracts
{
    public interface IStudentRepository
    {

        Task<PagedList<StudentMV>> GetAllStudentsAsync(RequestParameters requestParameters, bool trackChanges);
        Task<StudentMV> GetStudentByIdAsync(Guid studentId, bool trackChanges);
        Task<StudentMV> GetStudentBySlugAsync(string slug, bool trackChanges);
        Task<StudentMV> GetStudentNationalIdAsync(string nationalId, bool trackChanges);
        void CreateStudentAsync(Student student);
        void MoveToTrash(Student student);
        void SetToDraft(Student student);
        void Publish(Student student);
        void UpdateStudentAsync(Student student);
    }
}


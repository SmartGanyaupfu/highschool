using System;
using HighSchool.Entities.Models;
using HighSchool.Shared.RequestFeatures;

namespace HighSchool.Contracts
{
    public interface IStudentRepository
    {

        Task<PagedList<Student>> GetAllStudentsAsync(RequestParameters requestParameters, bool trackChanges);
        Task<Student> GetStudentByIdAsync(Guid studentId, bool trackChanges);
        Task<Student> GetStudentBySlugAsync(string slug, bool trackChanges);
        Task<Student> GetStudentRegistrationNumberAsync(string nationalId, bool trackChanges);
        void CreateStudentAsync(Student student);
        void MoveToTrash(Student student);
        void SetToDraft(Student student);
        void Publish(Student student);
        void UpdateStudentAsync(Student student);
    }
}


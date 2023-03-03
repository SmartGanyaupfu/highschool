using System;
using HighSchool.Entities.Models;
using HighSchool.Shared.RequestFeatures;

namespace HighSchool.Contracts
{
    public interface IStaffRepository
    {
        Task<PagedList<TeacherMV>> GetAllTeachersAsync(RequestParameters requestParameters, bool trackChanges);
        Task<TeacherMV> GetTeacherByIdAsync(Guid staffId, bool trackChanges);
        Task<TeacherMV> GetTeacherBySlugAsync(string slug, bool trackChanges);
        Task<TeacherMV> GetStaffNationalIdAsync(string natId, bool trackChanges);
        void CreateStaffAsync(Staff staff);
        void MoveToTrash(Staff staff);
        void SetToDraft(Staff staff);
        void Publish(Staff staff);
        void UpdateStaffAsync(Staff staff);

     
    }
}


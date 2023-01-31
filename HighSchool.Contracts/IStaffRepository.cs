using System;
using HighSchool.Entities.Models;
using HighSchool.Shared.RequestFeatures;

namespace HighSchool.Contracts
{
    public interface IStaffRepository
    {
        Task<PagedList<Staff>> GetAllStaffAsync(RequestParameters requestParameters, bool trackChanges);
        Task<Staff> GetStaffByIdAsync(Guid staffId, bool trackChanges);
        Task<Staff> GetStaffBySlugAsync(string slug, bool trackChanges);
        void CreateStaffAsync(Staff staff);
        void MoveToTrash(Staff staff);
        void SetToDraft(Staff staff);
        void Publish(Staff staff);
        void UpdateStaffAsync(Staff staff);
    }
}


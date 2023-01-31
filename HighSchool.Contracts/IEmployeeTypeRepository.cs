using System;
using HighSchool.Entities.Models;
using HighSchool.Shared.RequestFeatures;

namespace HighSchool.Contracts
{
    public interface IEmployeeTypeRepository
    {
        Task<IEnumerable<EmployeeType>> GetAllEmployeeTypeAsync( bool trackChanges);
        Task<EmployeeType> GetEmployeeTypeByIdAsync(int employeeTypeId, bool trackChanges);
        void CreateEmployeeTypeAsync(EmployeeType employeeType);
        void MoveToTrash(EmployeeType employeeType);
        void UpdateStaffAsync(EmployeeType employeeType);
    }
}


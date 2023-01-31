using System;
using HighSchool.Contracts;
using HighSchool.Entities.Models;
using HighSchool.Shared.RequestFeatures;
using Microsoft.EntityFrameworkCore;

namespace HighSchool.Repository
{
    public class EmployeeTypeRepository : GenericRepositoryBase<EmployeeType>, IEmployeeTypeRepository
    {
        public EmployeeTypeRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }

        public void CreateEmployeeTypeAsync(EmployeeType employeeType)
        {
            Create(employeeType);
        }

        public async Task<IEnumerable<EmployeeType>> GetAllEmployeeTypeAsync( bool trackChanges)
        {
            return await FindAll(trackChanges).ToListAsync();
        }

      

        public async Task<EmployeeType> GetEmployeeTypeByIdAsync(int employeeTypeId, bool trackChanges)
        {
            return await FindByCondition(p => p.EmployeeTypeId.Equals(employeeTypeId) && p.Deleted == false, trackChanges).SingleOrDefaultAsync();
        }

        public void MoveToTrash(EmployeeType employeeType)
        {
            employeeType.Deleted = true;
            employeeType.DateUpdated = DateTime.Now;
            Update(employeeType);
        }

        public void UpdateStaffAsync(EmployeeType employeeType)
        {
            Update(employeeType);
        }
    }
}


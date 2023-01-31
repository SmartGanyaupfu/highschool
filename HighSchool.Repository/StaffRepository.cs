using System;
using HighSchool.Contracts;
using HighSchool.Entities.Models;
using HighSchool.Shared.RequestFeatures;
using Microsoft.EntityFrameworkCore;

namespace HighSchool.Repository
{
    public class StaffRepository : GenericRepositoryBase<Staff>, IStaffRepository
    {
        public StaffRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }

        public void CreateStaffAsync(Staff staff)
        {
            staff.Published = true;
            staff.DatePublished = DateTime.Now;
            Create(staff);
        }

        public async Task<PagedList<Staff>> GetAllStaffAsync(RequestParameters requestParameters, bool trackChanges)
        {
            var staff = await FindByCondition(s => s.Deleted.Equals(false), trackChanges).OrderByDescending(p => p.DateCreated).ToListAsync();

            return PagedList<Staff>.ToPagedList(staff, requestParameters.PageNumber, requestParameters.PageSize);
        }

        public async Task<Staff> GetStaffByIdAsync(Guid staffId, bool trackChanges)
        {
            return await FindByCondition(p => p.StaffId.Equals(staffId) && p.Deleted == false, trackChanges).SingleOrDefaultAsync();
        }

        public async Task<Staff> GetStaffBySlugAsync(string slug, bool trackChanges)
        {
            return await FindByCondition(p => p.Slug.Equals(slug) && p.Deleted == false, trackChanges).SingleOrDefaultAsync();
        }

        public void MoveToTrash(Staff staff)
        {
            staff.Deleted = true;
            staff.DateUpdated = DateTime.Now;
            staff.Published = false;
            Update(staff);
        }

        public void Publish(Staff staff)
        {
            staff.DateUpdated = DateTime.Now;
            staff.Published = true;
            Update(staff);
        }

        public void SetToDraft(Staff staff)
        {
            staff.DateUpdated = DateTime.Now;
            staff.Published = false;
            Update(staff);
        }

        public void UpdateStaffAsync(Staff staff)
        {
            Update(staff);
        }
    }
}


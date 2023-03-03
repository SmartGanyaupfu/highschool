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

        public async Task<PagedList<TeacherMV>> GetAllTeachersAsync(RequestParameters requestParameters, bool trackChanges)
        {
            var staff = await FindByCondition(s => s.Deleted.Equals(false), trackChanges).OrderByDescending(p => p.DateCreated).Select(
                s=> new TeacherMV()
                {
                    Staff =s,
                    Courses=s.StaffCourses.Select(c=>c.Course).ToList()
                }
                ).ToListAsync();

            return PagedList<TeacherMV>.ToPagedList(staff, requestParameters.PageNumber, requestParameters.PageSize);

        }

        public async Task<TeacherMV> GetStaffNationalIdAsync(string natId, bool trackChanges)
        {
            return await FindByCondition(p => p.NationalIdentityNumber.Equals(natId), trackChanges).Select(
                s => new TeacherMV()
                {
                    Staff = s,
                    Courses = s.StaffCourses.Select(c => c.Course).ToList()
                }
                ).SingleOrDefaultAsync();
        }

        public async Task<TeacherMV> GetTeacherByIdAsync(Guid staffId, bool trackChanges)
        {
            return await FindByCondition(p => p.StaffId.Equals(staffId) && p.Deleted == false, trackChanges).Select(
                s => new TeacherMV()
                {
                    Staff = s,
                    Courses = s.StaffCourses.Select(c => c.Course).ToList()
                }
                ).SingleOrDefaultAsync();
        }

        public async Task<TeacherMV> GetTeacherBySlugAsync(string slug, bool trackChanges)
        {
            return await FindByCondition(p => p.Slug.Equals(slug) && p.Deleted == false, trackChanges).Select(
                s => new TeacherMV()
                {
                    Staff = s,
                    Courses = s.StaffCourses.Select(c => c.Course).ToList()
                }
                ).SingleOrDefaultAsync();
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


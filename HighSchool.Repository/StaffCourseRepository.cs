using System;
using HighSchool.Contracts;
using HighSchool.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace HighSchool.Repository
{
    public class StaffCourseRepository : GenericRepositoryBase<StaffCourse>, IStaffCourseRepository
    {
        public StaffCourseRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }

        public void CreateAsync(StaffCourse staffCourse)
        {
            Create(staffCourse);
        }

        public void DeleteAsync(StaffCourse staffCourse)
        {
            Delete(staffCourse);
        }

        public async Task<IEnumerable<StaffCourse>> GetAllStaffCoursesByCourseIdAsync(Guid courseId, bool trackChanges)
        {
            var staffCourses = await FindByCondition(pc => pc.CourseId.Equals(courseId), trackChanges).ToListAsync();

            return staffCourses;
        }

        public async Task<IEnumerable<StaffCourse>> GetAllStaffCoursesByStaffIdAsync(Guid staffId, bool trackChanges)
        {
            var staffCourses = await FindByCondition(pc => pc.StaffId.Equals(staffId), trackChanges).ToListAsync();

            return staffCourses;
        }

        public async Task<StaffCourse> GetStaffCourseByIdAsync(int staffCourseId, bool trackChanges)
        {
            return await FindByCondition(pc => pc.StaffCourseId.Equals(staffCourseId), trackChanges).SingleOrDefaultAsync();
        }

        public void UpdateAsync(StaffCourse staffCourse)
        {
            Update(staffCourse);
        }
    }
}


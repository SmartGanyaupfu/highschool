using System;
using HighSchool.Entities.Models;

namespace HighSchool.Contracts
{
    public interface IStaffCourseRepository
    {
        Task<IEnumerable<StaffCourse>> GetAllStaffCoursesByStaffIdAsync(Guid staffId, bool trackChanges);
        Task<IEnumerable<StaffCourse>> GetAllStaffCoursesByCourseIdAsync(Guid courseId, bool trackChanges);
        Task<StaffCourse> GetStaffCourseByIdAsync(int staffCourseId, bool trackChanges);
        void CreateAsync(StaffCourse staffCourse);
        void DeleteAsync(StaffCourse staffCourse);
        void UpdateAsync(StaffCourse staffCourse);
    }
}


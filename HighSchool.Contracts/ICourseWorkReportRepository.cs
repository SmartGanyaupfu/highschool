using System;
using HighSchool.Entities.Models;

namespace HighSchool.Contracts
{
    public interface ICourseWorkReportRepository
    {
        Task<IEnumerable<CourseWorkReport>> GetAllCourseWorkReportsForStudentAsync(Guid studentId, int hClassId, bool trackChanges);
        Task<CourseWorkReport> GetCourseWorkReportsByClassIdAsync(Guid studentId, int hClassId,int courseWorkReportId, bool trackChanges);
        void CreateCourseWorkReportAsync(Guid studentId, int hClassId, CourseWorkReport courseWorkReport);
        void MoveToTrash(CourseWorkReport courseWorkReport);
        void UpdateResourceAsync(CourseWorkReport courseWorkReport);
    }
}


using System;
using HighSchool.Entities.Models;

namespace HighSchool.Contracts
{
    public interface ICourseWorkReportRepository
    {
        Task<IEnumerable<CourseWorkReport>> GetAllCourseWorkReportsForStudentAsync(Guid studentId, int studentClassId, bool trackChanges);
        Task<CourseWorkReport> GetCourseWorkReportsByClassIdAsync(Guid studentId, int studentClassId,int courseWorkReportId, bool trackChanges);
        void CreateCourseWorkReportAsync(Guid studentId, int studentClassId, CourseWorkReport courseWorkReport);
        void MoveToTrash(CourseWorkReport courseWorkReport);
        void UpdateResourceAsync(CourseWorkReport courseWorkReport);
    }
}


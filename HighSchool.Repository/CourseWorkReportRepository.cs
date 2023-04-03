using System;
using HighSchool.Contracts;
using HighSchool.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace HighSchool.Repository
{
    public class CourseWorkReportRepository : GenericRepositoryBase<CourseWorkReport>, ICourseWorkReportRepository
    {
        public CourseWorkReportRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }

        public void CreateCourseWorkReportAsync(Guid studentId, int studentClassId, CourseWorkReport courseWorkReport)
        {
            courseWorkReport.StudentId = studentId;
            courseWorkReport.StudentClassId = studentClassId;
            Create(courseWorkReport);
        }

        public async Task<CourseWorkReport> GetCourseWorkReportsByClassIdAsync(Guid studentId, int studentClassId, int courseWorkReportId, bool trackChanges)
        {
            return await FindByCondition(s => s.StudentId.Equals(studentId) && s.StudentClassId.Equals(studentClassId) && s.CourseWorkReportId.Equals(courseWorkReportId), trackChanges).Include(c => c.Course).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<CourseWorkReport>> GetAllCourseWorkReportsForStudentAsync(Guid studentId, int studentClassId, bool trackChanges)
        {
           return await FindByCondition(s => s.StudentId.Equals(studentId) && s.StudentClassId.Equals(studentClassId), trackChanges).Include(c=>c.Course).ToListAsync();
        }

        public void MoveToTrash(CourseWorkReport courseWorkReport)
        {
            courseWorkReport.Deleted = true;
            courseWorkReport.DateUpdated = DateTime.Now;
            Update(courseWorkReport);
        }

        public void UpdateResourceAsync(CourseWorkReport courseWorkReport)
        {
            courseWorkReport.DateUpdated = DateTime.Now;
            Update(courseWorkReport);
        }
    }
}


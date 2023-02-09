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

        public void CreateCourseWorkReportAsync(Guid studentId, int hClassId, CourseWorkReport courseWorkReport)
        {
            courseWorkReport.StudentId = studentId;
            courseWorkReport.HClassId = hClassId;
            Create(courseWorkReport);
        }

        public async Task<CourseWorkReport> GetCourseWorkReportsByClassIdAsync(Guid studentId, int hClassId,int courseWorkReportId, bool trackChanges)
        {
            return await FindByCondition(s => s.StudentId.Equals(studentId) && s.HClassId.Equals(hClassId) && s.CourseWorkReportId.Equals(courseWorkReportId), trackChanges).Include(c => c.Course).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<CourseWorkReport>> GetAllCourseWorkReportsForStudentAsync(Guid studentId, int hClassId, bool trackChanges)
        {
           return await FindByCondition(s => s.StudentId.Equals(studentId) && s.HClassId.Equals(hClassId), trackChanges).Include(c=>c.Course).ToListAsync();
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


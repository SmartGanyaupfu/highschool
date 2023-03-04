using System;
using HighSchool.Contracts;
using HighSchool.Entities.Models;
using HighSchool.Shared.RequestFeatures;
using Microsoft.EntityFrameworkCore;

namespace HighSchool.Repository
{
    public class CourseRepository : GenericRepositoryBase<Course>, ICourseRepository
    {
        public CourseRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }

        public void CreateCourseAsync(Course course)
        {
            course.Published = true;
            course.DatePublished = DateTime.Now;
            Create(course);
        }

        public async Task<PagedList<CourseMV>> GetAllCoursesAsync(RequestParameters requestParameters, bool trackChanges)
        {
            var courses = await FindByCondition(s => s.Deleted.Equals(false), trackChanges).OrderByDescending(p => p.DateCreated).Select(
                c => new CourseMV()
                {
                    Course = c,
                    Staff = c.StaffCourses.Select(sc => sc.Staff).ToList()
                }
                ).ToListAsync();

            return PagedList<CourseMV>.ToPagedList(courses, requestParameters.PageNumber, requestParameters.PageSize);
        }

        public async Task<CourseMV> GetCourseByIdAsync(Guid courseId, bool trackChanges)
        {
            return await FindByCondition(p => p.CourseId.Equals(courseId) && p.Deleted == false, trackChanges).Select(
                c => new CourseMV()
                {
                    Course = c,
                    Staff = c.StaffCourses.Select(sc => sc.Staff).ToList()
                }
                ).SingleOrDefaultAsync();
        }

        public async Task<CourseMV> GetCourseBySlugAsync(string slug, bool trackChanges)
        {
            return await FindByCondition(p => p.Slug.Equals(slug) && p.Deleted == false, trackChanges).Select(
                c => new CourseMV()
                {
                    Course = c,
                    Staff = c.StaffCourses.Select(sc => sc.Staff).ToList()
                }
                ).SingleOrDefaultAsync();
        }

        public void MoveToTrash(Course course)
        {
            course.Deleted = true;
            course.DateUpdated = DateTime.Now;
            course.Published = false;
            Update(course);
        }

        public void PermanentDelete(Course course)
        {
            Delete(course);
        }

        public void Publish(Course course)
        {
            course.DateUpdated = DateTime.Now;
            course.Published = true;
            Update(course);
        }

        public void SetToDraft(Course course)
        {
            course.DateUpdated = DateTime.Now;
            course.Published = false;
            Update(course);
        }

        public void UpdateCourseAsync(Course course)
        {
         
            Update(course);
        }
    }
}


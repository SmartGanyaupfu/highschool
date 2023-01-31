using System;
using HighSchool.Entities.Models;
using HighSchool.Shared.RequestFeatures;

namespace HighSchool.Contracts
{
    public interface ICourseRepository
    {
        Task<PagedList<Course>> GetAllCourseAsync(RequestParameters requestParameters, bool trackChanges);
        Task<Course> GetCourseByIdAsync(int courseId, bool trackChanges);
        Task<Course> GetCourseBySlugAsync(string slug, bool trackChanges);
        void CreateCourseAsync(Course course);
        void MoveToTrash(Course course);
        void SetToDraft(Course course);
        void Publish(Course course);
        void UpdateCourseAsync(Course course);
    }
}


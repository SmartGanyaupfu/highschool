using System;
using HighSchool.Entities.Models;
using HighSchool.Shared.RequestFeatures;

namespace HighSchool.Contracts
{
    public interface ICourseRepository
    {
        Task<PagedList<CourseMV>> GetAllCourseAsync(RequestParameters requestParameters, bool trackChanges);
        Task<CourseMV> GetCourseByIdAsync(int courseId, bool trackChanges);
        Task<CourseMV> GetCourseBySlugAsync(string slug, bool trackChanges);
        void CreateCourseAsync(Course course);
        void MoveToTrash(Course course);
        void SetToDraft(Course course);
        void Publish(Course course);
        void UpdateCourseAsync(Course course);
        void PermanentDelete(Course course);
    }
}


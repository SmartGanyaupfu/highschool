using System;
using HighSchool.Entities.Models;
using HighSchool.Shared.RequestFeatures;

namespace HighSchool.Contracts
{
    public interface ILessonPlanRepository
    {
        Task<PagedList<LessonPlan>> GetLessonPlansForTeacherAsync(Guid staffId, RequestParameters requestParameters, bool trackChanges);
        Task<LessonPlan> GetLessonPlanByIdAsync(Guid staffId, int lessonPlanId, bool trackChanges);
        void CreateLessonPlanAsync(Guid staffId, LessonPlan lessonPlan);
        void MoveToTrash(LessonPlan lessonPlan);
        void UpdateAsync(LessonPlan lessonPlan);
    }
}


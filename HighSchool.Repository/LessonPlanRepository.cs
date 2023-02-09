using System;
using HighSchool.Contracts;
using HighSchool.Entities.Models;
using HighSchool.Shared.RequestFeatures;
using Microsoft.EntityFrameworkCore;

namespace HighSchool.Repository
{
    public class LessonPlanRepository : GenericRepositoryBase<LessonPlan>, ILessonPlanRepository
    {
        public LessonPlanRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }

        public void CreateLessonPlanAsync(Guid staffId, LessonPlan lessonPlan)
        {
            lessonPlan.StaffId = staffId;
            Create(lessonPlan);
        }

        public async Task<LessonPlan> GetLessonPlanByIdAsync(Guid staffId, int lessonPlanId, bool trackChanges)
        {
            return await FindByCondition(l => l.StaffId.Equals(staffId) && l.LessonPlanId.Equals(lessonPlanId), trackChanges).FirstOrDefaultAsync();
        }

        public async Task<PagedList<LessonPlan>> GetLessonPlansForTeacherAsync(Guid staffId, RequestParameters requestParameters, bool trackChanges)
        {
            var lessonPlans = await FindByCondition(l => l.StaffId.Equals(staffId), trackChanges).OrderByDescending(d => d.WeekEnding).ToListAsync();

            return PagedList<LessonPlan>.ToPagedList(lessonPlans, requestParameters.PageNumber, requestParameters.PageSize);
        }

        public void MoveToTrash(LessonPlan lessonPlan)
        {
            Delete(lessonPlan);
        }

        public void UpdateAsync(LessonPlan lessonPlan)
        {
            Update(lessonPlan);
        }
    }
}


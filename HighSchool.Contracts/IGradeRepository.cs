using System;
using HighSchool.Entities.Models;
using HighSchool.Shared.RequestFeatures;

namespace HighSchool.Contracts
{
    public interface IGradeRepository
    {
        Task<PagedList<Grade>> GetClassesAsync(RequestParameters requestParameters, bool trackChanges);
        Task<Grade> GetClassByIdAsync( int gradeId, bool trackChanges);
        void CreateClassAsync(Guid staffId, Grade grade);
        void MoveToTrash(Grade grade);
        void UpdateClassAsync(Grade grade);
    }
}


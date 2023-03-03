using System;
using HighSchool.Entities.Models;
using HighSchool.Shared.RequestFeatures;

namespace HighSchool.Contracts
{
    public interface IGradeRepository
    {
        Task<PagedList<GradeMV>> GetGradesAsync(RequestParameters requestParameters, bool trackChanges);
        Task<GradeMV> GetGradeByIdAsync( int gradeId, bool trackChanges);
        void CreateGradeAsync(Guid staffId, Grade grade);
        void MoveToTrash(Grade grade);
        void UpdateGradeAsync(Grade grade);
    }
}


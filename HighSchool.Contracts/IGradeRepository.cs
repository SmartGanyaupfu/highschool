using System;
using HighSchool.Entities.Models;
using HighSchool.Shared.RequestFeatures;

namespace HighSchool.Contracts
{
    public interface IGradeRepository
    {
        Task<PagedList<StudentClass>> GetGradesAsync(RequestParameters requestParameters, bool trackChanges);
        Task<StudentClass> GetGradeByIdAsync( int gradeId, bool trackChanges);
        void CreateGradeAsync( StudentClass grade);
        void MoveToTrash(StudentClass grade);
        void UpdateGradeAsync(StudentClass grade);
    }
}


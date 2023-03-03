using System;
using HighSchool.Entities.Models;
using HighSchool.Shared.RequestFeatures;

namespace HighSchool.Contracts
{
    public interface IGraduateRepository
    {
        Task<PagedList<GraduateMV>> GetGraduatesAsync(RequestParameters requestParameters, bool trackChanges);
        Task<GraduateMV> GetGraduateByIdAsync(int graduateId, bool trackChanges);
        void CreateGraduateAsync( Graduate graduate);
        void MoveToTrash(Graduate graduate);
        void UpdateGradeAsync(Graduate graduate);
    }
}


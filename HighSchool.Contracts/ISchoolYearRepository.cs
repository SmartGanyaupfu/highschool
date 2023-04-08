using System;
using HighSchool.Entities.Models;
using HighSchool.Shared.RequestFeatures;

namespace HighSchool.Contracts
{
    public interface ISchoolYearRepository
    {
        Task<PagedList<SchoolYear>> GetAllSchoolYearsAsync(RequestParameters requestParameters, bool trackChanges);
        Task<PagedList<SchoolYear>> GetAllDraftSchoolYearsAsync(RequestParameters requestParameters, bool trackChanges);
        Task<PagedList<SchoolYear>> GetAllPublishedSchoolYearsAsync(RequestParameters requestParameters, bool trackChanges);
        Task<SchoolYear> GetSchoolYearByIdAsync(int schoolYearId, bool trackChanges);
        void CreateAsync(SchoolYear schoolYear);
        void MoveToTrash(SchoolYear schoolYear);
        void SetToDraft(SchoolYear schoolYear);
        void Publish(SchoolYear schoolYear);
        void UpdateAsync(SchoolYear schoolYear);
        void PermanentDelete(SchoolYear schoolYear);
    }
}


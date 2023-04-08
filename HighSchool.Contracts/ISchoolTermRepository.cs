using System;
using HighSchool.Entities.Models;
using HighSchool.Shared.RequestFeatures;

namespace HighSchool.Contracts
{
    public interface ISchoolTermRepository
    {
        Task<IEnumerable<SchoolTerm>> GetAllSchoolTermsAsync( bool trackChanges);
        Task<IEnumerable<SchoolTerm>> GetAllDraftSchoolTermsAsync(bool trackChanges);
        Task<IEnumerable<SchoolTerm>> GetAllPublishedSchoolTermsAsync(bool trackChanges);
        Task<SchoolTerm> GetSchoolTermByIdAsync(int schoolTermId, bool trackChanges);
        void CreateAsync(SchoolTerm schoolTerm);
        void MoveToTrash(SchoolTerm schoolTerm);
        void SetToDraft(SchoolTerm schoolTerm);
        void Publish(SchoolTerm schoolTerm);
        void UpdateAsync(SchoolTerm schoolTerm);
        void PermanentDelete(SchoolTerm schoolTerm);
    }
}


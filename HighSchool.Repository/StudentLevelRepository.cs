using System;
using HighSchool.Contracts;
using HighSchool.Entities.Models;
using HighSchool.Shared.RequestFeatures;
using Microsoft.EntityFrameworkCore;

namespace HighSchool.Repository
{
    public class StudentLevelRepository : GenericRepositoryBase<StudentLevel>, IStudentLevelRepository
    {
        public StudentLevelRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }

        public void CreateStudentLevelAsync(StudentLevel studentLevel)
        {
            studentLevel.Published = false;
            studentLevel.DateCreated = DateTime.Now;
            studentLevel.DateUpdated = DateTime.Now;
            studentLevel.Deleted = false;

            Create(studentLevel);

        }

        public async Task<IEnumerable<StudentLevel>> GetAllDraftStudentLevelsAsync(bool trackChanges)
        {
            return await FindByCondition(l => l.Published.Equals(false), trackChanges).ToListAsync();
        }

        public async Task<IEnumerable<StudentLevel>> GetAllPublishedStudentLevelsAsync(bool trackChanges)
        {
            return await FindByCondition(l => l.Published.Equals(true) && l.Deleted.Equals(false), trackChanges).ToListAsync();
        }

        public async Task<IEnumerable<StudentLevel>> GetAllStudentLevelsAsync( bool trackChanges)
        {
            return await FindAll(trackChanges).ToListAsync();
        }

        public async Task<StudentLevel> GetStudentLevelByIdAsync(int studentLevelId, bool trackChanges)
        {
            return await FindByCondition(l => l.StudentLevelId.Equals(studentLevelId), trackChanges).SingleOrDefaultAsync();
        }

        public void MoveToTrash(StudentLevel studentLevel)
        {
            studentLevel.Deleted = true;
            studentLevel.DateUpdated = DateTime.Now;
            Update(studentLevel);
        }

        public void PermanentDelete(StudentLevel studentLevel)
        {
            Delete(studentLevel);
        }

        public void Publish(StudentLevel studentLevel)
        {
            studentLevel.Published = true;
            studentLevel.DatePublished = DateTime.Now;
            studentLevel.DateUpdated = DateTime.Now;
            studentLevel.Deleted = false;
            Update(studentLevel);
        }

        public void SetToDraft(StudentLevel studentLevel)
        {
            studentLevel.Published = false;
            studentLevel.Deleted = false;
            Update(studentLevel);
        }

        public void UpdateAsync(StudentLevel studentLevel)
        {
            Update(studentLevel);
        }
    }
}


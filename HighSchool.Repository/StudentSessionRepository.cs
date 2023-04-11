using System;
using HighSchool.Contracts;
using HighSchool.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace HighSchool.Repository
{
    public class StudentSessionRepository : GenericRepositoryBase<StudentSession>, IStudentSessionRepository
    {

        public StudentSessionRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateStudentSessionAsync(StudentSession studentSession)
        {
            studentSession.Published = false;
            studentSession.DateCreated = DateTime.Now;
            studentSession.Deleted = false;
            studentSession.DateUpdated = DateTime.Now;
            Create(studentSession);
        }

        public async Task<IEnumerable<StudentSession>> GetAllDraftStudentSessionsAsync(bool trackChanges)
        {
           return await FindByCondition(l => l.Published.Equals(false), trackChanges).ToListAsync();
        }

        public async Task<IEnumerable<StudentSession>> GetAllPublishedStudentSessionsAsync(bool trackChanges)
        {
          return await FindByCondition(l => l.Published.Equals(true), trackChanges).ToListAsync();
        }

        public async Task<IEnumerable<StudentSession>> GetAllStudentSessionsAsync(bool trackChanges)
        {
            return await FindAll( trackChanges).ToListAsync();
        }

        public async Task<StudentSession> GetStudentSessionByIdAsync(int studentSessionId, bool trackChanges)
        {
            return await FindByCondition(l => l.StudentSessionId.Equals(studentSessionId), trackChanges).SingleOrDefaultAsync();
        }

        public void MoveToTrash(StudentSession studentSession)
        {
            studentSession.Deleted = true;
            studentSession.DateUpdated = DateTime.Now;
            Update(studentSession);
        }

        public void PermanentDelete(StudentSession studentSession)
        {
            Delete(studentSession);
        }

        public void Publish(StudentSession studentSession)
        {
            studentSession.Deleted = false;
            studentSession.DateUpdated = DateTime.Now;
            studentSession.DatePublished = DateTime.Now;
            studentSession.Published = true;
            Update(studentSession);
        }

        public void SetToDraft(StudentSession studentSession)
        {
            studentSession.Deleted = false;
            studentSession.DateUpdated = DateTime.Now;
            studentSession.Published = false;
            Update(studentSession);
        }

        public void UpdateAsync(StudentSession studentSession)
        {
            Update(studentSession);
        }
    }
}


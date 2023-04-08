using System;
using HighSchool.Contracts;
using HighSchool.Entities.Models;
using HighSchool.Shared.RequestFeatures;
using Microsoft.EntityFrameworkCore;

namespace HighSchool.Repository
{
    public class StudentClassRepository : GenericRepositoryBase<StudentClass>, IStudentClassRepository
    {
       
        public StudentClassRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateStudentClassAsync(int levelId, StudentClass studentClass)
        {
            studentClass.Published = false;
            studentClass.Deleted = false;
            studentClass.DateCreated = DateTime.Now;
            studentClass.DateUpdated = DateTime.Now;
        }

        public async Task<IEnumerable<StudentClass>> GetAllDraftStudentClassesAsync(bool trackChanges)
        {
            return await FindByCondition(s=>s.Published.Equals(false), trackChanges).ToListAsync();
        }

        public async Task<IEnumerable<StudentClass>> GetAllPublishedStudentClassesAsync(bool trackChanges)
        {
            return await FindByCondition(l => l.Published.Equals(true) && l.Deleted.Equals(false), trackChanges).ToListAsync();
        }

        public async Task<IEnumerable<StudentClass>> GetAllStudentClassesAsync( bool trackChanges)
        {
            return await FindAll(trackChanges).ToListAsync();
        }

        

        public async Task<StudentClass> GetStudentClassByIdAsync(int studentClassId, bool trackChanges)
        {
            return await FindByCondition(l => l.StudentClassId.Equals(studentClassId), trackChanges).SingleOrDefaultAsync();
        }

        public void MoveToTrash(StudentClass studentClass)
        {
            studentClass.Deleted = true;
            studentClass.DateUpdated = DateTime.Now;
            Update(studentClass);
        }

        public void Publish(StudentClass studentClass)
        {
            studentClass.Deleted = false;
            studentClass.DatePublished = DateTime.Now;
            studentClass.Published = true;
            studentClass.DateUpdated = DateTime.Now;
            Update(studentClass);
        }

        public void SetToDraft(StudentClass studentClass)
        {
            studentClass.Deleted = false;
            studentClass.Published = false;
            studentClass.DateUpdated = DateTime.Now;
            Update(studentClass);
        }

        public void UpdateAsync(StudentClass studentClass)
        {
            Update(studentClass);
        }
    }
}


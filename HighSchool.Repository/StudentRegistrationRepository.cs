using System;
using HighSchool.Contracts;
using HighSchool.Entities.Models;
using HighSchool.Shared.RequestFeatures;
using Microsoft.EntityFrameworkCore;

namespace HighSchool.Repository
{
    public class StudentRegistrationRepository : GenericRepositoryBase<StudentRegistration>, IStudentRegistrationRepository
    {

        public StudentRegistrationRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateStudentRegistrationAsync( StudentRegistration studentRegistration)
        {
            studentRegistration.Published = false;
            studentRegistration.DateCreated = DateTime.Now;
            studentRegistration.Deleted = false;
            studentRegistration.DateUpdated = DateTime.Now;
           
            Create(studentRegistration);
        }

        public async Task<PagedList<StudentRegistration>> GetAllDraftStudentRegistrationsByYearAsync(int schoolYearId, RequestParameters requestParameters, bool trackChanges)
        {
            var registeredStudents = await FindByCondition(l => l.Published.Equals(false) && l.SchoolYearId.Equals(schoolYearId), trackChanges).
               Include(s => s.SchoolYear).Include(s => s.Student).Include(c => c.StudentClass).ToListAsync();
            return PagedList<StudentRegistration>.ToPagedList(registeredStudents, requestParameters.PageNumber, requestParameters.PageSize);
        }

        public async Task<PagedList<StudentRegistration>> GetAllStudentRegistrationsByYearAndClassAsync(int schoolYearId, int studentClassId, RequestParameters requestParameters, bool trackChanges)
        {
            var registeredStudents = await FindByCondition(l => l.Published.Equals(true) && l.SchoolYearId.Equals(schoolYearId) && l.StudentClassId.Equals(studentClassId), trackChanges).
                Include(s => s.SchoolYear).Include(s=>s.Student).Include(c=>c.StudentClass).ToListAsync();
            return PagedList<StudentRegistration>.ToPagedList(registeredStudents, requestParameters.PageNumber, requestParameters.PageSize);
        }

        public async Task<PagedList<StudentRegistration>> GetAllStudentRegistrationsByYearAndLevelAsync(int schoolYearId, int studentLevelId, RequestParameters requestParameters, bool trackChanges)
        {
            var registeredStudents = await FindByCondition(l => l.Published.Equals(true) && l.SchoolYearId.Equals(schoolYearId) && l.StudentLevelId.Equals(studentLevelId), trackChanges).
                Include(s => s.SchoolYear).Include(s => s.Student).Include(c => c.StudentClass).ToListAsync();
            return PagedList<StudentRegistration>.ToPagedList(registeredStudents, requestParameters.PageNumber, requestParameters.PageSize);
        }

        public async Task<PagedList<StudentRegistration>> GetAllStudentRegistrationsByYearAsync(int schoolYearId, RequestParameters requestParameters, bool trackChanges)
        {
            var registeredStudents = await FindByCondition(l => l.Published.Equals(true) && l.SchoolYearId.Equals(schoolYearId) , trackChanges).
               Include(s => s.SchoolYear).Include(s => s.Student).Include(c => c.StudentClass).ToListAsync();
            return PagedList<StudentRegistration>.ToPagedList(registeredStudents, requestParameters.PageNumber, requestParameters.PageSize);
        }

        public async Task<StudentRegistration> GetStudentRegistrationByIdAsync(int studentRegistrationId, bool trackChanges)
        {
            return await FindByCondition(l => l.StudentRegistrationId.Equals(studentRegistrationId), trackChanges).
               Include(s => s.SchoolYear).Include(s => s.Student).Include(c => c.StudentClass).Include(t=>t.SchoolTerm).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable< StudentRegistration>> GetStudentRegistrationByStudentIdAsync(int schoolYearId, Guid studentId, bool trackChanges)
        {
           return await FindByCondition(l => l.StudentId.Equals(studentId) && l.SchoolYearId.Equals(schoolYearId), trackChanges).
               Include(s => s.SchoolYear).Include(s => s.Student).Include(c => c.StudentClass).Include(t => t.SchoolTerm).ToListAsync();
        }

        public void MoveToTrash(StudentRegistration studentRegistration)
        {
            studentRegistration.Deleted = true;
            studentRegistration.DateUpdated = DateTime.Now;
            Update(studentRegistration);
        }

        public void PermanentDelete(StudentRegistration studentRegistration)
        {
            Delete(studentRegistration);
        }

        public void Publish(StudentRegistration studentRegistration)
        {
            studentRegistration.Deleted = false;
            studentRegistration.DateUpdated = DateTime.Now;
            studentRegistration.DatePublished = DateTime.Now;
           studentRegistration.Published = true;
            Update(studentRegistration);
        }

        public void SetToDraft(StudentRegistration studentRegistration)
        {
            studentRegistration.Deleted = false;
            studentRegistration.DateUpdated = DateTime.Now;
            studentRegistration.Published = false;
            Update(studentRegistration);
        }

        public void UpdateAsync(StudentRegistration studentRegistration)
        {
            Update(studentRegistration);
        }
    }
}


using System;
using System.Diagnostics;
using HighSchool.Contracts;
using HighSchool.Entities.Models;
using HighSchool.Shared.RequestFeatures;
using Microsoft.EntityFrameworkCore;

namespace HighSchool.Repository
{
    [DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
    public class StudentRepository : GenericRepositoryBase<Student>, IStudentRepository

    {
        public StudentRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }

        public void CreateStudentAsync(Student student)
            
        {
            student.Published = true;
            
            student.DatePublished = DateTime.Now;
            Create(student);
        }

        public async Task<PagedList<Student>> GetAllStudentsAsync(RequestParameters requestParameters, bool trackChanges)
        {
           // var students = await FindByCondition(s => s.Deleted.Equals(false), trackChanges).OrderByDescending(p => p.DateCreated).ToListAsync();

            var students = await FindAll(trackChanges)
            .OrderByDescending(s => s.DateCreated).ToListAsync();

            return PagedList<Student>.ToPagedList(students, requestParameters.PageNumber, requestParameters.PageSize);
        }

        public async Task<Student> GetStudentByIdAsync(Guid studentId, bool trackChanges)
        {
            return await FindByCondition(p => p.StudentId.Equals(studentId) && p.Deleted == false, trackChanges).Include(n=>n.NextOfKin).Include(n=>n.Notes)

            .OrderByDescending(s => s.DateCreated)
            .SingleOrDefaultAsync();
        }

        public async Task<Student> GetStudentBySlugAsync(string slug, bool trackChanges)
        {
            throw new NotImplementedException();
        }

        public async Task<Student> GetStudentRegistrationNumberAsync(string studentRegNumber, bool trackChanges)
        {
            return await FindByCondition(p => p.NationalIdentityNumber.Equals(studentRegNumber) && p.Deleted == false, trackChanges)

            .OrderByDescending(s => s.DateCreated).SingleOrDefaultAsync();
        }

        public void MoveToTrash(Student student)
        {

            student.Deleted = true;
            student.DateUpdated = DateTime.Now;
            student.Published = false;
            Update(student);
        }

        public void Publish(Student student)
        {
            student.DateUpdated = DateTime.Now;
            student.DatePublished = DateTime.Now;
            student.Published = true;
            Update(student);
        }

        public void SetToDraft(Student student)
        {
            student.DateUpdated = DateTime.Now;
            student.Published = false;
            Update(student);
        }

        public void UpdateStudentAsync(Student student)
        {
            Update(student);
        }

        private string GetDebuggerDisplay()
        {
            return ToString();
        }
    }
}


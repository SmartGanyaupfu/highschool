using System;
using HighSchool.Contracts;
using HighSchool.Entities.Models;
using HighSchool.Shared.RequestFeatures;
using Microsoft.EntityFrameworkCore;

namespace HighSchool.Repository
{
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
            var students = await FindByCondition(s => s.Deleted.Equals(false), trackChanges).OrderByDescending(p => p.DateCreated).ToListAsync();

            return PagedList<Student>.ToPagedList(students, requestParameters.PageNumber, requestParameters.PageSize);
        }

        public async Task<Student> GetStudentByIdAsync(Guid studentId, bool trackChanges)
        {
            return await FindByCondition(p => p.StudentId.Equals(studentId) && p.Deleted == false, trackChanges).SingleOrDefaultAsync();
        }

        public async Task<Student> GetStudentBySlugAsync(string slug, bool trackChanges)
        {
            throw new NotImplementedException();
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
            student.Published = true;
            Update(student);
        }

        public void UpdateStudentAsync(Student student)
        {
            Update(student);
        }
    }
}


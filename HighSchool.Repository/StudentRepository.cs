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

        public async Task<PagedList<StudentMV>> GetAllStudentsAsync(RequestParameters requestParameters, bool trackChanges)
        {
           // var students = await FindByCondition(s => s.Deleted.Equals(false), trackChanges).OrderByDescending(p => p.DateCreated).ToListAsync();

            var students = await FindAll(trackChanges)
            .OrderByDescending(s => s.DateCreated).Select(s => new StudentMV()
            {
                Student = s,
                Grades = s.StudentGrades.Select(g => g.Grade).ToList(),
                Graduations=s.StudentGraduates.Select(g=>g.Graduate).ToList()
            }).ToListAsync();

            return PagedList<StudentMV>.ToPagedList(students, requestParameters.PageNumber, requestParameters.PageSize);
        }

        public async Task<StudentMV> GetStudentByIdAsync(Guid studentId, bool trackChanges)
        {
            return await FindByCondition(p => p.StudentId.Equals(studentId) && p.Deleted == false, trackChanges).Include(n=>n.NextOfKin).Include(n=>n.Notes)

            .OrderByDescending(s => s.DateCreated).Select(s => new StudentMV()
            {
                Student = s,
                Grades = s.StudentGrades.Select(g => g.Grade).ToList(),
                Graduations = s.StudentGraduates.Select(g => g.Graduate).ToList()
            })
            .SingleOrDefaultAsync();
        }

        public async Task<StudentMV> GetStudentBySlugAsync(string slug, bool trackChanges)
        {
            throw new NotImplementedException();
        }

        public async Task<StudentMV> GetStudentNationalIdAsync(string nationalId, bool trackChanges)
        {
            return await FindByCondition(p => p.NationalIdentityNumber.Equals(nationalId) && p.Deleted == false, trackChanges)

            .OrderByDescending(s => s.DateCreated).Select(s => new StudentMV()
            {
                Student = s,
                Grades = s.StudentGrades.Select(g => g.Grade).ToList(),
                Graduations = s.StudentGraduates.Select(g => g.Graduate).ToList()
            }).SingleOrDefaultAsync();
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


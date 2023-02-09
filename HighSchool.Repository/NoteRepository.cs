using System;
using HighSchool.Contracts;
using HighSchool.Entities.Models;
using HighSchool.Shared.RequestFeatures;
using Microsoft.EntityFrameworkCore;

namespace HighSchool.Repository
{
    public class NoteRepository : GenericRepositoryBase<Note>, INoteRepository
    {
        public NoteRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }

        public void CreateNoteAsync(Guid studentId, Note note)
        {
            note.StudentId = studentId;
            Create(note);
        }

        public async Task<Note> GetNoteByIdAsync(Guid studentId, int noteId, bool trackChanges)
        {
            return await FindByCondition(n => n.StudentId.Equals(studentId) && n.Deleted.Equals(false), trackChanges).FirstOrDefaultAsync();
        }

        public async Task<PagedList<Note>> GetNotesForStudentAsync(Guid studentId, RequestParameters requestParameters, bool trackChanges)
        {
            var notes = await FindByCondition(n => n.StudentId.Equals(studentId) && n.Deleted.Equals(false), trackChanges).OrderByDescending(n=>n.DateCreated).ToListAsync();
            return PagedList<Note>.ToPagedList(notes, requestParameters.PageNumber, requestParameters.PageSize);
        }

        public void MoveToTrash(Note note)
        {
            note.Deleted = true;
            Update(note);
        }

        public void PermanentDelete(Note note)
        {
            Delete(note);
        }

        public void UpdateNoteAsync(Note note)
        {
            Update(note);
        }
    }
}


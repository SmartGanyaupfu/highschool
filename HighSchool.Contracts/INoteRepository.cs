using System;
using HighSchool.Entities.Models;
using HighSchool.Shared.RequestFeatures;

namespace HighSchool.Contracts
{
    public interface INoteRepository
    {
        Task<PagedList<Note>> GetNotesForStudentAsync(Guid studentId, RequestParameters requestParameters, bool trackChanges);
        Task<Note> GetNoteByIdAsync(Guid studentId, int noteId, bool trackChanges);
        void CreateNoteAsync(Guid studentId, Note note);
        void MoveToTrash(Note note);
        void UpdateNoteAsync(Note note);
        void PermanentDelete(Note note);

    }
}


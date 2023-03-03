using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using HighSchool.API.ActionFilters;
using HighSchool.Contracts;
using HighSchool.Entities.Models;
using HighSchool.Shared.DTOs;
using HighSchool.Shared.RequestFeatures;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HighSchool.API.Controllers.API
{
    [Route("api/student/{studentId}/notes")]
    public class NotesController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        // private readonly IImageUploader _imageService;

        public NotesController(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        // GET: api/values
        [HttpGet]
        public async Task<IActionResult> GetNotes(Guid studentId, RequestParameters requestParameters)
        {

            var notes = await _repository.Note.GetNotesForStudentAsync(studentId,requestParameters, trackChanges: false);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(notes.MetaData));
            var notesToReturn = _mapper.Map<IEnumerable<NoteDto>>(notes);


            return Ok(notesToReturn);
        }

        // GET api/values/5
        [HttpGet("{noteId}", Name = "notesId")]
        public async Task<IActionResult> GetNoteById(Guid studentId, int noteId)
        {
            var resource = await _repository.Note.GetNoteByIdAsync(studentId, noteId, trackChanges: false);
            if (resource is null)
                return NotFound();
            var resourceToReturn = _mapper.Map<AllocatedResourceDto>(resource);


            return Ok(resourceToReturn);
        }




        //* [Authorize]
        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateNote(Guid studentId, [FromBody] NoteForCreationDto noteForCreation)
        {
            var student = await _repository.Student.GetStudentByIdAsync(studentId, trackChanges: false);
            if (student is null)
                return NotFound();


            var noteEntity = _mapper.Map<Note>(noteForCreation);
            _repository.Note.CreateNoteAsync(studentId, noteEntity);
            await _repository.SaveAsync();
            var noteToReturn = _mapper.Map<NoteDto>(noteEntity);


            return CreatedAtRoute("notesId", new { studentId = studentId, noteId = noteEntity.NoteId }, noteToReturn);
        }

        //[Authorize]
        [HttpPut("{noteId}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateNoteById(Guid studentId, int noteId, [FromBody] NoteForUpdateDto noteForUpdate)
        {
          

            var noteEntity = await _repository.Note.GetNoteByIdAsync(studentId, noteId, trackChanges: true);
            if (noteEntity is null)
                return NotFound($"Note with id {noteId} does not exist");



            _mapper.Map(noteForUpdate, noteEntity);

            await _repository.SaveAsync();
            return NoContent();
        }
        //[Authorize]
        // Page is set to delete only
        [HttpDelete("{noteId}")]
        public async Task<IActionResult> DeleteValue(Guid studentId, int noteId)
        {


            var noteEntity = await _repository.Note.GetNoteByIdAsync(studentId, noteId, trackChanges: false);
            if (noteEntity is null)
                return NotFound($"Resource with id {noteId} does not exist");


            _repository.Note.MoveToTrash(noteEntity);

            await _repository.SaveAsync();

            return NoContent();
        }
    }
}


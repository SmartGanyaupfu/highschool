using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HighSchool.API.ActionFilters;
using HighSchool.API.Extensions;
using HighSchool.Contracts;
using HighSchool.Entities.Models;
using HighSchool.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HighSchool.API.Controllers.API.settings
{
    [Route("api/student-sessions")]
    public class StudentSessionsController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        // private readonly IImageUploader _imageService;

        public StudentSessionsController(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        // GET: api/student-sessions
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            var sessions = await _repository.StudentSession.GetAllStudentSessionsAsync(trackChanges: false);


            return Ok(sessions);
        }
        // GET: api/student-sessions/published
        [HttpGet("published")]
        public async Task<IActionResult> GetAllPublished()
        {


            var sessions = await _repository.StudentSession.GetAllPublishedStudentSessionsAsync(trackChanges: false);


            return Ok(sessions);
        }
        // GET: api/student-sessions/draft
        [HttpGet("draft")]
        public async Task<IActionResult> GetAllDraft()
        {


            var sessions = await _repository.StudentSession.GetAllDraftStudentSessionsAsync(trackChanges: false);


            return Ok(sessions);
        }

        //  api/school-levels/1
        [HttpGet("{studentSessionId}", Name = "studentSessionIdRoute")]
        public async Task<IActionResult> GetById(int studentSessionId)
        {
            var studentSession = await _repository.StudentSession.GetStudentSessionByIdAsync(studentSessionId, trackChanges: false);
            if (studentSession is null)
                return NotFound();

            var sessionToReturn = _mapper.Map<StudentSessionDto>(studentSession);
            return Ok(sessionToReturn);
        }




        //* [Authorize]
        [HttpPost()]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Create([FromBody] StudentSessionForCreationDto studentSessionForCreation)
        {

            studentSessionForCreation.AuthorId = User.GetUserId();

            var sessionEntity = _mapper.Map<StudentSession>(studentSessionForCreation);
            _repository.StudentSession.CreateStudentSessionAsync(sessionEntity);
            await _repository.SaveAsync();
            var sessionToReturn = _mapper.Map<StudentSessionDto>(sessionEntity);


            return CreatedAtRoute("studentSessionIdRoute", new { studentSessionId = sessionEntity.StudentSessionId }, sessionToReturn);

            // return Ok(blockEntity);
        }

        //[Authorize]
        [HttpPut("{studentSessionId}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Update(int studentSessionId, [FromBody] StudentSessionForUpdateDto studentSessionForUpdate)
        {

            studentSessionForUpdate.AuthorId = User.GetUserId();
            studentSessionForUpdate.DateUpdated = DateTime.Now;
            var sessionEntity = await _repository.StudentSession.GetStudentSessionByIdAsync(studentSessionId, trackChanges: true);
            if (sessionEntity is null)
                return NotFound($"Session with id {studentSessionId} does not exist");



            _mapper.Map(studentSessionForUpdate, sessionEntity);

            await _repository.SaveAsync();
            return NoContent();
        }
        //[Authorize]
        // Page is set to delete only
        [HttpPut("delete/{studentSessionId}")]
        public async Task<IActionResult> MoveToBin(int studentSessionId)
        {


            var sessionEntity = await _repository.StudentSession.GetStudentSessionByIdAsync(studentSessionId, trackChanges: true);
            if (sessionEntity is null)
                return NotFound($"Session with id {studentSessionId} does not exist");
            sessionEntity.AuthorId = User.GetUserId();

            _repository.StudentSession.MoveToTrash(sessionEntity);

            await _repository.SaveAsync();

            return NoContent();
        }

        [HttpPut("set-draft/{studentSessionId}")]
        public async Task<IActionResult> MoveToDraft(int studentSessionId)
        {

            var sessionEntity = await _repository.StudentSession.GetStudentSessionByIdAsync(studentSessionId, trackChanges: true);
            if (sessionEntity is null)
                return NotFound($"Session with id {studentSessionId} does not exist");
            sessionEntity.AuthorId = User.GetUserId();

            _repository.StudentSession.MoveToTrash(sessionEntity);

            await _repository.SaveAsync();

            return NoContent();
        }

        [HttpPut("publish/{studentSessionId}")]
        public async Task<IActionResult> Publish(int studentSessionId)
        {

            var sessionEntity = await _repository.StudentSession.GetStudentSessionByIdAsync(studentSessionId, trackChanges: true);
            if (sessionEntity is null)
                return NotFound($"Session with id {studentSessionId} does not exist");
            sessionEntity.AuthorId = User.GetUserId();

            _repository.StudentSession.Publish(sessionEntity);

            await _repository.SaveAsync();

            return NoContent();
        }

        [HttpPut("perm-delete/{studentSessionId}")]
        public async Task<IActionResult> PermDelete(int studentSessionId)
        {

            var sessionEntity = await _repository.StudentSession.GetStudentSessionByIdAsync(studentSessionId, trackChanges: true);
            if (sessionEntity is null)
                return NotFound($"Session with id {studentSessionId} does not exist");

            _repository.StudentSession.PermanentDelete(sessionEntity);

            await _repository.SaveAsync();

            return NoContent();
        }
    }
}


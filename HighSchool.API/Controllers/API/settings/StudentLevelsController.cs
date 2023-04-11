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
    [Route("api/student-levels")]
    public class StudentLevelsController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        // private readonly IImageUploader _imageService;

        public StudentLevelsController(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        // GET: api/student-levels
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            var levels = await _repository.StudentLevel.GetAllStudentLevelsAsync(trackChanges: false);


            return Ok(levels);
        }
        // GET: api/student-levels/published
        [HttpGet("published")]
        public async Task<IActionResult> GetAllPublished()
        {

            var levels = await _repository.StudentLevel.GetAllPublishedStudentLevelsAsync(trackChanges: false);


            return Ok(levels);
        }
        // GET: api/student-levels/draft
        [HttpGet("draft")]
        public async Task<IActionResult> GetAllDraft()
        {

            var levels = await _repository.StudentLevel.GetAllDraftStudentLevelsAsync(trackChanges: false);


            return Ok(levels);
        }

        //  api/school-levels/1
        [HttpGet("{studentLevelId}", Name = "studentLevelIdRoute")]
        public async Task<IActionResult> GetById(int studentLevelId)
        {
            var studentLevel = await _repository.StudentLevel.GetStudentLevelByIdAsync(studentLevelId, trackChanges: false);
            if (studentLevel is null)
                return NotFound();


            return Ok(studentLevel);
        }




        //* [Authorize]
        [HttpPost()]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Create( [FromBody] StudentLevelForCreationDto studentLevelForCreation)
        {

            studentLevelForCreation.AuthorId = User.GetUserId();

            var levelEntity = _mapper.Map<StudentLevel>(studentLevelForCreation);
            _repository.StudentLevel.CreateStudentLevelAsync(levelEntity);
            await _repository.SaveAsync();
            var levelToReturn = _mapper.Map<StudentLevelDto>(levelEntity);


            return CreatedAtRoute("studentLevelIdRoute", new { studentLevelId = levelEntity.StudentLevelId }, levelToReturn);

            // return Ok(blockEntity);
        }

        //[Authorize]
        [HttpPut("{studentLevelId}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Update(int studentLevelId, [FromBody] StudentLevelForUpdateDto studentLevelForUpdate)
        {

            studentLevelForUpdate.AuthorId = User.GetUserId();
            studentLevelForUpdate.DateUpdated = DateTime.Now;
            var levelEntity = await _repository.StudentLevel.GetStudentLevelByIdAsync(studentLevelId, trackChanges: true);
            if (levelEntity is null)
                return NotFound($"Level with id {studentLevelId} does not exist");



            _mapper.Map(studentLevelForUpdate, levelEntity);

            await _repository.SaveAsync();
            return NoContent();
        }
        //[Authorize]
        // Page is set to delete only
        [HttpPut("delete/{studentLevelId}")]
        public async Task<IActionResult> MoveToBin(int studentLevelId)
        {


            var levelEntity = await _repository.StudentLevel.GetStudentLevelByIdAsync(studentLevelId, trackChanges: true);
            if (levelEntity is null)
                return NotFound($"Level with id {studentLevelId} does not exist");
            levelEntity.AuthorId = User.GetUserId();

            _repository.StudentLevel.MoveToTrash(levelEntity);

            await _repository.SaveAsync();

            return NoContent();
        }

        [HttpPut("set-draft/{studentLevelId}")]
        public async Task<IActionResult> MoveToDraft(int studentLevelId)
        {

            var levelEntity = await _repository.StudentLevel.GetStudentLevelByIdAsync(studentLevelId, trackChanges: true);
            if (levelEntity is null)
                return NotFound($"Level with id {studentLevelId} does not exist");
            levelEntity.AuthorId = User.GetUserId();

            _repository.StudentLevel.SetToDraft(levelEntity);

            await _repository.SaveAsync();

            return NoContent();
        }

        [HttpPut("publish/{studentLevelId}")]
        public async Task<IActionResult> Publish(int studentLevelId)
        {

            var levelEntity = await _repository.StudentLevel.GetStudentLevelByIdAsync(studentLevelId, trackChanges: true);
            if (levelEntity is null)
                return NotFound($"Level with id {studentLevelId} does not exist");
            levelEntity.AuthorId = User.GetUserId();

            _repository.StudentLevel.Publish(levelEntity);

            await _repository.SaveAsync();

            return NoContent();
        }

        [HttpPut("perm-delete/{studentLevelId}")]
        public async Task<IActionResult> PermDelete(int studentLevelId)
        {

            var levelEntity = await _repository.StudentLevel.GetStudentLevelByIdAsync(studentLevelId, trackChanges: true);
            if (levelEntity is null)
                return NotFound($"Level with id {studentLevelId} does not exist");

            _repository.StudentLevel.PermanentDelete(levelEntity);

            await _repository.SaveAsync();

            return NoContent();
        }
    }
}


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
    [Route("api/student-classes")]
    public class StudentClassesController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        // private readonly IImageUploader _imageService;

        public StudentClassesController(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        // GET: api/student-classes
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            var classes = await _repository.StudentClass.GetAllStudentClassesAsync(trackChanges: false);


            return Ok(classes);
        }
        // GET: api/student-classes/published
        [HttpGet("published")]
        public async Task<IActionResult> GetAllPublished()
        {

            var classes = await _repository.StudentClass.GetAllPublishedStudentClassesAsync(trackChanges: false);


            return Ok(classes);
        }
        // GET: api/student-classes/draft
        [HttpGet("draft")]
        public async Task<IActionResult> GetAllDraft()
        {

            var classes = await _repository.StudentClass.GetAllDraftStudentClassesAsync(trackChanges: false);


            return Ok(classes);
        }

        //  api/student-classes/1
        [HttpGet("{studentClassId}", Name = "studentClassIdRoute")]
        public async Task<IActionResult> GetById(int studentClassId)
        {
            var studentClass = await _repository.StudentClass.GetStudentClassByIdAsync(studentClassId, trackChanges: false);
            if (studentClass is null)
                return NotFound();


            return Ok(studentClass);
        }




        //* [Authorize]
        [HttpPost("{studentLevelId}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Create(int studentLevelId,[FromBody] StudentClassForCreationDto studentClassForCreation)
        {

            studentClassForCreation.AuthorId = User.GetUserId();

            var classEntity = _mapper.Map<StudentClass>(studentClassForCreation);
            _repository.StudentClass.CreateStudentClassAsync(studentLevelId,classEntity);
            await _repository.SaveAsync();
            var classToReturn = _mapper.Map<StudentClassDto>(classEntity);


            return CreatedAtRoute("studentClassIdRoute", new { studentClassId = classEntity.StudentClassId }, classToReturn);

            // return Ok(blockEntity);
        }

        //[Authorize]
        [HttpPut("{studentClassId}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Update(int studentClassId, [FromBody] StudentClassForUpdateDto studentClassForUpdate)
        {

            studentClassForUpdate.AuthorId = User.GetUserId();
            studentClassForUpdate.DateUpdated = DateTime.Now;
            var studentClassEntity = await _repository.StudentClass.GetStudentClassByIdAsync(studentClassId, trackChanges: true);
            if (studentClassEntity is null)
                return NotFound($"Class with id {studentClassId} does not exist");



            _mapper.Map(studentClassForUpdate, studentClassEntity);

            await _repository.SaveAsync();
            return NoContent();
        }
        //[Authorize]
        // Page is set to delete only
        [HttpPut("delete/{studentClassId}")]
        public async Task<IActionResult> MoveToBin(int studentClassId)
        {


            var studentClassEntity = await _repository.StudentClass.GetStudentClassByIdAsync(studentClassId, trackChanges: true);
            if (studentClassEntity is null)
                return NotFound($"Class with id {studentClassId} does not exist");
          studentClassEntity.AuthorId = User.GetUserId();

            _repository.StudentClass.MoveToTrash(studentClassEntity);

            await _repository.SaveAsync();

            return NoContent();
        }

        [HttpPut("set-draft/{studentClassId}")]
        public async Task<IActionResult> MoveToDraft(int studentClassId)
        {


            var studentClassEntity = await _repository.StudentClass.GetStudentClassByIdAsync(studentClassId, trackChanges: true);
            if (studentClassEntity is null)
                return NotFound($"Class with id {studentClassId} does not exist");
            studentClassEntity.AuthorId = User.GetUserId();

            _repository.StudentClass.SetToDraft(studentClassEntity);

            await _repository.SaveAsync();

            return NoContent();
        }

        [HttpPut("publish/{studentClassId}")]
        public async Task<IActionResult> Publish(int studentClassId)
        {


            var studentClassEntity = await _repository.StudentClass.GetStudentClassByIdAsync(studentClassId, trackChanges: true);
            if (studentClassEntity is null)
                return NotFound($"Class with id {studentClassId} does not exist");
            studentClassEntity.AuthorId = User.GetUserId();

            _repository.StudentClass.Publish(studentClassEntity);

            await _repository.SaveAsync();

            return NoContent();
        }

        [HttpPut("perm-delete/{studentClassId}")]
        public async Task<IActionResult> PermDelete(int studentClassId)
        {


            var studentClassEntity = await _repository.StudentClass.GetStudentClassByIdAsync(studentClassId, trackChanges: true);
            if (studentClassEntity is null)
                return NotFound($"Class with id {studentClassId} does not exist");
            studentClassEntity.AuthorId = User.GetUserId();

            _repository.StudentClass.MoveToTrash(studentClassEntity);

            await _repository.SaveAsync();

            return NoContent();
        }
    }
}


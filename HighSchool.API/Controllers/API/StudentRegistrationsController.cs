using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using HighSchool.API.ActionFilters;
using HighSchool.API.Extensions;
using HighSchool.Contracts;
using HighSchool.Entities.Models;
using HighSchool.Shared.DTOs;
using HighSchool.Shared.RequestFeatures;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HighSchool.API.Controllers.API
{
    [Route("api/student-registrations")]
    public class StudentRegistrationsController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        // private readonly IImageUploader _imageService;

        public StudentRegistrationsController(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        // GET: api/student-registrations
        [HttpGet("year/{schoolYearId}")]
        public async Task<IActionResult> GetAllByYear(int schoolYearId, RequestParameters requestParameters)
        {

            var studentsRegs = await _repository.StudentRegistration.GetAllStudentRegistrationsByYearAsync(schoolYearId,requestParameters,trackChanges: false);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(studentsRegs.MetaData));
            var regToReturn = _mapper.Map<IEnumerable<StudentRegistrationDto>>(studentsRegs);

            return Ok(regToReturn);
        }
        // GET: api/student-registrations
        [HttpGet("year/{schoolYearId}/level/{studentLevelId}")]
        public async Task<IActionResult> GetAllByYearAndLevel(int schoolYearId,int studentLevelId, RequestParameters requestParameters)
        {

            var studentsRegs = await _repository.StudentRegistration.GetAllStudentRegistrationsByYearAndLevelAsync(schoolYearId,studentLevelId ,requestParameters, trackChanges: false);

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(studentsRegs.MetaData));
            var regToReturn = _mapper.Map<IEnumerable<StudentRegistrationDto>>(studentsRegs);

            return Ok(regToReturn);
        }
        // GET: api/student-registrations
        [HttpGet("year/{schoolYearId}/class/{studentClassId}")]
        public async Task<IActionResult> GetAllByYearandClass(int schoolYearId, int studentClassId, RequestParameters requestParameters)
        {

            var studentsRegs = await _repository.StudentRegistration.GetAllStudentRegistrationsByYearAndClassAsync(schoolYearId, studentClassId, requestParameters, trackChanges: false);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(studentsRegs.MetaData));
            var regToReturn = _mapper.Map<IEnumerable<StudentRegistrationDto>>(studentsRegs);

            return Ok(regToReturn);
        }
        [HttpGet("draft/year/{schoolYearId}")]
        public async Task<IActionResult> GetAllDraft(int schoolYearId, RequestParameters requestParameters)
        {

            var studentsRegs = await _repository.StudentRegistration.GetAllDraftStudentRegistrationsByYearAsync(schoolYearId, requestParameters, trackChanges: false);


            return Ok(studentsRegs);
        }

      
        [HttpGet("year/{yearId}/studentId/{studentId}")]
        public async Task<IActionResult> GetByStudentId(int yearId,Guid studentId)
        {
            var studentReg = await _repository.StudentRegistration.GetStudentRegistrationByStudentIdAsync(yearId, studentId, trackChanges: false);
            if (studentReg is null)
                return NotFound();


            return Ok(studentReg);
        }

        [HttpGet("{studentRegId}", Name ="registration")]
        public async Task<IActionResult> GetByStudentRegId(int studentRegId)
        {
            var studentReg = await _repository.StudentRegistration.GetStudentRegistrationByIdAsync(studentRegId, trackChanges: false);
            if (studentReg is null)
                return NotFound();


            return Ok(studentReg);
        }




        //* [Authorize]
        [HttpPost()]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Create( [FromBody] StudentRegistrationForCreationDto studentRegForCreation)
        {

            studentRegForCreation.AuthorId = User.GetUserId();

            var regEntity = _mapper.Map<StudentRegistration>(studentRegForCreation);
            _repository.StudentRegistration.CreateStudentRegistrationAsync( regEntity);
            await _repository.SaveAsync();


            var regToReturn = _mapper.Map<StudentRegistrationDto>(regEntity);


            return CreatedAtRoute("registration", new { studentRegId = regEntity.StudentRegistrationId }, regToReturn);

            // return Ok(blockEntity);
        }

        //[Authorize]
        [HttpPut("{studentRegId}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Update(int studentRegId, [FromBody] StudentRegistrationForUpdateDto studentRegForUpdate)
        {

            studentRegForUpdate.AuthorId = User.GetUserId();
            studentRegForUpdate.DateUpdated = DateTime.Now;
            var studentRegEntity = await _repository.StudentRegistration.GetStudentRegistrationByIdAsync(studentRegId, trackChanges: true);
            if (studentRegEntity is null)
                return NotFound($"Registration with id {studentRegId} does not exist");



            _mapper.Map(studentRegForUpdate, studentRegEntity);

            await _repository.SaveAsync();
            return NoContent();
        }
        //[Authorize]
        // Page is set to delete only
        [HttpPut("delete/{studentRegId}")]
        public async Task<IActionResult> MoveToBin(int studentRegId)
        {


            var studentRegEntity = await _repository.StudentRegistration.GetStudentRegistrationByIdAsync(studentRegId, trackChanges: true);
            if (studentRegEntity is null)
                return NotFound($"Registration with id {studentRegId} does not exist");
            studentRegEntity.AuthorId = User.GetUserId();

            _repository.StudentRegistration.MoveToTrash(studentRegEntity);

            await _repository.SaveAsync();

            return NoContent();
        }

        [HttpPut("set-draft/{studentRegId}")]
        public async Task<IActionResult> MoveToDraft(int studentRegId)
        {


            var studentRegEntity = await _repository.StudentRegistration.GetStudentRegistrationByIdAsync(studentRegId, trackChanges: true);
            if (studentRegEntity is null)
                return NotFound($"Registration with id {studentRegId} does not exist");
            studentRegEntity.AuthorId = User.GetUserId();

            _repository.StudentRegistration.SetToDraft(studentRegEntity);

            await _repository.SaveAsync();

            return NoContent();
        }

        [HttpPut("publish/{studentRegId}")]
        public async Task<IActionResult> Publish(int studentRegId)
        {
            var studentRegEntity = await _repository.StudentRegistration.GetStudentRegistrationByIdAsync(studentRegId, trackChanges: true);
            if (studentRegEntity is null)
                return NotFound($"Registration with id {studentRegId} does not exist");
            studentRegEntity.AuthorId = User.GetUserId();

            _repository.StudentRegistration.Publish(studentRegEntity);

            await _repository.SaveAsync();

            return NoContent();
        }

        [HttpPut("perm-delete/{studentRegId}")]
        public async Task<IActionResult> PermDelete(int studentRegId)
        {

            var studentRegEntity = await _repository.StudentRegistration.GetStudentRegistrationByIdAsync(studentRegId, trackChanges: true);
            if (studentRegEntity is null)
                return NotFound($"Registration with id {studentRegId} does not exist");

            _repository.StudentRegistration.PermanentDelete(studentRegEntity);

            await _repository.SaveAsync();

            return NoContent();
        }
    }
}


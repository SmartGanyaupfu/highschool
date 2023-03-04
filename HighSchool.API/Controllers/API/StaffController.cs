using System;
using AutoMapper;
using HighSchool.API.ActionFilters;
using HighSchool.API.Extensions;
using HighSchool.Contracts;
using HighSchool.Entities.Models;
using HighSchool.Shared.DTOs;
using HighSchool.Shared.RequestFeatures;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Xml.Linq;

namespace HighSchool.API.Controllers.API
{
    [Route("api/staff")]
    public class StaffController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public StaffController(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        // GET: api/values
        [HttpGet]
        public async Task<IActionResult> GetTeachers([FromQuery] RequestParameters requestParameters)
        {

            var teachers = await _repository.Staff.GetAllTeachersAsync(requestParameters, trackChanges: false);
            var teachersToReturn = _mapper.Map<IEnumerable<TeacherMVDto>>(teachers);

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(teachers.MetaData));

            return Ok(teachersToReturn);
        }

        // GET api/values/5
        [HttpGet("{staffId}", Name = "staffsId")]
        public async Task<IActionResult> GetStaffById(Guid staffId)
        {
            var staff = await _repository.Staff.GetTeacherByIdAsync(staffId, trackChanges: false);
            if (staff is null)
                return NotFound();

            var staffToReturn = _mapper.Map<TeacherMVDto>(staff);
            /* Image image;
             //Gallery gallery;


             if (post.Post.FeatureImageId != null)
             {
                 image = await _repository.Image.GetImageByIdAsync((int)post.Post.FeatureImageId, trackChanges: false);
                 postToReturn.Post.Image = _mapper.Map<ImageDto>(image);
             }
            */



            return Ok(staffToReturn);
        }
    

        //[Authorize]
        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateStaff([FromBody] StaffForCreationDto staff)
        {
            var staffFromDb = await _repository.Staff.GetStaffNationalIdAsync(staff.NationalIdentityNumber, trackChanges: false);

            if (staffFromDb != null)
            {
                return BadRequest($"Student with id {staff.NationalIdentityNumber} already exists.");
            }
            Guid g = Guid.NewGuid();
            staff.Slug += "-"+g  ;
            staff.AuthorId = User.GetUserId();

            var staffEntity = _mapper.Map<Staff>(staff);
            _repository.Staff.CreateStaffAsync(staffEntity);
            await _repository.SaveAsync();
            if (staff.CourseIds != null)
            {

                var staffCourses = await _repository.StaffCourse.GetAllStaffCoursesByStaffIdAsync(staffFromDb.Staff.StaffId, trackChanges: false);

                //delete the staff courses before adding new ones

                foreach (var sc in staffCourses)
                {
                    _repository.StaffCourse.DeleteAsync(sc);
                    await _repository.SaveAsync();
                }

                //create
                foreach (var courseId in staff.CourseIds)
                {
                    var staffCourse = new StaffCourse()
                    {
                        StaffId = staffEntity.StaffId,
                        CourseId = courseId
                    };
                    _repository.StaffCourse.CreateAsync(staffCourse);
                    await _repository.SaveAsync();

                }
            }
           

            var staffEntityFromDb = await _repository.Staff.GetTeacherByIdAsync(staffEntity.StaffId, trackChanges: false);
            if (staffEntityFromDb is null)
                return NotFound("Staff created,but could not be be retrieved.");

            Image image;
            //Gallery gallery;
            var staffFromDbToReturn = _mapper.Map<TeacherMVDto>(staffEntityFromDb);

            /*if (postFromDb.Post.FeatureImageId != null)
            {
                image = await _repository.Image.GetImageByIdAsync((int)postFromDb.Post.FeatureImageId, trackChanges: false);
                postFromDbToReturn.Post.Image = _mapper.Map<ImageDto>(image);
            }
            */

            //var votesToReturn = await _serviceManager.QualificationService.CreateQualificationForStudyOptionAsync(studyOptionId, qualification, trackChanges: false);
            return Ok(staffEntityFromDb);
        }
      
        //[Authorize]
        [HttpPut("{staffId}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateSaffById(Guid staffId, [FromBody] StaffForUpdateDto staff)
        {
            var staffFromDb = await _repository.Staff.GetTeacherByIdAsync(staffId, trackChanges: true);

            if (staffFromDb is null)
            {
                return NotFound($"Staff with id {staffId} does not exist");
            }
            staff.AuthorId = User.GetUserId();



            _mapper.Map(staff, staffFromDb.Staff);

            await _repository.SaveAsync();
            if (staff.CourseIds != null)
            {
                var staffCourses = await _repository.StaffCourse.GetAllStaffCoursesByStaffIdAsync(staffFromDb.Staff.StaffId, trackChanges: false);

                //delete the staff courses before adding new ones

                foreach (var sc in staffCourses)
                {
                    _repository.StaffCourse.DeleteAsync(sc);
                    await _repository.SaveAsync();
                }

                foreach (var courseId in staff.CourseIds)
                {
                    var staffCourse = new StaffCourse()
                    {
                        StaffId = staffFromDb.Staff.StaffId,
                        CourseId = courseId
                    };
                    _repository.StaffCourse.CreateAsync(staffCourse);
                    await _repository.SaveAsync();

                }
            }

          
            return NoContent();
        }
        //[Authorize]
        [HttpDelete("{staffId}")]
        public async Task<IActionResult> MoveStaffToTrash(Guid staffId)
        {


            var staffEntity = await _repository.Staff.GetTeacherByIdAsync(staffId, trackChanges: false);
            if (staffEntity is null)
                return NotFound($"Staff with id {staffId} does not exist");


            _repository.Staff.MoveToTrash(staffEntity.Staff);

            await _repository.SaveAsync();

            return NoContent();
        }

        /*[HttpDelete("permanentDelete/{studentId}")]

        public async Task<IActionResult> DeletePostPermanently(Guid studentId)
        {
            var studentEntity = await _repository.Student.GetStudentByIdAsync(studentId, trackChanges: false);

            if (studentEntity is null)
                return NotFound($"Student with id {studentId} does not exist");

            _repository.Student.Per(postEntity.Post);
            await _repository.SaveAsync();

            return NoContent();
        }*/

        [HttpPut("publish/{staffId}")]
        public async Task<IActionResult> PublishStaff(Guid staffId)
        {

            var staffEntity = await _repository.Staff.GetTeacherByIdAsync(staffId, trackChanges: false);
            if (staffEntity is null)
                return NotFound($"Staff with id {staffId} does not exist");

            _repository.Staff.Publish(staffEntity.Staff);

            await _repository.SaveAsync();

            return NoContent();
        }

        [HttpPut("save-draft/{staffId}")]
        public async Task<IActionResult> SetPostToDraft(Guid staffId)
        {

            var staffEntity = await _repository.Staff.GetTeacherByIdAsync(staffId, trackChanges: false);
            if (staffEntity is null)
                return NotFound($"Staff with id {staffId} does not exist");

            _repository.Staff.SetToDraft(staffEntity.Staff);

            await _repository.SaveAsync();

            return NoContent();
        }
    }
}


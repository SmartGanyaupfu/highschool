using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using HighSchool.API.ActionFilters;
using HighSchool.API.Extensions;
using HighSchool.API.Migrations;
using HighSchool.Contracts;
using HighSchool.Entities.Models;
using HighSchool.Shared.DTOs;
using HighSchool.Shared.RequestFeatures;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HighSchool.API.Controllers.API
{
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public StudentsController(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        // GET: api/values
        [HttpGet]
        public async Task<IActionResult> GetStudents([FromQuery] RequestParameters requestParameters)
        {

            var students = await _repository.Student.GetAllStudentsAsync(requestParameters, trackChanges: false);
            var studentsToReturn = _mapper.Map<IEnumerable< StudentDto>>(students);

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(students.MetaData));
          
            return Ok(studentsToReturn);
        }

        // GET api/values/5
        [HttpGet("{studentId}", Name = "studentsId")]
        public async Task<IActionResult> GetPageById(Guid studentId)
        {
            var student = await _repository.Student.GetStudentByIdAsync(studentId, trackChanges: false);
            if (student is null)
                return NotFound();

            var studentToReturn = _mapper.Map<StudentDto>(student);
            /* Image image;
             //Gallery gallery;


             if (post.Post.FeatureImageId != null)
             {
                 image = await _repository.Image.GetImageByIdAsync((int)post.Post.FeatureImageId, trackChanges: false);
                 postToReturn.Post.Image = _mapper.Map<ImageDto>(image);
             }
            */



            return Ok(studentToReturn);
        }
        /*[HttpGet("slug/{postSlug}")]
        public async Task<IActionResult> GetPostBySlug(string postSlug)
        {
            var post = await _repository.Post.GetPostBySlugNameAsync(postSlug, trackChanges: false);
            if (post is null)
                return NotFound();

            Image image;

            //Gallery gallery;
            var postToReturn = _mapper.Map<PostMVDto>(post);

            if (post.Post.FeatureImageId != null)
            {
                image = await _repository.Image.GetImageByIdAsync((int)post.Post.FeatureImageId, trackChanges: false);
                postToReturn.Post.Image = _mapper.Map<ImageDto>(image);
            }
            /*  if (post.SgGalleryId != null)
           {
               gallery = await _repository.Gallery.GetGalleryByIdAsync((int)post.SgGalleryId, trackChanges: false);
               postToReturn.Gallery = _mapper.Map<GalleryDto>(gallery);
           }
           var pageToReturn = _mapper.Map<PostDto>(post);*/
           /* return Ok(postToReturn);
        }
    */

        //[Authorize]
        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateStudent([FromBody] StudentForCreationDto student)
        {
            DateTime dob = (DateTime)student.DateOfBirth;
            var date = DateTime.Now;
            string year = (date.Year%100).ToString();
            string month = dob.Month.ToString().PadLeft(2, '0');
            string suffix= student?.LastName[0].ToString().ToUpper();
            string second = date.Second.ToString().PadLeft(2, '0');
            string prefix = student?.FirstName[0].ToString().ToUpper();
            string regNumber = prefix+year + month +second + suffix;
            
            var studentsFromDb = await _repository.Student.GetStudentRegistrationNumberAsync(regNumber, trackChanges: false);

            if (studentsFromDb != null)
            {
                date = DateTime.Now;
                second = date.Second.ToString().PadLeft(2, '0');
                regNumber = prefix + year + month + second + suffix;

               // return BadRequest($"Student with id {regNumber} already exists. Try again later");
            }

            
            student.AuthorId = User.GetUserId();

            var studentEntity = _mapper.Map<Student>(student);
            studentEntity.StudentRegNumber = regNumber;

            _repository.Student.CreateStudentAsync(studentEntity);
            await _repository.SaveAsync();
            var studentToReturn = _mapper.Map<StudentDto>(studentEntity);
            /* if (student.GradesIds != null) { 
             foreach (var gradeId in student.GradesIds)
             {
                 var studentGrade = new StudentGrade()
                 {
                     StudentId = studentEntity.StudentId,
                     GradeId = gradeId
                 };
                 _repository.StudentGrade.CreateAsync(studentGrade);
                 await _repository.SaveAsync();

             }
             }
             if (student.GraduateIds !=null)
             {
                 foreach (var graduateId in student.GraduateIds)
                 {
                     var studentGraduate = new StudentGraduate()
                     {
                         StudentId = studentEntity.StudentId,
                         GraduateId = graduateId
                     };
                     _repository.StudentGraduate.CreateAsync(studentGraduate);
                     await _repository.SaveAsync();
                 }
             }


             var studentFromDb = await _repository.Student.GetStudentByIdAsync(studentEntity.StudentId, trackChanges: false);
             if (studentFromDb is null)
                 return NotFound("Student created,but could not be be retrieved.");

             Image image;
             //Gallery gallery;
             var studentFromDbToReturn = _mapper.Map<StudentDto>(studentFromDb);

             /*if (postFromDb.Post.FeatureImageId != null)
             {
                 image = await _repository.Image.GetImageByIdAsync((int)postFromDb.Post.FeatureImageId, trackChanges: false);
                 postFromDbToReturn.Post.Image = _mapper.Map<ImageDto>(image);
             }
             */

            //var votesToReturn = await _serviceManager.QualificationService.CreateQualificationForStudyOptionAsync(studyOptionId, qualification, trackChanges: false);
            // return Ok(studentFromDbToReturn);
            return CreatedAtRoute("studentsId", new { studentId = studentToReturn.StudentId }, studentToReturn);
        }
       
        
        //[Authorize]
        [HttpPut("{studentId}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateStudentById(Guid studentId, [FromBody] StudentForUpdateDto student)
        {
            var studentFromDb = await _repository.Student.GetStudentByIdAsync(studentId, trackChanges: true);

            if (studentFromDb is null )
            {
                return NotFound($"Student with id {studentId} does not exist");
            }



            student.AuthorId = User.GetUserId();

          

            _mapper.Map(student, studentFromDb);

            await _repository.SaveAsync();
           /* if (student.GradesIds !=null)
            {
                var studentGrades = await _repository.StudentGrade.GetAllStudentGradesByStudentIdAsync(studentFromDb.StudentId, trackChanges: false);

                //delete the sudent grades before adding new ones

                foreach (var sg in studentGrades)
                {
                    _repository.StudentGrade.DeleteAsync(sg);
                    await _repository.SaveAsync();
                }

                //adding new sgs
                foreach (var gradeId in student.GradesIds)
                {
                    var studentGrade = new StudentGrade()
                    {
                        StudentId = studentId,
                        GradeId = gradeId
                    };
                    _repository.StudentGrade.CreateAsync(studentGrade);
                    await _repository.SaveAsync();
                }
            }

            if (student.GraduateIds !=null)
            {
                var studentGraduates = await _repository.StudentGraduate.GetAllStudentGraduatesByStudentIdAsync(studentFromDb.StudentId, trackChanges: false);

                //delete the sudent grades before adding new ones

                foreach (var sg in studentGraduates)
                {
                    _repository.StudentGraduate.DeleteAsync(sg);
                    await _repository.SaveAsync();
                }

                //adding student graduations
                foreach (var graduateId in student.GraduateIds)
                {
                    var studentGraduate = new StudentGraduate()
                    {
                        StudentId = studentId,
                        GraduateId = graduateId
                    };
                    _repository.StudentGraduate.CreateAsync(studentGraduate);
                    await _repository.SaveAsync();
                }
            }*/
            return NoContent();
        }
        //[Authorize]
        [HttpDelete("{studentId}")]
        public async Task<IActionResult> MoveStudentToTrash(Guid studentId)
        {


            var studentEntity = await _repository.Student.GetStudentByIdAsync(studentId, trackChanges: false);
            if (studentEntity is null)
                return NotFound($"Student with id {studentId} does not exist");


            _repository.Student.MoveToTrash(studentEntity);

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

        [HttpPut("publish/{studentId}")]
        public async Task<IActionResult> PublishPost(Guid studentId)
        {
            var studentEntity = await _repository.Student.GetStudentByIdAsync(studentId, trackChanges: false);
            if (studentEntity is null)
                return NotFound($"Student with id {studentId} does not exist");

            _repository.Student.Publish(studentEntity);

            await _repository.SaveAsync();

            return NoContent();
        }

        [HttpPut("save-draft/{studentId}")]
        public async Task<IActionResult> SetPostToDraft(Guid studentId)
        {
            var studentEntity = await _repository.Student.GetStudentByIdAsync(studentId, trackChanges: false);
            if (studentEntity is null)
                return NotFound($"Student with id {studentId} does not exist");

            _repository.Student.SetToDraft(studentEntity);

            await _repository.SaveAsync();

            return NoContent();
        }
    }
}


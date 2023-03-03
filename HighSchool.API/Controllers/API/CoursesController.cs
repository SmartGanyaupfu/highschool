using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using HighSchool.API.ActionFilters;
using HighSchool.API.Extensions;
using HighSchool.Contracts;
using HighSchool.Entities;
using HighSchool.Entities.Models;
using HighSchool.Shared.DTOs;
using HighSchool.Shared.RequestFeatures;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HighSchool.API.Controllers.API
{
    [Route("api/courses")]
    public class CoursesController  : ControllerBase
    {
        private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public CoursesController(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    // GET: api/values
    [HttpGet]
    public async Task<IActionResult> GetCourses([FromQuery] RequestParameters requestParameters)
    {

        var courses = await _repository.Course.GetAllCoursesAsync(requestParameters, trackChanges: false);
        var coursesToReturn = _mapper.Map<IEnumerable<CourseMVDto>>(courses);

        Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(courses.MetaData));

        return Ok(coursesToReturn);
    }

    // GET api/values/5
    [HttpGet("{courseId}", Name = "coursesId")]
    public async Task<IActionResult> GetSCourseById(Guid courseId)
    {
        var course = await _repository.Course.GetCourseByIdAsync(courseId, trackChanges: false);
        if (course is null)
            return NotFound();

        var courseToReturn = _mapper.Map<CourseMVDto>(course);
         Image image;
        


         if (course.Course.FeatureImageId != null)
         {
             image = await _repository.Image.GetImageByIdAsync((int)course.Course.FeatureImageId, trackChanges: false);
             courseToReturn.Course.Image = _mapper.Map<ImageDto>(image);
         }
        



        return Ok(courseToReturn);
    }
    [HttpGet("slug/{slug}")]
    public async Task<IActionResult> GetPostBySlug(string slug)
    {
        var course = await _repository.Course.GetCourseBySlugAsync(slug, trackChanges: false);
        if (course is null)
            return NotFound();

            var courseToReturn = _mapper.Map<CourseMVDto>(course);
            Image image;



            if (course.Course.FeatureImageId != null)
            {
                image = await _repository.Image.GetImageByIdAsync((int)course.Course.FeatureImageId, trackChanges: false);
                courseToReturn.Course.Image = _mapper.Map<ImageDto>(image);
            }
            /*  if (post.SgGalleryId != null)
           {
               gallery = await _repository.Gallery.GetGalleryByIdAsync((int)post.SgGalleryId, trackChanges: false);
               postToReturn.Gallery = _mapper.Map<GalleryDto>(gallery);
           }
           var pageToReturn = _mapper.Map<PostDto>(post);*/
             return Ok(courseToReturn);
         }


            //[Authorize]
            [HttpPost]
            [ServiceFilter(typeof(ValidationFilterAttribute))]
            public async Task<IActionResult> CreateCourse([FromBody] CourseForCreationDto  course)
        {

            var courseFromDb = await _repository.Course.GetCourseBySlugAsync(course.Slug, trackChanges: false);

            if (courseFromDb != null)
            {
                Guid g = Guid.NewGuid();
                course.Slug += g + "-copy";
            }
            course.AuthorId = User.GetUserId();

                var courseEntity = _mapper.Map<Course>(course);
                _repository.Course.CreateCourseAsync(courseEntity);
                await _repository.SaveAsync();
                


                var courseEntityFromDb = await _repository.Course.GetCourseByIdAsync(courseEntity.CourseId, trackChanges: false);
                if (courseEntityFromDb is null)
                    return NotFound("Course created,but could not be be retrieved.");

            var courseToReturn = _mapper.Map<CourseMVDto>(courseEntityFromDb);
            Image image;


            if (courseEntityFromDb.Course.FeatureImageId != null)
            {
                image = await _repository.Image.GetImageByIdAsync((int)courseEntityFromDb.Course.FeatureImageId, trackChanges: false);
                courseToReturn.Course.Image = _mapper.Map<ImageDto>(image);
            }

            return Ok(courseToReturn);
    }
   
    //[Authorize]
    [HttpPut("{courseId}")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> UpdateCourseById(Guid courseId, [FromBody] CourseForUpdateDto courseForUpdate)
    {
        var courseFromDb = await _repository.Course.GetCourseByIdAsync(courseId, trackChanges: true);

        if (courseFromDb is null)
        {
            return NotFound($"Course with id {courseId} does not exist");
        }
        courseForUpdate.AuthorId = User.GetUserId();



        _mapper.Map(courseForUpdate, courseFromDb.Course);

        await _repository.SaveAsync();


        return NoContent();
    }
    //[Authorize]
    [HttpDelete("{courseId}")]
    public async Task<IActionResult> MoveCourseToTrash(Guid courseId)
    {


        var courseEntity = await _repository.Course.GetCourseByIdAsync(courseId, trackChanges: false);
        if (courseEntity is null)
            return NotFound($"Course with id {courseId} does not exist");


        _repository.Course.MoveToTrash(courseEntity.Course);

        await _repository.SaveAsync();

        return NoContent();
    }

    [HttpDelete("permanentDelete/{studentId}")]

    public async Task<IActionResult> DeleteCoursePermanently(Guid courseId)
    {
            var courseEntity = await _repository.Course.GetCourseByIdAsync(courseId, trackChanges: false);
            if (courseEntity is null)
                return NotFound($"Course with id {courseId} does not exist");


            _repository.Course.PermanentDelete(courseEntity.Course);

            await _repository.SaveAsync();

            return NoContent();
        }

    [HttpPut("publish/{courseId}")]
    public async Task<IActionResult> PublishCourse(Guid courseId)
    {

            var courseEntity = await _repository.Course.GetCourseByIdAsync(courseId, trackChanges: false);
            if (courseEntity is null)
                return NotFound($"Course with id {courseId} does not exist");


            _repository.Course.Publish(courseEntity.Course);

            await _repository.SaveAsync();

            return NoContent();
        }

    [HttpPut("save-draft/{courseId}")]
    public async Task<IActionResult> SetCourseToDraft(Guid courseId)
    {
            var courseEntity = await _repository.Course.GetCourseByIdAsync(courseId, trackChanges: false);
            if (courseEntity is null)
                return NotFound($"Course with id {courseId} does not exist");


            _repository.Course.SetToDraft(courseEntity.Course);

            await _repository.SaveAsync();

            return NoContent();
        }
}
}


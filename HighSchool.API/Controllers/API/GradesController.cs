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

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HighSchool.API.Controllers.API
{
    [Route("api/grades")]
    public class GradesController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public GradesController(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        // GET: api/values
        [HttpGet]
        public async Task<IActionResult> GetGrades([FromQuery] RequestParameters requestParameters)
        {

            var grades = await _repository.Grade.GetGradesAsync(requestParameters, trackChanges: false);
            var gradesToReturn = _mapper.Map<IEnumerable<GradeMVDto>>(grades);

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(grades.MetaData));

            return Ok(gradesToReturn);
        }

        // GET api/values/5
        [HttpGet("{gradeId}", Name = "gradesId")]
        public async Task<IActionResult> GetGradeById(int gradeId)
        {
            var grade = await _repository.Grade.GetGradeByIdAsync(gradeId, trackChanges: false);
            if (grade is null)
                return NotFound();

            var gradeToReturn = _mapper.Map<GradeMVDto>(grade);
          



            return Ok(gradeToReturn);
        }
       

        //[Authorize]
        [HttpPost ]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateGrade( [FromBody] GradeForCreationDto grade)
        {
            

            grade.AuthorId = User.GetUserId();

            var gradeEntity = _mapper.Map<Grade>(grade);
            _repository.Grade.CreateGradeAsync(grade.StaffId,gradeEntity);
            await _repository.SaveAsync();
           

            var gradeFromDb = await _repository.Grade.GetGradeByIdAsync(gradeEntity.GradeId, trackChanges: false);
            if (gradeFromDb is null)
                return NotFound("Grade created,but could not be be retrieved.");

           
            var gradeFromDbToReturn = _mapper.Map<GradeMVDto>(gradeFromDb);

            return Ok(gradeFromDbToReturn);
        }
    
        //[Authorize]
        [HttpPut("{gradeId}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateGradeById(int gradeId, [FromBody] GradeForUpdateDto grade)
        {
            var gradeFromDb = await _repository.Grade.GetGradeByIdAsync(gradeId, trackChanges: true);

            if (gradeFromDb is null)
            {
                return NotFound($"Grade with id {gradeId} does not exist");
            }
            grade.AuthorId = User.GetUserId();



            _mapper.Map(grade, gradeFromDb.Grade);

       
           
            return NoContent();
        }
        //[Authorize]
        [HttpDelete("{gradeId}")]
        public async Task<IActionResult> MoveGradeToTrash(int gradeId)
        {



            var gradeFromDb = await _repository.Grade.GetGradeByIdAsync(gradeId, trackChanges: false);

            if (gradeFromDb is null)
            {
                return NotFound($"Grade with id {gradeId} does not exist");
            }


            _repository.Grade.MoveToTrash(gradeFromDb.Grade);

            await _repository.SaveAsync();

            return NoContent();
        }

  
    }
}


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

namespace HighSchool.API.Controllers.API
{
    [Route("api/student/{studentId}/nextOfKin")]
    public class NextOfKinsController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        // private readonly IImageUploader _imageService;

        public NextOfKinsController(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
     
      

        // GET api/values/5
        [HttpGet("{nextOfKinId}", Name = "nextOfKinsId")]
        public async Task<IActionResult> GetNextOfKinById(Guid studentId, int nextOfKinId)
        {
            var nextOfkin = await _repository.NextOfKin.GetNextOfKinByIdAsync(studentId,nextOfKinId, trackChanges: false);
            if (nextOfkin is null)
                return NotFound();
            var nextOfKinToReturn = _mapper.Map<NextOfKinDto>(nextOfkin);


            return Ok(nextOfKinToReturn);
        }
    



        //* [Authorize]
        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateNextOfKinForStudent(Guid studentId,[FromBody] NextOfKinForCreationDto nextOfKinForCreation)
        {
            var student = await _repository.Student.GetStudentByIdAsync(studentId, trackChanges: false);
            if (student is null)
                return NotFound();


            var nextOfKinEntity = _mapper.Map<NextOfKin>(nextOfKinForCreation);
            _repository.NextOfKin.CreateNextOfKinAsync(studentId,nextOfKinEntity);
            await _repository.SaveAsync();
            var nextOfKinToReturn = _mapper.Map<NextOfKinDto>(nextOfKinEntity);

            //var votesToReturn = await _serviceManager.QualificationService.CreateQualificationForStudyOptionAsync(studyOptionId, qualification, trackChanges: false);
            return CreatedAtRoute("nextOfKinsId", new { studentId=studentId,nextOfkinId = nextOfKinToReturn.NextOfKinId }, nextOfKinToReturn);
        }

        //[Authorize]
        [HttpPut("{nextOfKinId}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateNextOfKinById(Guid studentId,int nextOfKinId, [FromBody] NextOfKinForUpdateDto nextOfKinForUpdate)
        {


            var nextOfkin = await _repository.NextOfKin.GetNextOfKinByIdAsync(studentId, nextOfKinId, trackChanges: true);
            if (nextOfkin is null)
                return NotFound($"NextOfkIn with id {nextOfKinId} does not exist");



            _mapper.Map(nextOfKinForUpdate, nextOfkin);

            await _repository.SaveAsync();
            return NoContent();
        }
        //[Authorize]
        // Page is set to delete only
        [HttpDelete("{nextOfKinId}")]
        public async Task<IActionResult> Delete(Guid studentId,int nextOfKinId)
        {



            var nextOfkin = await _repository.NextOfKin.GetNextOfKinByIdAsync(studentId, nextOfKinId, trackChanges: false);
            if (nextOfkin is null)
                return NotFound($"NextOfkIn with id {nextOfKinId} does not exist");



            _repository.NextOfKin.MoveToTrash(nextOfkin);

            await _repository.SaveAsync();

            return NoContent();
        }

    }
}


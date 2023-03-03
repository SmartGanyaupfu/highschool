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
    [Route("api/student/{studentId}/resources")]
    public class AllocatedResourcesController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        // private readonly IImageUploader _imageService;

        public AllocatedResourcesController(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        // GET: api/values
        [HttpGet]
        public async Task<IActionResult> GeResources(Guid studentId)
        {

            var resources = await _repository.AllocatedResource.GetAllAllocatedResourcesForStudentAsync(studentId,trackChanges: false);
            var resourcesToReturn = _mapper.Map<IEnumerable<AllocatedResourceDto>>(resources);


            return Ok(resourcesToReturn);
        }

        // GET api/values/5
        [HttpGet("{resourceId}", Name = "resourcesId")]
        public async Task<IActionResult> GetResoureById(Guid studentId,int resourceId)
        {
            var resource = await _repository.AllocatedResource.GetAllocatedResourceByIdAsync(studentId,resourceId, trackChanges: false);
            if (resource is null)
                return NotFound();
            var resourceToReturn = _mapper.Map<AllocatedResourceDto>(resource);


            return Ok(resourceToReturn);
        }
        



        //* [Authorize]
        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateResource(Guid studentId,[FromBody] AllocatedResourceForCreationDto resourceForCreationDto)
        {
            var student = await _repository.Student.GetStudentByIdAsync(studentId, trackChanges: false);
            if (student is null)
                return NotFound();
           

            var resourceEntity = _mapper.Map<AllocatedResource>(resourceForCreationDto);
            _repository.AllocatedResource.CreateResourceAsync(studentId,resourceEntity);
            await _repository.SaveAsync();
            var resourceToReturn = _mapper.Map<AllocatedResourceDto>(resourceEntity);

            
            return CreatedAtRoute("resourcesId", new { studentId= studentId, resourceId= resourceEntity.AllocatedResourceId }, resourceToReturn);
        }

        //[Authorize]
        [HttpPut("{resourceId}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateResourceById(Guid studentId,int resourceId, [FromBody] AllocatedResourceForUpdateDto resourceForUpdateDto)
        {
            var student = await _repository.Student.GetStudentByIdAsync(studentId, trackChanges: false);
            if (student is null)
                return NotFound();

            var resourceEntity = await _repository.AllocatedResource.GetAllocatedResourceByIdAsync(studentId,resourceId, trackChanges: true);
            if (resourceEntity is null)
                return NotFound($"Resource with id {resourceId} does not exist");



            _mapper.Map(resourceForUpdateDto, resourceEntity);

            await _repository.SaveAsync();
            return NoContent();
        }
        //[Authorize]
        // Page is set to delete only
        [HttpDelete("{resourceId}")]
        public async Task<IActionResult> DeleteValue(Guid studentId,int resourceId)
        {


            var student = await _repository.Student.GetStudentByIdAsync(studentId, trackChanges: false);
            if (student is null)
                return NotFound();

            var resourceEntity = await _repository.AllocatedResource.GetAllocatedResourceByIdAsync(studentId, resourceId, trackChanges: false);
            if (resourceEntity is null)
                return NotFound($"Resource with id {resourceId} does not exist");


            _repository.AllocatedResource.MoveToTrash(resourceEntity);

            await _repository.SaveAsync();

            return NoContent();
        }

    }
}


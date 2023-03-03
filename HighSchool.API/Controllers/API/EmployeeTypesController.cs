using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using HighSchool.API.ActionFilters;
using HighSchool.Contracts;
using HighSchool.Entities.Models;
using HighSchool.Shared.DTOs;
using HighSchool.Shared.RequestFeatures;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HighSchool.API.Controllers.API
{
    [Route("api/employeeType")]
    public class EmployeeTypesController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        // private readonly IImageUploader _imageService;

        public EmployeeTypesController(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        // GET: api/values
        [HttpGet]
        public async Task<IActionResult> GetEmpTypes()
        {

            var employeeTypes = await _repository.EmployeeType.GetAllEmployeeTypeAsync( trackChanges: false);
          
            var employeeTypesToReturn = _mapper.Map<IEnumerable<EmployeeTypeDto>>(employeeTypes);


            return Ok(employeeTypesToReturn);
        }

        // GET api/values/5
        [HttpGet("{typeId}", Name = "typesId")]
        public async Task<IActionResult> GetTypeById( int typeId)
        {
            var type = await _repository.EmployeeType.GetEmployeeTypeByIdAsync(typeId, trackChanges: false);
            if (type is null)
                return NotFound();
            var typeToReturn = _mapper.Map<EmployeeTypeDto>(type);


            return Ok(typeToReturn);
        }




        //* [Authorize]
        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateType([FromBody] EmployeeTypeForCreationDto typeForCreation)
        {
          

            var typeEntity = _mapper.Map<EmployeeType>(typeForCreation);
            _repository.EmployeeType.CreateEmployeeTypeAsync(typeEntity);
            await _repository.SaveAsync();
            var typeToReturn = _mapper.Map<EmployeeTypeDto>(typeEntity);


            return CreatedAtRoute("typesId", new { typeId = typeEntity.EmployeeTypeId }, typeToReturn);
        }

        //[Authorize]
        [HttpPut("{typeId}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateTypeById(int typeId, [FromBody] EmployeeTypeForUpdateDto typeForUpdateDto)
        {


            var type = await _repository.EmployeeType.GetEmployeeTypeByIdAsync(typeId, trackChanges: false);
            if (type is null)
                return NotFound($"EmployeeType with id {typeId} does not exist");


            _mapper.Map(typeForUpdateDto, type);

            await _repository.SaveAsync();
            return NoContent();
        }
        //[Authorize]
        // Page is set to delete only
        [HttpDelete("{typeId}")]
        public async Task<IActionResult> Delete( int typeId)
        {


            var type = await _repository.EmployeeType.GetEmployeeTypeByIdAsync(typeId, trackChanges: false);
            if (type is null)
                return NotFound($"EmployeeType with id {typeId} does not exist");


            _repository.EmployeeType.MoveToTrash(type);

            await _repository.SaveAsync();

            return NoContent();
        }
    }
}


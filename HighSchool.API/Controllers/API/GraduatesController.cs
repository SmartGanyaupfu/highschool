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
    [Route("api/graduates")]
    public class GraduatesController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public GraduatesController(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        // GET: api/values
        [HttpGet]
        public async Task<IActionResult> GetGraduates([FromQuery] RequestParameters requestParameters)
        {

            var graduates = await _repository.Graduate.GetGraduatesAsync(requestParameters, trackChanges: false);
            var graduatesToReturn = _mapper.Map<IEnumerable<GraduateDto>>(graduates);

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(graduates.MetaData));

            return Ok(graduatesToReturn);
        }

        // GET api/values/5
        [HttpGet("{graduateId}", Name = "graduatesId")]
        public async Task<IActionResult> GetGraduateById(int graduateId)
        {
            var graduate = await _repository.Graduate.GetGraduateByIdAsync(graduateId, trackChanges: false);
            if (graduate is null)
                return NotFound();

            var graduateToReturn = _mapper.Map<GraduateDto>(graduate);




            return Ok(graduateToReturn);
        }


        //[Authorize]
        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateGraduate([FromBody] GraduateForCreationDto graduate)
        {


            graduate.AuthorId = User.GetUserId();

            var graduateEntity = _mapper.Map<Graduate>(graduate);
            _repository.Graduate.CreateGraduateAsync( graduateEntity);
            await _repository.SaveAsync();


            var graduateFromDb = await _repository.Graduate.GetGraduateByIdAsync(graduateEntity.GraduateId, trackChanges: false);
            if (graduateFromDb is null)
                return NotFound("Graduate created,but could not be be retrieved.");


            var graduateFromDbToReturn = _mapper.Map<GraduateDto>(graduateFromDb);

            return Ok(graduateFromDbToReturn);
        }

        //[Authorize]
        [HttpPut("{graduateId}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateGraduateById(int graduateId, [FromBody] GraduateForUpdateDto graduate)
        {
            var graduateFromDb = await _repository.Graduate.GetGraduateByIdAsync(graduateId, trackChanges: true);

            if (graduateFromDb is null)
            {
                return NotFound($"Graduate with id {graduateId} does not exist");
            }
            graduate.AuthorId = User.GetUserId();



            _mapper.Map(graduate, graduateFromDb);



            return NoContent();
        }
        //[Authorize]
        [HttpDelete("{graduateId}")]
        public async Task<IActionResult> MoveGraduateToTrash(int graduateId)
        {



            var graduateFromDb = await _repository.Graduate.GetGraduateByIdAsync(graduateId, trackChanges: false);

            if (graduateFromDb is null)
            {
                return NotFound($"Graduate with id {graduateId} does not exist");
            }


            _repository.Graduate.MoveToTrash(graduateFromDb);

            await _repository.SaveAsync();

            return NoContent();
        }
    }
}


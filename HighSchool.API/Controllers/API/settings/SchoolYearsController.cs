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

namespace HighSchool.API.Controllers.API.settings
{
    [Route("api/schoo-years")]
    public class SchoolYearsController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        // private readonly IImageUploader _imageService;

        public SchoolYearsController(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        // GET: api/school-years
        [HttpGet]
        public async Task<IActionResult> GetAll(RequestParameters requestParameter)
        {

            var schoolYears = await _repository.SchoolYear.GetAllSchoolYearsAsync(requestParameter,trackChanges: false);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(schoolYears.MetaData));
            var schoolYearsToReturn = _mapper.Map<IEnumerable<SchoolYearDto>>(schoolYears);


            return Ok(schoolYearsToReturn);
        }
        // GET: api/school-years/published
        [HttpGet("published")]
        public async Task<IActionResult> GetAllPublished(RequestParameters requestParameters)
        {

            var schoolYears = await _repository.SchoolYear.GetAllPublishedSchoolYearsAsync(requestParameters, trackChanges: false);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(schoolYears.MetaData));
            var schoolYearsToReturn = _mapper.Map<IEnumerable<SchoolYearDto>>(schoolYears);


            return Ok(schoolYearsToReturn);
        }
        // GET: api/school-years/draft
        [HttpGet("draft")]
        public async Task<IActionResult> GetAllDraft(RequestParameters requestParameters)
        {

            var schoolYears = await _repository.SchoolYear.GetAllDraftSchoolYearsAsync(requestParameters, trackChanges: false);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(schoolYears.MetaData));
            var schoolYearsToReturn = _mapper.Map<IEnumerable<SchoolYearDto>>(schoolYears);


            return Ok(schoolYearsToReturn);
        }

        //  api/school-years/1
        [HttpGet("{schoolYearId}", Name = "schoolYearIdRoute")]
        public async Task<IActionResult> GetById(int schoolYearId)
        {
            var year = await _repository.SchoolYear.GetSchoolYearByIdAsync(schoolYearId, trackChanges: false);
            if (year is null)
                return NotFound();


            return Ok(year);
        }




        //* [Authorize]
        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Create([FromBody] SchoolYearForCreationDto schoolYearForCreation)
        {
            /* Todo   can you do a search by year to avoid duplicate years*/
            schoolYearForCreation.AuthorId = User.GetUserId();

            var yearEntity = _mapper.Map<SchoolYear>(schoolYearForCreation);
            _repository.SchoolYear.CreateAsync(yearEntity);
            await _repository.SaveAsync();
            var yearToReturn = _mapper.Map<SchoolYearDto>(yearEntity);


            return CreatedAtRoute("schoolYearIdRoute", new { schoolYearId = yearEntity.SchoolYearId }, yearToReturn);

            // return Ok(blockEntity);
        }

        //[Authorize]
        [HttpPut("{schoolYearId}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Update(int schoolYearId, [FromBody] SchoolYearForUpdateDto schoolYearForUpdate)
        {

            schoolYearForUpdate.AuthorId = User.GetUserId();
            schoolYearForUpdate.DateUpdated = DateTime.Now;
            var schoolYearEntity = await _repository.SchoolYear.GetSchoolYearByIdAsync(schoolYearId, trackChanges: true);
            if (schoolYearEntity is null)
                return NotFound($"School year with id {schoolYearId} does not exist");



            _mapper.Map(schoolYearForUpdate, schoolYearEntity);

            await _repository.SaveAsync();
            return NoContent();
        }
        //[Authorize]
        // Page is set to delete only
        [HttpPut("delete/{schoolYearId}")]
        public async Task<IActionResult> MoveToBin(int schoolYearId)
        {


            var schoolYearEntity = await _repository.SchoolYear.GetSchoolYearByIdAsync(schoolYearId, trackChanges: true);
            if (schoolYearEntity is null)
                return NotFound($"School year with id {schoolYearId} does not exist");
            schoolYearEntity.AuthorId = User.GetUserId();

            _repository.SchoolYear.MoveToTrash(schoolYearEntity);

            await _repository.SaveAsync();

            return NoContent();
        }

        [HttpPut("set-draft/{schoolYearId}")]
        public async Task<IActionResult> MoveToDraft(int schoolYearId)
        {


            var schoolYearEntity = await _repository.SchoolYear.GetSchoolYearByIdAsync(schoolYearId, trackChanges: true);
            if (schoolYearEntity is null)
                return NotFound($"School year with id {schoolYearId} does not exist");
            schoolYearEntity.AuthorId = User.GetUserId();

            _repository.SchoolYear.SetToDraft(schoolYearEntity);

            await _repository.SaveAsync();

            return NoContent();
        }

        [HttpPut("publish/{schoolYearId}")]
        public async Task<IActionResult> Publish(int schoolYearId)
        {


            var schoolYearEntity = await _repository.SchoolYear.GetSchoolYearByIdAsync(schoolYearId, trackChanges: true);
            if (schoolYearEntity is null)
                return NotFound($"School year with id {schoolYearId} does not exist");
            schoolYearEntity.AuthorId = User.GetUserId();

            _repository.SchoolYear.Publish(schoolYearEntity);

            await _repository.SaveAsync();

            return NoContent();
        }

        [HttpPut("perm-delete/{schoolYearId}")]
        public async Task<IActionResult> MoveToDraftft(int schoolYearId)
        {


            var schoolYearEntity = await _repository.SchoolYear.GetSchoolYearByIdAsync(schoolYearId, trackChanges: true);
            if (schoolYearEntity is null)
                return NotFound($"School year with id {schoolYearId} does not exist");
            schoolYearEntity.AuthorId = User.GetUserId();

            _repository.SchoolYear.PermanentDelete(schoolYearEntity);

            await _repository.SaveAsync();

            return NoContent();
        }
    }
}


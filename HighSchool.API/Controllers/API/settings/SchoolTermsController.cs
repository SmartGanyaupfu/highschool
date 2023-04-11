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

namespace HighSchool.API.Controllers.API.settings
{
    [Route("api/school-terms")]
    public class SchoolTermsController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        // private readonly IImageUploader _imageService;

        public SchoolTermsController(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        // GET: api/school-terms
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            var terms = await _repository.SchoolTerm.GetAllSchoolTermsAsync(trackChanges: false);


            return Ok(terms);
        }
        // GET: api/school-terms/published
        [HttpGet("published")]
        public async Task<IActionResult> GetAllPublished()
        {

            var terms = await _repository.SchoolTerm.GetAllPublishedSchoolTermsAsync(trackChanges: false);


            return Ok(terms);
        }
        // GET: api/school-terms/draft
        [HttpGet("draft")]
        public async Task<IActionResult> GetAllDraft()
        {

            var terms = await _repository.SchoolTerm.GetAllDraftSchoolTermsAsync(trackChanges: false);


            return Ok(terms);
        }

        //  api/school-terms/1
        [HttpGet("{schoolTermId}", Name = "schoolTermIdRoute")]
        public async Task<IActionResult> GetById(int schoolTermId)
        {
            var term = await _repository.SchoolTerm.GetSchoolTermByIdAsync(schoolTermId,trackChanges: false);
            if (term is null)
                return NotFound();


            return Ok(term);
        }




        //* [Authorize]
        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Create([FromBody] SchoolTermForCreationDto schoolTermForCreation)
        {

            schoolTermForCreation.AuthorId = User.GetUserId();

            var termEntity = _mapper.Map<SchoolTerm>(schoolTermForCreation);
            _repository.SchoolTerm.CreateAsync(termEntity);
            await _repository.SaveAsync();
            var termToReturn = _mapper.Map<SchoolTermDto>(termEntity);


            return CreatedAtRoute("schoolTermIdRoute", new { schoolTermId = termEntity.SchoolTermId }, termToReturn);

            // return Ok(blockEntity);
        }

        //[Authorize]
        [HttpPut("{schoolTermId}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Update(int schoolTermId, [FromBody] SchoolTermForUpdateDto schoolTermForUpdate)
        {

            schoolTermForUpdate.AuthorId = User.GetUserId();
            schoolTermForUpdate.DateUpdated = DateTime.Now;
            var schoolTermEntity = await _repository.SchoolTerm.GetSchoolTermByIdAsync(schoolTermId, trackChanges: true);
            if (schoolTermEntity is null)
                return NotFound($"Term with id {schoolTermId} does not exist");



            _mapper.Map(schoolTermForUpdate, schoolTermEntity);

            await _repository.SaveAsync();
            return NoContent();
        }
        //[Authorize]
        // Page is set to delete only
        [HttpPut("delete/{schoolTermId}")]
        public async Task<IActionResult> MoveToBin(int schoolTermId)
        {


            var schoolTermEntity = await _repository.SchoolTerm.GetSchoolTermByIdAsync(schoolTermId, trackChanges: true);
            if (schoolTermEntity is null)
                return NotFound($"Term with id {schoolTermId} does not exist");
            schoolTermEntity.AuthorId = User.GetUserId();

            _repository.SchoolTerm.MoveToTrash(schoolTermEntity);

            await _repository.SaveAsync();

            return NoContent();
        }

        [HttpPut("set-draft/{schoolTermId}")]
        public async Task<IActionResult> MoveToDraft(int schoolTermId)
        {


            var schoolTermEntity = await _repository.SchoolTerm.GetSchoolTermByIdAsync(schoolTermId, trackChanges: true);
            if (schoolTermEntity is null)
                return NotFound($"Term with id {schoolTermId} does not exist");
            schoolTermEntity.AuthorId = User.GetUserId();

            _repository.SchoolTerm.SetToDraft(schoolTermEntity);

            await _repository.SaveAsync();

            return NoContent();
        }

        [HttpPut("publish/{schoolTermId}")]
        public async Task<IActionResult> Publish(int schoolTermId)
        {


            var schoolTermEntity = await _repository.SchoolTerm.GetSchoolTermByIdAsync(schoolTermId, trackChanges: true);
            if (schoolTermEntity is null)
                return NotFound($"Tearm with id {schoolTermId} does not exist");
            schoolTermEntity.AuthorId = User.GetUserId();

            _repository.SchoolTerm.Publish(schoolTermEntity);

            await _repository.SaveAsync();

            return NoContent();
        }

        [HttpPut("perm-delete/{schoolTermId}")]
        public async Task<IActionResult> MoveToDraftft(int schoolTermId)
        {


            var schoolTermEntity = await _repository.SchoolTerm.GetSchoolTermByIdAsync(schoolTermId, trackChanges: true);
            if (schoolTermEntity is null)
                return NotFound($"Term with id {schoolTermId} does not exist");


            _repository.SchoolTerm.PermanentDelete(schoolTermEntity);

            await _repository.SaveAsync();

            return NoContent();
        }
    }
}


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
    [Route("api/blocks")]
    public class BlocksController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        // private readonly IImageUploader _imageService;

        public BlocksController(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        // GET: api/values
        [HttpGet]
        public async Task<IActionResult> GetBlocks( RequestParameters requestParameters)
        {

            var blocks = await _repository.ContentBlock.GetAllBlocksAsync( requestParameters, trackChanges: false);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(blocks.MetaData));


            return Ok(blocks);
        }

        // GET api/values/5
        [HttpGet("{blockId}", Name = "blocksId")]
        public async Task<IActionResult> GetBlockById(int blockId)
        {
            var block = await _repository.ContentBlock.GetContentBlockByIdAsync(blockId, trackChanges: false);
            if (block is null)
                return NotFound();


            return Ok(block);
        }




        //* [Authorize]
        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateBlock( [FromBody] ContentBlockForCreationDto blockForCreation)
        {
           


            var blockEntity = _mapper.Map<ContentBlock>(blockForCreation);
            _repository.ContentBlock.CreateContentBlockAsync( blockEntity);
            await _repository.SaveAsync();
            //var blockToReturn = _mapper.Map<ContentBlock>(blockEntity);


            //return CreatedAtRoute("notesId", new { studentId = studentId, noteId = noteEntity.NoteId }, noteToReturn);

            return Ok(blockEntity);
        }

        //[Authorize]
        [HttpPut("{blockId}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateBlockById(int blockId, [FromBody] ContentBlockForUpdateDto blockForUpdate)
        {


            var blockEntity = await _repository.ContentBlock.GetContentBlockByIdAsync(blockId, trackChanges: true);
            if (blockEntity is null)
                return NotFound($"Block with id {blockId} does not exist");



            _mapper.Map(blockForUpdate, blockEntity);

            await _repository.SaveAsync();
            return NoContent();
        }
        //[Authorize]
        // Page is set to delete only
        [HttpDelete("{blockId}")]
        public async Task<IActionResult> DeleteValue(int blockId)
        {


            var blockEntity = await _repository.ContentBlock.GetContentBlockByIdAsync(blockId, trackChanges: false);
            if (blockEntity is null)
                return NotFound($"Block with id {blockId} does not exist");


            _repository.ContentBlock.MoveToTrash(blockEntity);

            await _repository.SaveAsync();

            return NoContent();
        }
    }
}


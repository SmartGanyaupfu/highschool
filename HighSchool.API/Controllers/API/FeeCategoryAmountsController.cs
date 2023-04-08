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
    [Route("api/[controller]")]
    public class FeeCategoryAmountsController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        // private readonly IImageUploader _imageService;

        public FeeCategoryAmountsController(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        // GET: api/values
        [HttpGet]
        public async Task<IActionResult> GetFeeCatAmounts(RequestParameters requestParameters)
        {

            var blocks = await _repository.ContentBlock.GetAllBlocksAsync(requestParameters, trackChanges: false);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(blocks.MetaData));


            return Ok(blocks);
        }

       
    }
}


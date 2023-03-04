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
    [Route("api/widgets")]
    public class WidgetsController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        // private readonly IImageUploader _imageService;

        public WidgetsController(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        // GET: api/values
        [HttpGet]
        public async Task<IActionResult> GetWidgets( )
        {

            var widgets = await _repository.Widget.GetWidgetAsync( trackChanges: false);
            


            return Ok(widgets);
        }

     




        //* [Authorize]
        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateWidget( [FromBody] WidgetForCreationDto widget)
        {

            var widgetEntity = _mapper.Map<Widget>(widget);
            _repository.Widget.CreateWidgetAsync(widgetEntity);
            await _repository.SaveAsync();


            return Ok(widgetEntity);
        }

        //[Authorize]
        [HttpPut("{widgetId}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateNoteById( int widgetId, [FromBody] WidgetForUpdateDto widget)
        {


            var widgetFromDb= await _repository.Widget.GetWidgetByIdAsync( widgetId, trackChanges: true);
            if (widgetFromDb is null)
                return NotFound($"Note with id {widgetId} does not exist");



            _mapper.Map(widget, widgetFromDb);

            await _repository.SaveAsync();
            return NoContent();
        }
        
    }
}


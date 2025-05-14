using System.Collections.Generic;
using System.Threading.Tasks;
using Services.Abstractions;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.Contracts.SonarProcess;
using WebApi.Models.SearchEvent;
using CDH = WebApi.Controllers.Helper.ControllerDebugHelper;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/v1/search-events")] //[Route("[controller]")]
    public class SearchEventController: ControllerBase
    {
        private readonly ISearchEventService _service;
        private readonly IMapper _mapper;
        private readonly ILogger<SearchEventController> _logger;

        public SearchEventController(ISearchEventService service, ILogger<SearchEventController> logger, IMapper mapper)
        {
            _service = service;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet("{eventId}")]
        public async Task<IActionResult> GetAsync(long eventId)
        {
            var res = _mapper.Map<SearchEventModel>(await _service.GetByIdAsync(eventId));
            return Ok(res);
            //return Ok((SearchEventModel)CDH.GetTestSearchEventModel());  // ОТЛАДКА 
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreatingSeachEventModel courseModel)
        {
            return Ok(await _service.CreateAsync(_mapper.Map<CreatingSearchEventDto>(courseModel)));
        }
        
        [HttpPut("{eventId}")]
        public async Task<IActionResult> EditAsync(long eventId, UpdatingSearchEventModel eventModel)
        {
            await _service.UpdateAsync(eventId, _mapper.Map<UpdatingSearchEventModel, UpdatingSearchEventDto>(eventModel));
            return Ok();
        }

        [HttpPut("WithSearchTasks")]
        public async Task<IActionResult> EditWithSearchTasksAsync(long eventId, UpdatingSearchEventWithSearchTasksModel eventModel)
        {
            await _service.UpdatingWithSonarTasksAsync(eventId, _mapper.Map<UpdatingSearchEventWithSearchTasksModel, UpdatingSearchEventWithSeacrchTasksDto>(eventModel));
            return Ok();
        }
        
        [HttpDelete("{eventId}")]
        public async Task<IActionResult> DeleteAsync(long eventId)
        {
            await _service.DeleteAsync(eventId);
            return Ok();
        }
        
        [HttpPost("list")]
        public async Task<IActionResult> GetListAsync(SearchEventFilterModel filterModel)
        {
            var filterDto = _mapper.Map<SearchEventFilterModel, SearchEventFilterDto>(filterModel);
            return Ok(_mapper.Map<List<SearchEventModel>>(await _service.GetPagedAsync(filterDto)));
        }
    }
}
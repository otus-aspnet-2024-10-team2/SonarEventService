using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Services.Abstractions;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.Contracts.SonarTask;
using WebApi.Models.SearchTask;

namespace WebApi.Controllers
{
    [ApiController]
    //[Route("[controller]")]
    [Route("api/v1/search-tasks")]
    public class SearchTaskController: ControllerBase
    {
        private readonly ISearchTaskService _service;
        private readonly ILogger<SearchTaskController> _logger;
        private readonly IMapper _mapper;

        public SearchTaskController(ISearchTaskService service, ILogger<SearchTaskController> logger, IMapper mapper)
        {
            _service = service;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet("{taskId}")]
        public async Task<IActionResult> GetAsync(long taskId, CancellationToken cancellationToken)
        {
            var sonarTaskDto = await _service.GetByIdAsync(taskId, cancellationToken);
            return Ok(_mapper.Map<SearchTaskDto, SearchTaskModel>(sonarTaskDto));
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(CreatingSearchTaskModel creatingSonarTaskDto)
        {
            return Ok(await _service.CreateAsync(_mapper.Map<CreatingSearchTaskModel, CreatingSearchTaskDto>(creatingSonarTaskDto)));
        }
        
        [HttpPut("{taskId}")]
        public async Task<IActionResult> EditAsync(int taskId, UpdatingSearchTaskModel creatingLessonDto)
        {
            await _service.UpdateAsync(taskId, _mapper.Map<UpdatingSearchTaskModel, UpdatingSearchTaskDto>(creatingLessonDto));
            return Ok();
        }
        
        [HttpDelete("{taskId}")]
        public async Task<IActionResult> DeleteAsync(int taskId)
        {
            await _service.DeleteAsync(taskId);
            return Ok();
        }
        
        [HttpGet("list/{page}/{itemsPerPage}")]
        public async Task<IActionResult> GetListAsync(int page, int itemsPerPage)
        {
            return Ok(_mapper.Map<List<SearchTaskModel>>(await _service.GetPagedAsync(page, itemsPerPage)));
        }
    }
}
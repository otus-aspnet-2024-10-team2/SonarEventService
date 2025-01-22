using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Services.Abstractions;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.Contracts.SonarTask;
using WebApi.Models.SonarTask;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SonarTaskController: ControllerBase
    {
        private readonly ISonarTaskService _service;
        private readonly ILogger<SonarTaskController> _logger;
        private readonly IMapper _mapper;

        public SonarTaskController(ISonarTaskService service, ILogger<SonarTaskController> logger, IMapper mapper)
        {
            _service = service;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id, CancellationToken cancellationToken)
        {
            var sonarTaskDto = await _service.GetByIdAsync(id, cancellationToken);
            return Ok(_mapper.Map<SonarTaskDto, SonarTaskModel>(sonarTaskDto));
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(CreatingSonarTaskModel creatingSonarTaskDto)
        {
            return Ok(await _service.CreateAsync(_mapper.Map<CreatingSonarTaskModel, CreatingSonarTaskDto>(creatingSonarTaskDto)));
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> EditAsync(int id, UpdatingSonarTaskModel creatingLessonDto)
        {
            await _service.UpdateAsync(id, _mapper.Map<UpdatingSonarTaskModel, UpdatingSonarTaskDto>(creatingLessonDto));
            return Ok();
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _service.DeleteAsync(id);
            return Ok();
        }
        
        [HttpGet("list/{page}/{itemsPerPage}")]
        public async Task<IActionResult> GetListAsync(int page, int itemsPerPage)
        {
            return Ok(_mapper.Map<List<SonarTaskModel>>(await _service.GetPagedAsync(page, itemsPerPage)));
        }
    }
}
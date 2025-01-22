using System.Collections.Generic;
using System.Threading.Tasks;
using Services.Abstractions;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.Contracts.SonarProcess;
using WebApi.Models.SonarProcess;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SonarProcessController: ControllerBase
    {
        private readonly ISonarProcessService _service;
        private readonly IMapper _mapper;
        private readonly ILogger<SonarProcessController> _logger;

        public SonarProcessController(ISonarProcessService service, ILogger<SonarProcessController> logger, IMapper mapper)
        {
            _service = service;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            return Ok(_mapper.Map<SonarProcessModel>(await _service.GetByIdAsync(id)));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreatingSonarProcessModel courseModel)
        {
            return Ok(await _service.CreateAsync(_mapper.Map<CreatingSonarProcessDto>(courseModel)));
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> EditAsync(int id, UpdatingSonarProcessModel courseModel)
        {
            await _service.UpdateAsync(id, _mapper.Map<UpdatingSonarProcessModel, UpdatingSonarProcessDto>(courseModel));
            return Ok();
        }


        //[HttpPut("WithLessons")]
        [HttpPut("WithSonarTasks")]
        public async Task<IActionResult> EditWithLessonsAsync(int id, UpdatingSonarProcessWithSonarTasksModel courseModel)
        {
            await _service.UpdatingWithSonarTasksAsync(id, _mapper.Map<UpdatingSonarProcessWithSonarTasksModel, UpdatingSonarProcessWithLSonarTasksDto>(courseModel));
            return Ok();
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _service.DeleteAsync(id);
            return Ok();
        }
        
        [HttpPost("list")]
        public async Task<IActionResult> GetListAsync(SonarProcessFilterModel filterModel)
        {
            var filterDto = _mapper.Map<SonarProcessFilterModel, SonarProcessFilterDto>(filterModel);
            return Ok(_mapper.Map<List<SonarProcessModel>>(await _service.GetPagedAsync(filterDto)));
        }
    }
}
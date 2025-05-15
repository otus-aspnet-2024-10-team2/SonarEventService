using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.Abstractions;
using Services.Contracts.SearchRequest;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WebApi.Models.SearchRequest;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/v1/search-requests")]
    public class SearchRequestsController : ControllerBase
    {
        private readonly ISearchRequestService _service;
        private readonly ILogger<SearchRequestsController> _logger;
        private readonly IMapper _mapper;

        public SearchRequestsController(ISearchRequestService service, ILogger<SearchRequestsController> logger, IMapper mapper)
        {
            _service = service;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet("{requestId}")]
        public async Task<IActionResult> GetAsync(long requestId, CancellationToken cancellationToken)
        {
            var searchRequestDto = await _service.GetByIdAsync(requestId, cancellationToken);
            return Ok(_mapper.Map<SearchRequestDto, SearchRequestModel>(searchRequestDto));
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(CreatingSearchRequestModel creatingSonarTaskDto)
        {
            return Ok(await _service.CreateAsync(_mapper.Map<CreatingSearchRequestModel, CreatingSearchRequestDto>(creatingSonarTaskDto)));
        }

        [HttpPut("{requestId}")]
        public async Task<IActionResult> EditAsync(int requestId, UpdatingSearchRequestModel creatingLessonDto)
        {
            await _service.UpdateAsync(requestId, _mapper.Map<UpdatingSearchRequestModel, UpdatingSearchRequestDto>(creatingLessonDto));
            return Ok();
        }

        [HttpDelete("{requestId}")]
        public async Task<IActionResult> DeleteAsync(int requestId)
        {
            await _service.DeleteAsync(requestId);
            return Ok();
        }

        [HttpGet("list/{page}/{itemsPerPage}")]
        public async Task<IActionResult> GetListAsync(int page, int itemsPerPage)
        {
            return Ok(_mapper.Map<List<SearchRequestModel>>(await _service.GetPagedAsync(page, itemsPerPage)));
        }
    }
}
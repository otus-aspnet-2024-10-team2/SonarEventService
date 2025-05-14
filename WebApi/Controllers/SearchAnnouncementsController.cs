using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.Abstractions;
using Services.Contracts.SearchAnnouncement;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WebApi.Models.SearchAnnouncement;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/v1/search-announcements")]
    public class SearchAnnouncementsController : ControllerBase
    {
        private readonly ISearchAnnouncementService _service;
        private readonly ILogger<SearchAnnouncementsController> _logger;
        private readonly IMapper _mapper;

        public SearchAnnouncementsController(ISearchAnnouncementService service, ILogger<SearchAnnouncementsController> logger, IMapper mapper)
        {
            _service = service;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet("{announcementId}")]
        public async Task<IActionResult> GetAsync(long announcementId, CancellationToken cancellationToken)
        {
            var searchAnnouncementDto = await _service.GetByIdAsync(announcementId, cancellationToken);
            return Ok(_mapper.Map<SearchAnnouncementDto, SearchAnnouncementModel>(searchAnnouncementDto));
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(CreatingSearchAnnouncementModel creatingSonarTaskDto)
        {
            return Ok(await _service.CreateAsync(_mapper.Map<CreatingSearchAnnouncementModel, CreatingSearchAnnouncementDto>(creatingSonarTaskDto)));
        }

        [HttpPut("{announcementId}")]
        public async Task<IActionResult> EditAsync(int announcementId, UpdatingSearchAnnouncementModel creatingLessonDto)
        {
            await _service.UpdateAsync(announcementId, _mapper.Map<UpdatingSearchAnnouncementModel, UpdatingSearchAnnouncementDto>(creatingLessonDto));
            return Ok();
        }

        [HttpDelete("{announcementId}")]
        public async Task<IActionResult> DeleteAsync(int announcementId)
        {
            await _service.DeleteAsync(announcementId);
            return Ok();
        }

        [HttpGet("list/{page}/{itemsPerPage}")]
        public async Task<IActionResult> GetListAsync(int page, int itemsPerPage)
        {
            return Ok(_mapper.Map<List<SearchAnnouncementModel>>(await _service.GetPagedAsync(page, itemsPerPage)));
        }
    }
}
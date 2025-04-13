using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.Abstractions;
using Services.Contracts.SearchGroup;
using WebApi.Models.SearchGroup;

namespace WebApi.Controllers;

/// <summary>
/// Группы поиска
/// </summary>
[ApiController]
[Route("api/v1/search-groups")]  //[controller]
public class SearchGroupsController : ControllerBase
{
    private readonly ISearchGroupService _service;
    private readonly IMapper _mapper;
    private readonly ILogger<SearchGroupsController> _logger;

    public SearchGroupsController(ISearchGroupService service, ILogger<SearchGroupsController> logger, IMapper mapper)
    {
        _service = service;
        _logger = logger;
        _mapper = mapper;
    }

    [HttpGet("{groupId}")]
    public async Task<IActionResult> GetAsync(long groupId)
    {
        return Ok(_mapper.Map<SearchGroupModel>(await _service.GetByIdAsync(groupId)));
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreatingSearchGroupModel courseModel)
    {
        return Ok(await _service.CreateAsync(_mapper.Map<CreatingSearchGroupDto>(courseModel)));
    }

    [HttpPut("{groupId}")]
    public async Task<IActionResult> EditAsync(long groupId, UpdatingSearchGroupModel courseModel)
    {
        await _service.UpdateAsync(groupId, _mapper.Map<UpdatingSearchGroupModel, UpdatingSearchGroupDto>(courseModel));
        return Ok();
    }


    [HttpDelete("{groupId}")]
    public async Task<IActionResult> DeleteAsync(long groupId)
    {
        await _service.DeleteAsync(groupId);
        return Ok();
    }

    [HttpPost("list")]
    public async Task<IActionResult> GetListAsync(SearchGroupFilterModel filterModel)
    {
        var filterDto = _mapper.Map<SearchGroupFilterModel, SearchGroupFilterDto>(filterModel);
        return Ok(_mapper.Map<List<SearchGroupModel>>(await _service.GetPagedAsync(filterDto)));
    }
}

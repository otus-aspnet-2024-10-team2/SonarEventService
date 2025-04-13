using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.Abstractions;
using Services.Contracts.GroupMember;
using WebApi.Models.GroupMember;

namespace WebApi.Controllers;

[ApiController]
[Route("api/v1/group-members")]
public class GroupMembersController : ControllerBase
{
    private readonly IGroupMemberService _service;
    private readonly IMapper _mapper;
    private readonly ILogger<GroupMembersController> _logger;

    public GroupMembersController(IGroupMemberService service, ILogger<GroupMembersController> logger, IMapper mapper)
    {
        _service = service;
        _logger = logger;
        _mapper = mapper;
    }

    [HttpGet("{memberId}")]
    public async Task<IActionResult> GetAsync(int memberId)
    {
        return Ok(_mapper.Map<GroupMemberModel>(await _service.GetByIdAsync(memberId)));
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreatingGroupMemberModel courseModel)
    {
        return Ok(await _service.CreateAsync(_mapper.Map<CreatingGroupMemberDto>(courseModel)));
    }

    [HttpPut("{memberId}")]
    public async Task<IActionResult> EditAsync(int memberId, UpdatingGroupMemberModel courseModel)
    {
        await _service.UpdateAsync(memberId, _mapper.Map<UpdatingGroupMemberModel, UpdatingGroupMemberDto>(courseModel));
        return Ok();
    }

    [HttpDelete("{memberId}")]
    public async Task<IActionResult> DeleteAsync(int memberId)
    {
        await _service.DeleteAsync(memberId);
        return Ok();
    }

    [HttpPost("list")]
    public async Task<IActionResult> GetListAsync(GroupMemberFilterModel filterModel)
    {
        var filterDto = _mapper.Map<GroupMemberFilterModel, GroupMemberFilterDto>(filterModel);
        return Ok(_mapper.Map<List<GroupMemberModel>>(await _service.GetPagedAsync(filterDto)));
    }
}

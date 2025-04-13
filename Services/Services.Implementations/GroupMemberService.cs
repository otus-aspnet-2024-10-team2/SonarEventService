using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Entities;
using Services.Abstractions;
using Services.Contracts.GroupMember;
using Services.Repositories.Abstractions;

namespace Services.Implementations;

public class GroupMemberService : IGroupMemberService
{

    private readonly IMapper _mapper;
    private readonly IGroupMemberRepository _groupMemberRepository;

    public GroupMemberService(IGroupMemberRepository groupMemberRepository,
                               IMapper mapper)
    {
        _groupMemberRepository = groupMemberRepository;
        _mapper = mapper;
    }

    public async Task<long> CreateAsync(CreatingGroupMemberDto creatingGroupMemberDto)
    {
        var groupMember = _mapper.Map<CreatingGroupMemberDto, GroupMember>(creatingGroupMemberDto);
        var createdGroupMember = await _groupMemberRepository.AddAsync(groupMember);
        await _groupMemberRepository.SaveChangesAsync();
        return createdGroupMember.Id;
    }

    public async Task DeleteAsync(long id)
    {
        var groupMember = await _groupMemberRepository.GetAsync(id, CancellationToken.None);
        var deleted = _groupMemberRepository.Delete(id);
        if (!deleted)
        {
            throw new Exception($"Участник группы поиска с идентфикатором {id} не удален!");
        }
        await _groupMemberRepository.SaveChangesAsync();
    }

    public async Task<GroupMemberDto> GetByIdAsync(long id)
    {
        var groupMember = await _groupMemberRepository.GetAsync(id, CancellationToken.None);
        return _mapper.Map<GroupMember, GroupMemberDto>(groupMember);
    }

    public async Task<ICollection<GroupMemberDto>> GetPagedAsync(GroupMemberFilterDto filterDto)
    {
        ICollection<GroupMember> entities = await _groupMemberRepository.GetPagedAsync(filterDto);
        return _mapper.Map<ICollection<GroupMember>, ICollection<GroupMemberDto>>(entities);
    }

    public async Task UpdateAsync(long id, UpdatingGroupMemberDto updatingGroupMemberDto)
    {
        var groupMember = await _groupMemberRepository.GetAsync(id, CancellationToken.None);
        if (groupMember == null)
        {
            throw new Exception($"Участник группы поиска с идентфикатором {id} не найден!");
        }
        groupMember.GroupId = updatingGroupMemberDto.GroupId;
        groupMember.UserId = updatingGroupMemberDto.UserId;
        groupMember.Role = updatingGroupMemberDto.Role;
        _groupMemberRepository.Update(groupMember);
        await _groupMemberRepository.SaveChangesAsync();
    }
}

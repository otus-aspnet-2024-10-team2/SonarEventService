using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MassTransit;
using Services.Abstractions;
using Services.Contracts.GroupMember;
using Services.Repositories.Abstractions;

namespace Services.Implementations;

public class GroupMemberService : IGroupMemberService
{

    private readonly IMapper _mapper;
    private readonly IGroupMemberRepository _groupMemberRepository;
    private readonly IUnitOfWork _unitOfWork;

    public GroupMemberService(
        IMapper mapper,
        IGroupMemberRepository groupMemberRepository)
    {
        _mapper = mapper;
        _groupMemberRepository = groupMemberRepository;
    }

    Task<long> IGroupMemberService.CreateAsync(CreatingGroupMemberDto creatingGroupMemberDto)
    {
        throw new NotImplementedException();
    }

    Task IGroupMemberService.DeleteAsync(long id)
    {
        throw new NotImplementedException();
    }

    Task<GroupMemberDto> IGroupMemberService.GetByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    Task<ICollection<GroupMemberDto>> IGroupMemberService.GetPagedAsync(GroupMemberFilterDto filterDto)
    {
        throw new NotImplementedException();
    }

    Task IGroupMemberService.UpdateAsync(long id, UpdatingGroupMemberDto updatingGroupMemberDto)
    {
        throw new NotImplementedException();
    }
}

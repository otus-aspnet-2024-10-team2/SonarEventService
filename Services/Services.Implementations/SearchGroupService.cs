﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Entities;
using Services.Abstractions;
using Services.Contracts.SearchGroup;
using Services.Repositories.Abstractions;

namespace Services.Implementations;

public class SearchGroupService : ISearchGroupService
{

    private readonly IMapper _mapper;
    private readonly ISearchGroupRepository _searchGroupRepository;

    public SearchGroupService(ISearchGroupRepository SearchGroupRepository,
                               IMapper mapper)
    {
        _searchGroupRepository = SearchGroupRepository;
        _mapper = mapper;
    }

    public async Task<long> CreateAsync(CreatingSearchGroupDto creatingSearchGroupDto)
    {
        var searchGroup = _mapper.Map<CreatingSearchGroupDto, SearchGroup>(creatingSearchGroupDto);
        searchGroup.CreatedAt = DateTime.Now;
        var createdSearchGroup = await _searchGroupRepository.AddAsync(searchGroup);
        await _searchGroupRepository.SaveChangesAsync();
        return createdSearchGroup.Id;
    }

    public async Task DeleteAsync(long id)
    {
        var searchGroup = await _searchGroupRepository.GetAsync(id, CancellationToken.None);
        var deleted = _searchGroupRepository.Delete(id);
        if (!deleted)
        {
            throw new Exception($"Группа поиска с идентфикатором {id} не удалена!");
        }
        await _searchGroupRepository.SaveChangesAsync();
    }

    public async Task<SearchGroupDto> GetByIdAsync(long id)
    {
        var searchGroup = await _searchGroupRepository.GetAsync(id, CancellationToken.None);
        return _mapper.Map<SearchGroup, SearchGroupDto>(searchGroup);
    }

    public async Task<ICollection<SearchGroupDto>> GetPagedAsync(SearchGroupFilterDto filterDto)
    {
        ICollection<SearchGroup> entities = await _searchGroupRepository.GetPagedAsync(filterDto);
        return _mapper.Map<ICollection<SearchGroup>, ICollection<SearchGroupDto>>(entities);
    }

    public async Task UpdateAsync(long id, UpdatingSearchGroupDto updatingSearchGroupDto)
    {
        var searchGroup = await _searchGroupRepository.GetAsync(id, CancellationToken.None);
        if (searchGroup == null)
        {
            throw new Exception($"Группа поиска с идентфикатором {id} не найдена!");
        }
        searchGroup.RequestId = updatingSearchGroupDto.RequestId;
        searchGroup.LeaderId = updatingSearchGroupDto.LeaderId;
        searchGroup.UpdatedAt = DateTime.Now;
        _searchGroupRepository.Update(searchGroup);
        await _searchGroupRepository.SaveChangesAsync();
    }
}

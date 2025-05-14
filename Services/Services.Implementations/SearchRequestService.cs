using AutoMapper;
using Domain.Entities;
using MassTransit;
using Services.Abstractions;
using Services.Contracts.SearchRequest;
using Services.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Implementations;

/// <summary>
/// Сервис работы с заявками на поиск
/// </summary>
public class SearchRequestService : ISearchRequestService
{
    private readonly IMapper _mapper;
    private readonly ISearchRequestRepository _searchRequestRepository;
    private readonly IBusControl _busControl;

    public SearchRequestService(
        IMapper mapper,
        ISearchRequestRepository searchRequestRepository,
        IBusControl busControl)
    {
        _mapper = mapper;
        _searchRequestRepository = searchRequestRepository;
        _busControl = busControl;
    }

    /// <summary>
    /// Получить заявку на поиск.
    /// </summary>
    /// <param name="id"> Идентификатор. </param>
    /// <param name="cancellationToken"> Токен отмены </param>
    /// <returns> ДТО заявки на поиск. </returns>
    public async Task<SearchRequestDto> GetByIdAsync(long id, CancellationToken cancellationToken)
    {
        var searchRequest = await _searchRequestRepository.GetAsync(id, cancellationToken);
        return _mapper.Map<SearchRequest, SearchRequestDto>(searchRequest);
    }

    /// <summary>
    /// Создать заявку на поиск.
    /// </summary>
    /// <param name="сreatingSearchRequestDto"> ДТО заявки на поиск. </param>
    /// <returns> Идентификатор. </returns>
    public async Task<long> CreateAsync(CreatingSearchRequestDto сreatingSearchRequestDto)
    {
        var searchRequest = _mapper.Map<CreatingSearchRequestDto, SearchRequest>(сreatingSearchRequestDto);
        var createdSearchRequest = await _searchRequestRepository.AddAsync(searchRequest);
        await _searchRequestRepository.SaveChangesAsync();
        return createdSearchRequest.Id;
    }

    /// <summary>
    /// Изменить заявку на поиск.
    /// </summary>
    /// <param name="id"> Идентификатор. </param>
    /// <param name="updatingSearchRequestDto"> ДТО заявки на поиск. </param>
    public async Task UpdateAsync(long id, UpdatingSearchRequestDto updatingSearchRequestDto)
    {
        var searchRequest = await _searchRequestRepository.GetAsync(id, CancellationToken.None);
        if (searchRequest == null)
        {
            throw new Exception($"Заявка на поиска с id = {id} не найден");
        }

        searchRequest.AnnouncementId = updatingSearchRequestDto.AnnouncementId;
        searchRequest.CoordinatorId = updatingSearchRequestDto.CoordinatorId;
        searchRequest.Description = updatingSearchRequestDto.Description;
        searchRequest.Status = updatingSearchRequestDto.Status;
        searchRequest.UpdatedAt = updatingSearchRequestDto.UpdatedAt;

        _searchRequestRepository.Update(searchRequest);
        await _searchRequestRepository.SaveChangesAsync();
    }

    /// <summary>
    /// Удалить заявку на поиск.
    /// </summary>
    /// <param name="id"> Идентификатор. </param>
    public async Task DeleteAsync(long id)
    {
        var searchRequest = await _searchRequestRepository.GetAsync(id, CancellationToken.None);
        var deleted = _searchRequestRepository.Delete(id);
        if (!deleted)
        {
            throw new Exception($"Заявка на поиск с идентфикатором {id} не удалена!");
        }
        await _searchRequestRepository.SaveChangesAsync();
    }

    /// <summary>
    /// Получить постраничный список заявок.
    /// </summary>
    /// <param name="page"> Номер страницы. </param>
    /// <param name="pageSize"> Объем страницы. </param>
    /// <returns> Страница заявок. </returns>
    public async Task<ICollection<SearchRequestDto>> GetPagedAsync(int page, int pageSize)
    {
        ICollection<SearchRequest> entities = await _searchRequestRepository.GetPagedAsync(page, pageSize);
        return _mapper.Map<ICollection<SearchRequest>, ICollection<SearchRequestDto>>(entities);
    }
}

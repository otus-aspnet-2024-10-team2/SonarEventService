using AutoMapper;
using Domain.Entities;
using MassTransit;
using Services.Abstractions;
using Services.Contracts.SearchAnnouncement;
using Services.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Implementations;

/// <summary>
/// Сервис работы с объявлениями о поиске
/// </summary>
public class SearchAnnouncementService : ISearchAnnouncementService
{
    private readonly IMapper _mapper;
    private readonly ISearchAnnouncementRepository _searchAnnouncementRepository;
    private readonly IBusControl _busControl;

    public SearchAnnouncementService(
        IMapper mapper,
        ISearchAnnouncementRepository searchAnnouncementRepository,
        IBusControl busControl)
    {
        _mapper = mapper;
        _searchAnnouncementRepository = searchAnnouncementRepository;
        _busControl = busControl;
    }

    /// <summary>
    /// Получить объявление поиска.
    /// </summary>
    /// <param name="id"> Идентификатор. </param>
    /// <param name="cancellationToken"> Токен отмены </param>
    /// <returns> ДТО объявления поиска. </returns>
    public async Task<SearchAnnouncementDto> GetByIdAsync(long id, CancellationToken cancellationToken)
    {
        var searchAnnouncement = await _searchAnnouncementRepository.GetAsync(id, cancellationToken);
        return _mapper.Map<SearchAnnouncement, SearchAnnouncementDto>(searchAnnouncement);
    }

    /// <summary>
    /// Создать объявление поиска.
    /// </summary>
    /// <param name="сreatingSearchAnnouncementDto"> ДТО объявления. </param>
    /// <returns> Идентификатор. </returns>
    public async Task<long> CreateAsync(CreatingSearchAnnouncementDto сreatingSearchAnnouncementDto)
    {
        var searchAnnouncement = _mapper.Map<CreatingSearchAnnouncementDto, SearchAnnouncement>(сreatingSearchAnnouncementDto);
        var createdSearchAnnouncement = await _searchAnnouncementRepository.AddAsync(searchAnnouncement);
        await _searchAnnouncementRepository.SaveChangesAsync();
        return createdSearchAnnouncement.Id;
    }

    /// <summary>
    /// Изменить объявление поиска.
    /// </summary>
    /// <param name="id"> Идентификатор. </param>
    /// <param name="updatingSearchAnnouncementDto"> ДТО объявления поиска. </param>
    public async Task UpdateAsync(long id, UpdatingSearchAnnouncementDto updatingSearchAnnouncementDto)
    {
        var searchAnnouncement = await _searchAnnouncementRepository.GetAsync(id, CancellationToken.None);
        if (searchAnnouncement == null)
        {
            throw new Exception($"Объявление поиска с id = {id} не найден");
        }

        searchAnnouncement.AnimalId = updatingSearchAnnouncementDto.AnimalId;
        searchAnnouncement.OwnerId = updatingSearchAnnouncementDto.OwnerId;
        searchAnnouncement.LastSeenLocation = updatingSearchAnnouncementDto.LastSeenLocation;
        searchAnnouncement.Description = updatingSearchAnnouncementDto.Description;
        searchAnnouncement.Status = updatingSearchAnnouncementDto.Status;
        searchAnnouncement.UpdatedAt = updatingSearchAnnouncementDto.UpdatedAt;

        _searchAnnouncementRepository.Update(searchAnnouncement);
        await _searchAnnouncementRepository.SaveChangesAsync();
    }

    /// <summary>
    /// Удалить объявление поиска.
    /// </summary>
    /// <param name="id"> Идентификатор. </param>
    public async Task DeleteAsync(long id)
    {
        var searchAnnouncement = await _searchAnnouncementRepository.GetAsync(id, CancellationToken.None);
        var deleted = _searchAnnouncementRepository.Delete(id);
        if (!deleted)
        {
            throw new Exception($"Объявление поиска с идентфикатором {id} не удалена!");
        }
        await _searchAnnouncementRepository.SaveChangesAsync();
    }

    /// <summary>
    /// Получить постраничный список объявлений поиска.
    /// </summary>
    /// <param name="page"> Номер страницы. </param>
    /// <param name="pageSize"> Объем страницы. </param>
    /// <returns> Страница объявлений поиска. </returns>
    public async Task<ICollection<SearchAnnouncementDto>> GetPagedAsync(int page, int pageSize)
    {
        ICollection<SearchAnnouncement> entities = await _searchAnnouncementRepository.GetPagedAsync(page, pageSize);
        return _mapper.Map<ICollection<SearchAnnouncement>, ICollection<SearchAnnouncementDto>>(entities);
    }
}

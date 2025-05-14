using System.Collections.Generic;
using System;
using Services.Contracts.SearchAnnouncement;
using Services.Contracts.User;
using Services.Contracts.SearchGroup;
using Services.Contracts.SonarProcess;

namespace Services.Contracts.SearchRequest;

public class SearchRequestDto
{
    /// <summary>
    /// Уникальный идентификатор заявки
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Идентификатор объявления, к которому относится заявка
    /// </summary>
    public long AnnouncementId { get; set; }

    /// <summary>
    /// Идентификатор координатора заявки
    /// </summary>
    public long CoordinatorId { get; set; }

    /// <summary>
    /// Описание заявки
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Статус заявки: активна / завершена / отклонена
    /// </summary>
    public string Status { get; set; }

    /// <summary>
    /// Дата создания заявки
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Дата последнего обновления
    /// </summary>
    public DateTime UpdatedAt { get; set; }

    // Навигационные свойства

    /// <summary>
    /// Объявление, к которому относится заявка
    /// </summary>
    public SearchAnnouncementDto Announcement { get; set; }

    /// <summary>
    /// Координатор заявки
    /// </summary>
    public UserDto Coordinator { get; set; }

    /// <summary>
    /// Группы поиска, связанная с этой заявкой
    /// </summary>

    public List<SearchGroupDto> Groups { get; set; } = new List<SearchGroupDto>();

    /// <summary>
    /// Мероприятия, связанные с этой заявкой
    /// </summary>
    public List<SearchEventDto> Events { get; set; } = new List<SearchEventDto>();
}

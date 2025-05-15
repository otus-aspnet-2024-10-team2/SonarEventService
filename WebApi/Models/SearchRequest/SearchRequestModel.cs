using System.Collections.Generic;
using System;
using WebApi.Models.SearchAnnouncement;
using WebApi.Models.User;
using WebApi.Models.SearchGroup;
using WebApi.Models.SearchEvent;

namespace WebApi.Models.SearchRequest;

public class SearchRequestModel
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
    public SearchAnnouncementModel Announcement { get; set; }

    /// <summary>
    /// Координатор заявки
    /// </summary>
    public UserModel Coordinator { get; set; }

    /// <summary>
    /// Группы поиска, связанная с этой заявкой
    /// </summary>

    public List<SearchGroupModel> Groups { get; set; } = new List<SearchGroupModel>();

    /// <summary>
    /// Мероприятия, связанные с этой заявкой
    /// </summary>
    public List<SearchEventModel> Events { get; set; } = new List<SearchEventModel>();
}

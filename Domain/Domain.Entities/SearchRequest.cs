using System.Collections.Generic;
using System;

namespace Domain.Entities;


/// <summary>
/// Сущность заявки на поиск животного
/// </summary>
public class SearchRequest : IEntity<long>
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
    public virtual SearchAnnouncement Announcement { get; set; }

    /// <summary>
    /// Координатор заявки
    /// </summary>
    public virtual User Coordinator { get; set; }

    /// <summary>
    /// Группы поиска, связанная с этой заявкой
    /// </summary>

    public virtual List<SearchGroup> Groups { get; set; } = new List<SearchGroup>();

    /// <summary>
    /// Мероприятия, связанные с этой заявкой
    /// </summary>
    public virtual List<SearchEvent> Events { get; set; } = new List<SearchEvent>();
}

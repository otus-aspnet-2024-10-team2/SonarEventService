using System.Collections.Generic;
using System;

namespace Domain.Entities;

/// <summary>
/// Сущность объявления о поиске животного
/// </summary>
public class SearchAnnouncement : IEntity<long>
{
    /// <summary>
    /// Уникальный идентификатор объявления
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Идентификатор животного, связанного с объявлением
    /// </summary>
    public long AnimalId { get; set; }

    /// <summary>
    /// Идентификатор владельца, создавшего объявление
    /// </summary>
    public long OwnerId { get; set; }

    /// <summary>
    /// Описание объявления (1024 знаков)
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Последнее известное место нахождения (500 знаков)
    /// </summary>
    public string LastSeenLocation { get; set; }

    /// <summary>
    /// Статус объявления: активен / завершен / отклонен
    /// </summary>
    public string Status { get; set; }

    /// <summary>
    /// Дата создания объявления
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Дата последнего обновления
    /// </summary>
    public DateTime UpdatedAt { get; set; }

    // Навигационные свойства

    /// <summary>
    /// Животное, связанное с объявлением
    /// </summary>
    public virtual Animal Animal { get; set; }

    /// <summary>
    /// Владелец объявления
    /// </summary>
    public virtual User Owner { get; set; }

    /// <summary>
    /// Заявки, связанные с этим объявлением
    /// </summary>
    public virtual List<SearchRequest> SearchRequests { get; set; } = new List<SearchRequest>();
}
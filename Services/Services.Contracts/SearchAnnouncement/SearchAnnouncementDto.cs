using Services.Contracts.Animal;
using Services.Contracts.SearchRequest;
using Services.Contracts.User;
using System;
using System.Collections.Generic;

namespace Services.Contracts.SearchAnnouncement;

public class SearchAnnouncementDto
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
    /// Дата создания задачи
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Дата последнего обновления задачи
    /// </summary>
    public DateTime UpdatedAt { get; set; }

    /// <summary>
    /// Животное, связанное с объявлением
    /// </summary>
    public AnimalDto Animal { get; set; }

    /// <summary>
    /// Владелец объявления
    /// </summary>
    public UserDto Owner { get; set; }

    /// <summary>
    /// Заявки, связанные с этим объявлением
    /// </summary>
    //public List<SearchRequestDto> SearchRequests { get; set; } = new List<SearchRequestDto>();
}

using System.Collections.Generic;
using System;

namespace Domain.Entities;

/// <summary>
/// Сущность животного
/// </summary>
public class Animal : IEntity<long>
{
    /// <summary>
    /// Уникальный идентификатор животного
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Имя животного
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Вид животного (например: кошка, собака)
    /// </summary>
    public string Species { get; set; }

    /// <summary>
    /// Порода животного
    /// </summary>
    public string Breed { get; set; }

    /// <summary>
    /// Цвет / окрас животного
    /// </summary>
    public string Color { get; set; }

    /// <summary>
    /// Номер чипа животного
    /// </summary>
    public string ChipNumber { get; set; }

    /// <summary>
    /// Идентификатор владельца (пользователя)
    /// </summary>
    public long OwnerId { get; set; }

    /// <summary>
    /// Последнее известное место нахождения
    /// </summary>
    public string LastSeenLocation { get; set; }

    /// <summary>
    /// Описание особенностей животного
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Ссылка на фото животного
    /// </summary>
    public string PhotoUrl { get; set; }

    /// <summary>
    /// Дата создания записи
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Дата последнего обновления
    /// </summary>
    public DateTime UpdatedAt { get; set; }

    // Навигационные свойства

    /// <summary>
    /// Владелец животного
    /// </summary>
    public virtual User Owner { get; set; }

    /// <summary>
    /// Объявления о поиске, связанные с этим животным
    /// </summary>
    public virtual List<SearchAnnouncement> SearchAnnouncements { get; set; } = new List<SearchAnnouncement>();
}
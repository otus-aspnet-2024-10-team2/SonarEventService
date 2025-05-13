using System.Collections.Generic;
using System;

namespace Domain.Entities;

/// <summary>
/// Сущность пользователя системы
/// </summary>
public class User : IEntity<long>
{
    /// <summary>
    /// Уникальный идентификатор пользователя
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Логин пользователя (уникален)
    /// </summary>
    public string Username { get; set; }

    /// <summary>
    /// Краткое имя пользователя (например: "Ваня")
    /// </summary>
    public string ShortName { get; set; }

    /// <summary>
    /// Полное имя пользователя
    /// </summary>
    public string FullName { get; set; }

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
    /// Животные, принадлежащие пользователю
    /// </summary>
    public virtual List<Animal> Animals { get; set; } = new List<Animal>();

    /// <summary>
    /// Объявления о поиске, созданные пользователем
    /// </summary>
    public virtual List<SearchAnnouncement> SearchAnnouncements { get; set; } = new List<SearchAnnouncement>();

    /// <summary>
    /// Заявки на поиск, которыми управляет пользователь (как координатор)
    /// </summary>
    public virtual List<SearchRequest> CoordinatedRequests { get; set; } = new List<SearchRequest>();

    /// <summary>
    /// Группы поиска, возглавляемые пользователем
    /// </summary>
    public virtual List<SearchGroup> LedGroups { get; set; } = new List<SearchGroup>();

    /// <summary>
    /// Мероприятия, созданные пользователем
    /// </summary>
    public virtual List<SearchEvent> CreatedEvents { get; set; } = new List<SearchEvent>();

    /// <summary>
    /// Задачи, назначенные пользователю
    /// </summary>
    public virtual List<SearchTask> AssignedTasks { get; set; } = new List<SearchTask>();

    /// <summary>
    /// Членство пользователя в поисковых группах
    /// </summary>
    public virtual List<GroupMember> GroupMemberships { get; set; } = new List<GroupMember>();
}
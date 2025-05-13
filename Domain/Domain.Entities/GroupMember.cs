using System;
using System.Collections.Generic;

namespace Domain.Entities;


/// <summary>
/// Сущность участника поисковой группы
/// </summary>
public class GroupMember : IEntity<long>
{
    /// <summary>
    /// Уникальный идентификатор участника группы
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Идентификатор группы, к которой относится участник
    /// </summary>
    public long GroupId { get; set; }

    /// <summary>
    /// Идентификатор пользователя — участника группы
    /// </summary>
    public long UserId { get; set; }

    /// <summary>
    /// Роль пользователя в группе (например: лидер, доброволец) (50 знаков)
    /// </summary>
    public string Role { get; set; }

    /// <summary>
    /// Дата добавления пользователя в группу
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Дата последнего обновления записи
    /// </summary>
    public DateTime UpdatedAt { get; set; }

    // Навигационные свойства

    /// <summary>
    /// Поисковая группа, к которой относится участник
    /// </summary>
    public virtual SearchGroup Group { get; set; }

    /// <summary>
    /// Пользователь — участник группы
    /// </summary>
    public virtual User User { get; set; }
}


///// <summary>
///// Участник группы поиска
///// </summary>
//public class GroupMember : IEntity<long>
//{
//    public long Id { get; set; }
//    public long GroupId { get; set; }
//    public virtual SearchGroup Group { get; set; }
//    public long UserId { get; set; }
//    public virtual SearchUser User { get; set; }
//    public string Role { get; set; }
//    public DateTime CreatedAt { get; set; }
//    public DateTime UpdatedAt { get; set; }
//}

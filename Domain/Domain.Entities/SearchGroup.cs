using System;
using System.Collections.Generic;

namespace Domain.Entities;



/// <summary>
/// Сущность поисковой группы
/// </summary>
public class SearchGroup : IEntity<long>
{
    /// <summary>
    /// Уникальный идентификатор группы
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Идентификатор заявки, к которой относится группа
    /// </summary>
    public long RequestId { get; set; }

    /// <summary>
    /// Идентификатор лидера группы
    /// </summary>
    public long LeaderId { get; set; }

    /// <summary>
    /// Дата создания группы
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Дата последнего обновления
    /// </summary>
    public DateTime UpdatedAt { get; set; }

    // Навигационные свойства

    /// <summary>
    /// Заявка, к которой относится группа
    /// </summary>
    public virtual SearchRequest Request { get; set; }

    /// <summary>
    /// Лидер группы
    /// </summary>
    public virtual User Leader { get; set; }

    /// <summary>
    /// Участники группы
    /// </summary>
    public virtual List<GroupMember> Members { get; set; } = new List<GroupMember>();
}



//public class SearchGroup : IEntity<long>
//{
//    public long Id { get; set; }
//    public long RequestId { get; set; }
//    public virtual SearchRequest Request { get; set; }
//    public long LeaderId { get; set; }
//    public virtual SearchLeader Leader { get; set; }
//    public DateTime CreatedAt { get; set; }
//    public DateTime UpdatedAt { get; set; }
//    public virtual ICollection<GroupMember> Members { get; set; }
//    public virtual ICollection<SearchTask> Tasks { get; set; }

//}

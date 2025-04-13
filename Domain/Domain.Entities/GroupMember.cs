using System;
using System.Collections.Generic;

namespace Domain.Entities;

/// <summary>
/// Участник группы поиска
/// </summary>
public class GroupMember : IEntity<long>
{
    public long Id { get; set; }
    public long GroupId { get; set; }
    public long UserId { get; set; }
    public string Role { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public virtual ICollection<SearchGroup> Groups { get; set; }
    public virtual SearchUser User { get; set; }
    


}

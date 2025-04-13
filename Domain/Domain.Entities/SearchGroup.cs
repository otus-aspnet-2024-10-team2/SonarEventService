using System;
using System.Collections.Generic;

namespace Domain.Entities;

public class SearchGroup : IEntity<long>
{
    public long Id { get; set; }
    public long RequestId { get; set; }
    public long LeaderId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public virtual SearchRequest SearchRequest { get; set; }
    public virtual SearchLeader Leader { get; set; }
    public virtual ICollection<GroupMember> Members { get; set; }
    public virtual ICollection<SearchTask> Tasks { get; set; }

}

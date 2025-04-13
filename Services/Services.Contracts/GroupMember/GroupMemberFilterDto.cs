namespace Services.Contracts.GroupMember;

public class GroupMemberFilterDto
{
    public long GroupId { get; set; }
    public long UserId { get; set; }

    public int ItemsPerPage { get; set; }

    public int Page { get; set; }
}

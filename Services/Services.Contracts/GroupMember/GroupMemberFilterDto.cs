namespace Services.Contracts.GroupMember;

public class GroupMemberFilterDto
{
    public int GroupId { get; set; }
    public int UserId { get; set; }

    public int ItemsPerPage { get; set; }

    public int Page { get; set; }
}

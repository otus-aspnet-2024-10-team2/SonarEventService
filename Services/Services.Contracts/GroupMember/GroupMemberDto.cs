namespace Services.Contracts.GroupMember;

public class GroupMemberDto
{
    public long MemberId { get; set; }
    public long GroupId { get; set; }
    public long UserId { get; set; }
    public string Role { get; set; }
}

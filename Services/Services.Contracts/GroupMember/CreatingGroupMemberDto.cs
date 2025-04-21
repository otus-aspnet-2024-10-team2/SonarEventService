namespace Services.Contracts.GroupMember;

public class CreatingGroupMemberDto
{
    public long GroupId { get; set; }
    public long UserId { get; set; }
    public string Role { get; set; }
}

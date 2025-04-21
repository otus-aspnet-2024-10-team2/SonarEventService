namespace Services.Contracts.GroupMember;

public class UpdatingGroupMemberDto
{
    public long GroupId { get; set; }
    public long UserId { get; set; }
    public string Role { get; set; }
}

namespace Services.Contracts.GroupMember;

public class CreatingGroupMemberDto
{
    public int GroupId { get; set; }
    public int UserId { get; set; }
    public string Role { get; set; }
}

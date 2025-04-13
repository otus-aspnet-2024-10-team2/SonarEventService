namespace Services.Contracts.GroupMember;

public class GroupMemberDto
{
    public int MemberId { get; set; }
    public int GroupId { get; set; }
    public int UserId { get; set; }
    public string Role { get; set; }
}

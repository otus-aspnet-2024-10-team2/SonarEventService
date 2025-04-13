namespace WebApi.Models.GroupMember;

public class CreatingGroupMemberModel
{
    public int GroupId { get; set; }
    public int UserId { get; set; }
    public string Role { get; set; }
}

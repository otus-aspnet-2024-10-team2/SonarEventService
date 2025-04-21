namespace WebApi.Models.GroupMember;

public class UpdatingGroupMemberModel
{
    public int GroupId { get; set; }
    public int UserId { get; set; }
    public string Role { get; set; }
}

namespace WebApi.Models.GroupMember;

public class GroupMemberFilterModel
{
    public int GroupId { get; set; }
    public int UserId { get; set; }
    public string Role { get; set; }
    public int ItemsPerPage { get; set; }

    public int Page { get; set; }
}

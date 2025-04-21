namespace WebApi.Models.GroupMember;

/// <summary>
/// Модель Участник группы поиска
/// </summary>
public class GroupMemberModel
{
    public int MemberId { get; set; }
    public int GroupId { get; set; }
    public int UserId { get; set; }
    public string Role { get; set; }
}
namespace Services.Contracts.SearchGroup;

/// <summary>
/// DTO группы поиска
/// </summary>
public class SearchGroupDto
{
    public long GroupId { get; set; }
    public long RequestId { get; set; }
    public long LeaderId { get; set; }
}
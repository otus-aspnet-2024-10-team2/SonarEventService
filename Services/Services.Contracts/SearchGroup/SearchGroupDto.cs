namespace Services.Contracts.SearchGroup;

/// <summary>
/// DTO группы поиска
/// </summary>
public class SearchGroupDto
{
    public int GroupId { get; set; }
    public int RequestId { get; set; }
    public int LeaderId { get; set; }
}
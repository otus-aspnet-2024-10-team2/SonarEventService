namespace WebApi.Models.SearchGroup;

/// <summary>
/// Модель группы поиска
/// </summary>
public class SearchGroupModel
{
    public int GroupId { get; set; }
    public int RequestId { get; set; }
    public int LeaderId { get; set; }
}
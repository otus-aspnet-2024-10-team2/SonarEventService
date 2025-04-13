namespace Services.Contracts.SearchGroup;

public class SearchGroupFilterDto
{
    public int RequestId { get; set; }
    public int LeaderId { get; set; }

    public int ItemsPerPage { get; set; }

    public int Page { get; set; }
}

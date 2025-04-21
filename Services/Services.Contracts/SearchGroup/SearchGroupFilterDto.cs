namespace Services.Contracts.SearchGroup;

public class SearchGroupFilterDto
{
    public long RequestId { get; set; }
    public long LeaderId { get; set; }

    public int ItemsPerPage { get; set; }

    public int Page { get; set; }
}

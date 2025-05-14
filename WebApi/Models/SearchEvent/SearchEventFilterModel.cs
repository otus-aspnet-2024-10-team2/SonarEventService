namespace WebApi.Models.SearchEvent;

public class SearchEventFilterModel
{
    public string Status { get; set; }

    public int ItemsPerPage { get; set; }

    public int Page { get; set; }
}
namespace WebApi.Models.SearchEvent;

public class SearchEventFilterModel
{
    public string Name { get; set; }

    //public decimal? Price { get; set; }

    public int ItemsPerPage { get; set; }

    public int Page { get; set; }
}
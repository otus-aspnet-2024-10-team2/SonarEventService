namespace Services.Contracts.SonarProcess;

public class SearchEventFilterDto
{
    public string Name { get; set; }

    //public decimal? Price { get; set; }

    public int ItemsPerPage { get; set; }

    public int Page { get; set; }
}
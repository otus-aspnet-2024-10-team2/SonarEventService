namespace Services.Contracts.SonarProcess;

public class SearchEventFilterDto
{
    public string Status { get; set; }

    public int ItemsPerPage { get; set; }

    public int Page { get; set; }
}
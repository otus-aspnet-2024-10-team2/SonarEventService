namespace WebApi.Models.SonarProcess;

public class SonarProcessFilterModel
{
    public string Name { get; set; }

    //public decimal? Price { get; set; }

    public int ItemsPerPage { get; set; }

    public int Page { get; set; }
}
namespace Domain.Entities;

/// <summary>
/// Запрос на поиск
/// </summary>
public class SearchRequest : IEntity<long>
{
    public long Id { get; set; }

    //TODO: Other properties
}

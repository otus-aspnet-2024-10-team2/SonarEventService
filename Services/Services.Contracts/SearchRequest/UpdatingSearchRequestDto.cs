using System;

namespace Services.Contracts.SearchRequest;

public class UpdatingSearchRequestDto
{
    /// <summary>
    /// Идентификатор объявления, к которому относится заявка
    /// </summary>
    public long AnnouncementId { get; set; }

    /// <summary>
    /// Идентификатор координатора заявки
    /// </summary>
    public long CoordinatorId { get; set; }

    /// <summary>
    /// Описание заявки
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Статус заявки: активна / завершена / отклонена
    /// </summary>
    public string Status { get; set; }

    /// <summary>
    /// Дата последнего обновления
    /// </summary>
    public DateTime UpdatedAt { get; set; }
}

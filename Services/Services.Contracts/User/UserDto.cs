using System;

namespace Services.Contracts.User;

public class UserDto
{
    /// <summary>
    /// Уникальный идентификатор пользователя
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Логин пользователя (уникален)
    /// </summary>
    public string Username { get; set; }

    /// <summary>
    /// Краткое имя пользователя (например: "Ваня")
    /// </summary>
    public string ShortName { get; set; }

    /// <summary>
    /// Полное имя пользователя
    /// </summary>
    public string FullName { get; set; }

    /// <summary>
    /// Дата создания записи
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Дата последнего обновления
    /// </summary>
    public DateTime UpdatedAt { get; set; }
}

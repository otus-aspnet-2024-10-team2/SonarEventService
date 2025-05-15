using System;

namespace Services.Contracts.User;

public class CreatingUserDto
{
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
}

﻿using System;

namespace WebApi.Models.User;

public class UpdatingUserModel
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

    /// <summary>
    /// Дата последнего обновления
    /// </summary>
    public DateTime UpdatedAt { get; set; }
}

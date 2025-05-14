using System;
using WebApi.Models.User;

namespace WebApi.Models.Animal;

public class AnimalModel
{
    /// <summary>
    /// Уникальный идентификатор животного
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Имя животного (50 знаков)
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Вид животного (например: кошка, собака) (50 знаков)
    /// </summary>
    public string Species { get; set; }

    /// <summary>
    /// Порода животного (50 знаков)
    /// </summary>
    public string Breed { get; set; }

    /// <summary>
    /// Цвет / окрас животного (50 знаков)
    /// </summary>
    public string Color { get; set; }

    /// <summary>
    /// Номер чипа животного
    /// </summary>
    public string ChipNumber { get; set; }

    /// <summary>
    /// Идентификатор владельца (пользователя)
    /// </summary>
    public long OwnerId { get; set; }

    /// <summary>
    /// Последнее известное место нахождения (500 знаков)
    /// </summary>
    public string LastSeenLocation { get; set; }

    /// <summary>
    /// Описание особенностей животного (1024 знака)
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Ссылка на фото животного (1024 знака)
    /// </summary>
    public string PhotoUrl { get; set; }

    /// <summary>
    /// Дата создания записи
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Дата последнего обновления
    /// </summary>
    public DateTime UpdatedAt { get; set; }

    /// <summary>
    /// Владелец животного
    /// </summary>
    public UserModel Owner { get; set; }
}

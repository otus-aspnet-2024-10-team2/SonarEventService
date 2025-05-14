using System;

namespace WebApi.Models.Animal;

public class UpdatingAnimalModel
{
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
    /// Дата последнего обновления
    /// </summary>
    public DateTime UpdatedAt { get; set; }
}

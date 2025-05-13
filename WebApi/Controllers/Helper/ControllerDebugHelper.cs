using System;
using System.Collections.Generic;
using WebApi.Models.SearchEvent;
using WebApi.Models.SearchTask;

namespace WebApi.Controllers.Helper
{
    public static class ControllerDebugHelper
    {
        internal static SearchEventModel GetTestSearchEventModel()
        {
            var testSearchEvent = new SearchEventModel
            {
                Id = 1L,
                RequestId = 101L,
                CreatedByUserId = 5L,
                Description = "Поиск пропавшей собаки породы лабрадор в районе парка Горького",
                Location = "Парк Горького, Москва",
                Status = "в процессе",
                StartTime = new DateTime(2025, 4, 5, 10, 0, 0),
                EndTime = new DateTime(2025, 4, 5, 14, 0, 0),
                CreatedAt = new DateTime(2025, 4, 1, 15, 30, 0),
                UpdatedAt = new DateTime(2025, 4, 3, 9, 15, 0),
                Tasks = new List<SearchTaskModel>
                {
                    //new SearchTaskModel
                    //{
                    //    Id = 1001L,
                    //    EventId = 1L,
                    //    AssignedToUserId = 7L,
                    //    Title = "Обзвон приютов",
                    //    Description = "Позвонить в 10 ближайших приютов и уточнить информацию о животных",
                    //    Status = "в процессе",
                    //    CreatedAt = new DateTime(2025, 4, 1, 16, 0, 0),
                    //    UpdatedAt = new DateTime(2025, 4, 3, 10, 0, 0)
                    //},
                    //new SearchTaskModel
                    //{
                    //    Id = 1002L,
                    //    EventId = 1L,
                    //    AssignedToUserId = 8L,
                    //    Title = "Расклеивание объявлений",
                    //    Description = "Разместить объявления в районе метро 'Парк Горького'",
                    //    Status = "назначена",
                    //    CreatedAt = new DateTime(2025, 4, 2, 11, 0, 0),
                    //    UpdatedAt = new DateTime(2025, 4, 2, 11, 0, 0)
                    //}
                }
            };
            return testSearchEvent;
        }
    }
}

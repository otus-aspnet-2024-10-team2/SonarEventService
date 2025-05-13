-- Скрипты для создания таблиц




-- ###################### Пользователи - Users

-- DROP TABLE Users
CREATE TABLE Users (
    Id INTEGER PRIMARY KEY NOT NULL,				-- Уникальный идентификатор пользователя
    Username TEXT NOT NULL UNIQUE,					-- Логин пользователя
    ShortName TEXT,									-- Краткое имя (пример: Ваня)
    FullName TEXT,									-- Полное имя пользователя
    CreatedAt DATETIME DEFAULT CURRENT_TIMESTAMP,	-- Дата и время создания записи
    UpdatedAt DATETIME DEFAULT CURRENT_TIMESTAMP	-- Дата и время последнего обновления
);

-- Добавляем данные
-- select * from Users 
INSERT INTO Users (Id, Username, ShortName, FullName, CreatedAt, UpdatedAt) VALUES
(1, 'john_doe', 'John', 'John Doe', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP),
(2, 'jane_smith', 'Jane', 'Jane Smith', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP),
(3, 'alex_m', 'Alex', 'Alexander Morgan', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP),
(4, 'anna_k', 'Anna', 'Anna Kim', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP),
(5, 'mike_w', 'Mike', 'Michael White', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP),
(6, 'sarah_j', 'Sarah', 'Sarah Johnson', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP),
(7, 'david_t', 'David', 'David Taylor', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP),
(8, 'lisa_r', 'Lisa', 'Lisa Rodriguez', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP),
(9, 'chris_p', 'Chris', 'Christopher Parker', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP),
(10, 'emily_h', 'Emily', 'Emily Harris', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP);

INSERT INTO Users (Id, Username, ShortName, FullName, CreatedAt, UpdatedAt) VALUES
(11, 'coordinator', 'Coord.', 'Coordinator', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP);

INSERT INTO Users (Id, Username, ShortName, FullName, CreatedAt, UpdatedAt) VALUES
(12, 'vol1', 'Ваня П.', 'Иван Петров', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP),
(13, 'vol2', 'Дима С.', 'Дмитрий Смирнов', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP),
(14, 'vol3', 'Артем К.', 'Артём Кузнецов', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP),
(15, 'vol4', 'Максим В.', 'Максим Волков', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP),
(16, 'vol5', 'Никита И.', 'Никита Иванов', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP),
(17, 'vol6', 'Аня С.', 'Анна Сергеева', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP),
(18, 'vol7', 'Катя А.', 'Екатерина Андреева', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP),
(19, 'vol8', 'Ольга П.', 'Ольга Петрова', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP),
(20, 'vol9', 'Таня С.', 'Татьяна Соколова', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP);


-- ###################### Питомцы - Animals 

-- DROP TABLE Animals 
-- select * from Animals 
CREATE TABLE Animals (
    Id INTEGER PRIMARY KEY AUTOINCREMENT, -- Идентификатор животного
    Name TEXT,									-- Имя животного
    Species TEXT,								-- Вид животного (например: собака, кошка)
    Breed TEXT,									-- Порода
    Color TEXT,									-- Цвет (окрас)
    ChipNumber TEXT,							-- Номер чипа
    OwnerId INTEGER,							-- Владелец (Ссылка на Users)
	LastSeenLocation TEXT,						-- Последнее известное место
    Description TEXT,							-- Описание (особые приметы, особенности)
    PhotoUrl TEXT,								-- Ссылка на фото
    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP,	-- Дата создания записи
    UpdatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP,	-- Дата последнего обновления записи
    FOREIGN KEY (OwnerId) REFERENCES Users(Id) ON DELETE SET NULL
);
--- ИНДЕКСЫ
CREATE INDEX IX_Animals_OwnerId ON Animals(OwnerId);

-- ДЕМО ДАННЫЕ: select * from Animals
-- Добавляем животных для пользователя с Id = 1 (john_doe)
INSERT INTO Animals (Name, Species, Breed, Color, ChipNumber, OwnerId, LastSeenLocation, Description, PhotoUrl)
VALUES 
('Мурка', 'Кошка', 'Персидская', 'Белая', 'CHIP0002', 1, 'Дом рядом с метро', 'Любит играть с мячом', 'https://example.com/photo2.jpg '),
('Рекс', 'Собака', 'Терьер', 'Серый', 'CHIP0003', 2, 'Центральный район', 'Очень активный', 'https://example.com/photo3.jpg '),
('Снежок', 'Кролик', 'Русский белый', 'Белый', 'CHIP0006', 3, 'Сад у дома', 'Очень пушистый', 'https://example.com/photo6.jpg '),
('Барсик', 'Кот', 'Сиамский', 'Темно-серый', 'CHIP0008', 4, 'Квартира на проспекте', 'Громко мяукает', 'https://example.com/photo8.jpg '),
('Феня', 'Свинья', 'Мини-пиг', 'Розоватая', 'CHIP0010', 5, 'Дача на окраине', 'Очень умная', 'https://example.com/photo10.jpg '),
('Снежана', 'Кошка', 'Мейн-кун', 'Серая полосатая', 'CHIP0012', 6, 'Квартира на 5 этаже', 'Очень большая порода', 'https://example.com/photo12.jpg '),
('Феликс', 'Кот', 'Бенгальский', 'Рыжий с пятнами', 'CHIP0014', 7, 'Офис компании', 'Не переносит шума', 'https://example.com/photo14.jpg '),
('Лютик', 'Кролик', 'Голландский', 'Белый с черным пятном на лбу', 'CHIP0015', 8, 'Детский парк', 'Маленький и проворный', 'https://example.com/photo15.jpg '),
('Джек', 'Собака', 'Пудель', 'Белый', 'CHIP0017', 9, 'Сквер возле школы', 'Обучаемый, выполняет команды', 'https://example.com/photo17.jpg '),
('Чарли', 'Кошка', 'Шотландская вислоухая', 'Серая', 'CHIP0020', 10, 'Балкон', 'Очень милая и ласковая', 'https://example.com/photo20.jpg ');



-- ###################### SearchAnnouncements - Таблица для хранения объявлений о поиске.

-- DROP TABLE SearchAnnouncements 
CREATE TABLE SearchAnnouncements (
    Id INTEGER PRIMARY KEY AUTOINCREMENT, 	-- Уникальный идентификатор объявления (первичный ключ, автоинкремент)
    AnimalId INTEGER,						-- Идентификатор животного, на которое создано объявление (ссылка на таблицу
    OwnerId INTEGER,						-- Идентификатор владельца животного (ссылка на таблицу)
    Description TEXT,						-- Описание объявления (например: "Пропал кот Мурка")
    LastSeenLocation VARCHAR(255),			-- Последнее известное место, где видели животное
    Status VARCHAR(50) NOT NULL DEFAULT 'активен', -- например: "активен", "завершен", "отклонен"
    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    UpdatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (AnimalId) REFERENCES Animals(Id) ON DELETE SET NULL,
    FOREIGN KEY (OwnerId) REFERENCES Users(Id) ON DELETE CASCADE
);
-- ИНДЕКСЫ
CREATE INDEX IX_SearchAnnouncements_OwnerId ON SearchAnnouncements(OwnerId);
CREATE INDEX IX_SearchAnnouncements_Status ON SearchAnnouncements(Status);

-- select * from SearchAnnouncements 
-- Демо данные в таблице
-- Добавляем объявления о поиске с разными статусами
-- DROP TABLE SearchAnnouncements
INSERT INTO SearchAnnouncements (AnimalId, OwnerId, Description, LastSeenLocation, Status)
VALUES
-- Активные объявления
(1, 1, 'Пропала кошка Мурка. Просьба помочь найти!', 'Дом рядом с метро', 'активен'),
(2, 2, 'Ищем собаку Рекса. Очень активный питомец.', 'Центральный район', 'активен'),
(5, 5, 'Свинья Феня пропала с дачи на окраине.', 'Дача на окраине', 'активен'),
(7, 7, 'Кот Феликс ушёл из офиса. Не переносит шума.', 'Офис компании', 'активен'),
(9, 9, 'Пудель Джек пропал со сквера возле школы.', 'Сквер возле школы', 'активен'),
(10, 10, 'Кошка Чарли ушла с балкона. Очень ласковая.', 'Балкон', 'активен'),

-- Завершённые объявления (животное найдено)
(3, 3, 'Кролик Снежок ушел, но уже найден.', 'Сад у дома', 'завершен'),
(6, 6, 'Кошка Снежана потерялась, но позже вернулась домой.', 'Квартира на 5 этаже', 'завершен'),

-- Отклонённые объявления (например, некорректные или отменённые)
(4, 4, 'Кот Барсик потерялся, но информация оказалась ошибочной.', 'Квартира на проспекте', 'отклонен'),
(8, 8, 'Кролик Лютик потерялся, но данные были неполными.', 'Детский парк', 'отклонен');




-- ###################### SearchRequests - Таблица для хранения заявок на поиск. 
-- DROP TABLE SearchRequests 
CREATE TABLE SearchRequests (
    Id INTEGER PRIMARY KEY AUTOINCREMENT, 			-- Уникальный идентификатор заявки
    AnnouncementId INTEGER,							-- Идентификатор объявления о поиске
    CoordinatorId INTEGER, 							-- Идентификатор координатора (пользователя) 
    Description TEXT,								-- Описание заявки в дополненении к обьявлению
    Status VARCHAR(50) NOT NULL DEFAULT 'активен', 	-- Статус заявки (например: "активен", "завершен", "приостановлен", "отменен")
    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP,  -- Дата и время создания заявки
    UpdatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP,  -- Дата и время последнего обновления

    -- Внешние ключи (в SQLite ссылки нужно указывать отдельно через FOREIGN KEY)
    FOREIGN KEY (AnnouncementId) REFERENCES SearchAnnouncements(Id) ON DELETE CASCADE,
    FOREIGN KEY (CoordinatorId) REFERENCES Users(Id) ON DELETE SET NULL
);
-- индексы
CREATE INDEX IX_SearchRequests_AnnouncementId ON SearchRequests(AnnouncementId);
CREATE INDEX IX_SearchRequests_CoordinatorId ON SearchRequests(CoordinatorId);
CREATE INDEX IX_SearchRequests_Status ON SearchRequests(Status);


-- Заявки по активным объявлениям Демо данные
-- select * from SearchRequests
-- select * from SearchAnnouncements

INSERT INTO SearchRequests (AnnouncementId, CoordinatorId, Description, Status)
VALUES
(1, 11, 'Поиск#1 кошки Мурка', 'активен'),
(2, 11, 'Поиск#2  собаки Рекса', 'активен'),
(3, 11, 'Поиск#3  кролика Снежка', 'завершен'),
(4, 11, 'Поиск#4  кота Феликса в офисе', 'активен'),
(5, 11, 'Поиск#5  пуделя Джека', 'активен'),
(6, 11, 'Поиск#6  Чарли', 'активен'),
(7, 11, 'Поиск#7 Снежаны', 'завершен'),
(8, 11, 'Поиск#8 - Ошибка в объявлении — данные неполные', 'отклонен'),
(9, 11, 'Поиск#9', 'активен'),
(10, 11, 'Поиск#10 - Нет возможности участвовать, мало информации', 'отклонен');


-- ###################### SearchGroups - Таблица для хранения групп поиска. 
-- drop table SearchGroups
CREATE TABLE SearchGroups (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,		-- Уникальный идентификатор группы
    RequestId INTEGER,							-- Ссылка на заявку (SearchRequests.Id)
    LeaderId INTEGER,							-- Идентификатор лидера группы (пользователь, участвующий в поиске)
    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP, -- Дата время создания группы
    UpdatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP, -- Дата последнего обновления

    -- Внешние ключи
    FOREIGN KEY (RequestId) REFERENCES SearchRequests(Id) ON DELETE CASCADE,
    FOREIGN KEY (LeaderId) REFERENCES Users(Id) ON DELETE SET NULL
);
-- Индексы
CREATE INDEX IX_SearchGroups_RequestId ON SearchGroups(RequestId);
CREATE INDEX IX_SearchGroups_LeaderId ON SearchGroups(LeaderId);

-- ДЕМО ДАННЫЕ
-- select * from SearchGroups
--		-- select * from SearchRequests --смотрим запросы поиска
-- Добавляем демо-данные в таблицу SearchGroups
INSERT INTO SearchGroups (RequestId, LeaderId)
VALUES
(1, 12),
(2, 15),
(3, 12),
(4, 15),
(5, 12),
(6, 15),
(7, 12),
(8, 15),
(9, 12),
(10, 15);

-- ###################### GroupMembers - Таблица для хранения участников групп поиска.
-- DROP TABLE GroupMembers
CREATE TABLE GroupMembers (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,		-- Уникальный ID участника группы
    GroupId INTEGER,							-- Ссылка на группу (
    UserId INTEGER,								-- Ссылка на пользователя (
    Role VARCHAR(50),							-- Роль в группе (например: "volunteer", "leader")
    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP, -- Дата создания записи
    UpdatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP, -- Дата последнего обновления

    -- Внешние ключи
    FOREIGN KEY (GroupId) REFERENCES SearchGroups(Id) ON DELETE CASCADE,
    FOREIGN KEY (UserId) REFERENCES Users(Id) ON DELETE CASCADE
);
-- Индексы 
CREATE INDEX IX_GroupMembers_UserId ON GroupMembers(UserId);
CREATE INDEX IX_GroupMembers_GroupId ON GroupMembers(GroupId);
-- ДЕМО ДАННЫЕ 
-- select * from SearchGroups
-- select * from GroupMembers 
-- Добавляем участников в группы (по 3 человека на группу)
INSERT INTO GroupMembers (GroupId, UserId, Role) VALUES
-- Группа 1
(1, 12, 'leader'),
(1, 17, 'volunteer'),
(1, 19, 'volunteer'),
-- Группа 2
(2, 14, 'volunteer'),
(2, 15, 'leader'),
(2, 20, 'volunteer'),
-- Группа 3
(3, 12, 'leader'),
(3, 18, 'volunteer'),
(3, 14, 'volunteer'),
-- Группа 4
(4, 15, 'leader'),
(4, 13, 'volunteer'),
(4, 19, 'volunteer'),
-- Группа 5
(5, 12, 'leader'),
(5, 20, 'volunteer'),
(5, 14, 'volunteer'),
-- Группа 6
(6, 15, 'leader'),
(6, 13, 'volunteer'),
(6, 14, 'volunteer'),
-- Группа 7
(7, 12, 'leader'),
(7, 17, 'volunteer'),
(7, 13, 'volunteer'),
-- Группа 8
(8, 15, 'leader'),
(8, 16, 'volunteer'),
(8, 20, 'volunteer'),
-- Группа 9
(9, 12, 'leader'),
(9, 14, 'volunteer'),
(9, 18, 'volunteer'),
-- Группа 10
(10, 15, 'leader'),
(10, 19, 'volunteer'),
(10, 13, 'volunteer');

-- ###################### SearchEvents - Таблица для хранения мероприятий поиска

-- Создание таблицы SearchEvents
CREATE TABLE SearchEvents (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,			-- Уникальный ID мероприятия
    RequestId INTEGER,								-- Ссылка на заявку (SearchRequests.Id)
    CreatedBy INTEGER,								-- Кто создал мероприяти (Users.Id)
    Description TEXT,								-- Описание мероприятия
    Location VARCHAR(255),							-- Место проведения
	Status VARCHAR(50) NOT NULL DEFAULT 'планируется', -- Статус мероприятия: планируется, выполняется, завершено, остановлено
    StartTime DATETIME,								-- Время начала
    EndTime DATETIME,								-- Время окончания
    CreatedAt DATETIME DEFAULT CURRENT_TIMESTAMP,	-- Дата создания
    UpdatedAt DATETIME DEFAULT CURRENT_TIMESTAMP,	-- Дата последнего обновления

    -- Внешние ключи
    FOREIGN KEY (RequestId) REFERENCES SearchRequests(Id) ON DELETE CASCADE,
    FOREIGN KEY (CreatedBy) REFERENCES Users(Id) ON DELETE CASCADE
);

-- Индекс 
CREATE INDEX IX_SearchEvents_RequestId ON SearchEvents(RequestId);
CREATE INDEX IX_SearchEvents_CreatedBy ON SearchEvents(CreatedBy);
CREATE INDEX IX_SearchEvents_StartTime ON SearchEvents(StartTime);
CREATE INDEX IX_SearchEvents_Status ON SearchEvents(Status); 
-- добавляю новые необязательные поля



-- Демо данные 
-- select * from SearchRequests 
-- select * from SearchGroups 
-- select * from SearchEvents
INSERT INTO SearchEvents (RequestId, CreatedBy, Description, Location, StartTime, EndTime, Status)
VALUES
-- RequestId = 1
(1, 12, 'Поиск кошки Мурка', 'Дом рядом с метро', '2025-04-05 09:00:00', '2025-04-05 13:00:00', 'выполняется'),
-- RequestId = 2
(2, 15, 'Проверка района поиска собаки Рекса', 'Центральный район', '2025-04-08 10:00:00', '2025-04-08 14:00:00', 'выполняется'),
-- RequestId = 3
(3, 12, 'Восстановление информации о пропавшем кролике', 'Сад у дома', '2025-04-03 12:00:00', '2025-04-03 14:00:00', 'завершено'),
-- RequestId = 4
(4, 15, 'Организация поисковой группы для кота Феликса', 'Офис компании', '2025-04-10 11:00:00', '2025-04-10 15:00:00', 'планируется'),
-- RequestId = 5
(5, 12, 'Обход сквера возле школы', 'Сквер возле школы', '2025-04-12 08:30:00', '2025-04-12 12:30:00', 'планируется'),
-- RequestId = 6
(6, 15, 'Рассылка информации о поиске Чарли', 'Кафе неподалёку', '2025-04-07 15:00:00', '2025-04-07 17:00:00', 'выполняется'),
-- RequestId = 7
(7, 12, 'Анализ данных по Снежане', 'Площадь города', '2025-04-02 10:00:00', '2025-04-02 12:00:00', 'завершено'),
-- RequestId = 8
(8, 15, 'Уточнение данных по ошибочному объявлению', 'Квартира на проспекте', '2025-04-04 14:00:00', '2025-04-04 15:00:00', 'остановлено'),
-- RequestId = 9
(9, 12, 'Сбор добровольцев для поиска', 'Парк недалеко от дома', '2025-04-11 10:00:00', '2025-04-11 14:00:00', 'планируется'),
-- RequestId = 10
(10, 15, 'Изучение информации о последнем местонахождении', 'Магазин у балкона', '2025-04-06 13:00:00', '2025-04-06 15:00:00', 'остановлено');

-- ###################### SearchTasks - Таблица для хранения задач поиска
-- drop table SearchTasks
CREATE TABLE SearchTasks (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    EventId INTEGER,                          -- Ссылка на мероприятие (ссылка SearchEvents.Id)
    AssignedTo INTEGER,                       -- Кому назначена задача (ссылка Users.Id)
    Title TEXT NOT NULL,                      -- Название задачи
    Description TEXT,                         -- Описание задачи
    Status VARCHAR(50) NOT NULL               -- Статус задачи: "назначена", "в процессе", "завершена" 'отменена'
        CHECK (Status IN ('назначена', 'в процессе', 'завершена', 'отменена')),
    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP, -- Дата создания записи
    UpdatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP, -- Дата последнего обновления

    -- Внешние ключи
    FOREIGN KEY (EventId) REFERENCES SearchEvents(Id) ON DELETE CASCADE,
    FOREIGN KEY (AssignedTo) REFERENCES Users(Id) ON DELETE SET NULL
);

-- Индекс 
CREATE INDEX IX_SearchTasks_EventId ON SearchTasks(EventId);
CREATE INDEX IX_SearchTasks_AssignedTo ON SearchTasks(AssignedTo);
CREATE INDEX IX_SearchTasks_Status ON SearchTasks(Status);
-- Добавляю поля (в процессе отладки после пересоздания можно удалить)
-- Демо данные
-- select * from SearchTasks
			-- select * from SearchEvents
			-- select * from GroupMembers 
			-- select * from SearchGroups

INSERT INTO SearchTasks (EventId, AssignedTo, Title, Description, Status)
VALUES
-- EventId = 1
(1, 12, 'Расспросить соседей', 'Узнать, видели ли кто-нибудь кошку Мурка', 'в процессе'),
-- EventId = 2
(2, 15, 'Обзвон приютов', 'Позвонить в ближайшие приюты', 'назначена'),
-- EventId = 3
(3, 18, 'Создание объявлений', 'Подготовить текст и фото для поиска кролика', 'завершена'),
-- EventId = 4
(4, 19, 'Организация группы поиска', 'Собрать команду для мероприятия', 'в процессе'),
-- EventId = 5
(5, 20, 'Обход района', 'Пройти сквер возле школы', 'в процессе'),
-- EventId = 6
(6, 13, 'Рассылка информации', 'Разослать объявления в чаты', 'в процессе'),
-- EventId = 7
(7, 17, 'Анализ данных', 'Изучить информацию от очевидцев', 'завершена'),
-- EventId = 8
(8, 16, 'Уточнение информации', 'Проверить детали по ошибочному объявлению', 'отменена'),
-- EventId = 9
(9, 18, 'Сбор добровольцев', 'Назначить встречу для распределения задач', 'назначена'),
-- EventId = 10
(10, 13, 'Фотофиксация местности', 'Сделать фотографии района последнего местонахождения', 'в процессе');


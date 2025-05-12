












-- 
SELECT [Id]
      ,[Subject] 
      ,[CourseId]
      ,[Deleted]
  FROM [SonarTasks]
  
 --

 select * from SonarProcess;
 

 
 
 SELECT 
    st.Id AS TaskId,
    st.Title AS TaskTitle,
    st.Description AS TaskDescription,
    st.Status AS TaskStatus,
    st.CreatedAt AS TaskCreatedAt,
    st.UpdatedAt AS TaskUpdatedAt,

    se.Id AS EventId,
    se.Description AS EventDescription,
    se.Location AS EventLocation,
    se.StartTime,
    se.EndTime,

    u.UserName AS AssignedToUsername,
    u.FullName AS AssignedToFullName,

    sreq.Id AS RequestId,

    sa.Description AS AnnouncementDescription,

    a.Name AS AnimalName,
    a.Species AS AnimalSpecies,
    a.Breed AS AnimalBreed
FROM SearchTasks st
JOIN SearchEvents se ON st.EventId = se.Id
JOIN SearchRequests sreq ON se.RequestId = sreq.Id
JOIN SearchAnnouncements sa ON sreq.Id = sa.Id
JOIN Animals a ON sa.AnimalId = a.Id
LEFT JOIN Users u ON st.AssignedTo = u.Id;
 
 -- select * from SearchEvents








----------

DROP TABLE SonarTasks
DROP TABLE SonarProcess
drop table SearchLeader


-- <<<<<<<<<<  22.01.2025 настраиваю таблицу SonarTasks
/*  
CREATE TABLE [SonarTasks] (
  [Id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL
, [Subject] text NULL
, [SonarProcessId] bigint NOT NULL
, [Deleted] bigint NOT NULL
, CONSTRAINT [FK_SonarTasks_0_0] FOREIGN KEY ([SonarProcessId]) REFERENCES [SonarProcess] ([Id]) ON DELETE CASCADE ON UPDATE NO ACTION
);
CREATE INDEX [SonarTasks_IX_SonarProcessId] ON [SonarTasks] ([SonarProcessId] ASC);
*/
-- переносим данные таблицы
/*
INSERT INTO SonarTasks (id, Subject, SonarProcessId, Deleted)
SELECT id, Subject, CourseId SonarProcessId, Deleted
FROM SonarTasksOld;
*/
--drop table SonarTasksOld
  
  
  
  

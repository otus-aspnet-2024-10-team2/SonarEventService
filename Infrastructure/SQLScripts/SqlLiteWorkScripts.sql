-- Script Date: 22.01.2025 16:42  - ErikEJ.SqlCeScripting version 3.5.2.95
SELECT [Id]
      ,[Subject] 
      ,[CourseId]
      ,[Deleted]
  FROM [SonarTasks];
  
 --

 select * from SonarProcess;
 
 





















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
  
  
  
  

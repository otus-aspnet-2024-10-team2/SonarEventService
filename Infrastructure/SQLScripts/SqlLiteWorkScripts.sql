



select * from SearchEvents where id = 1








-- Запро выбоки задач пользователей 
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


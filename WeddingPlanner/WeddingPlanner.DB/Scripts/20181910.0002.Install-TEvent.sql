create table weddingplanner.tEvent
(
    EventId int identity(0, 1),
    UserId int not null,
    OrganizerId int not null,
    EventName nvarchar(225) not null,

    constraint PK_tEvent primary key(EventId),
);
insert into weddingplanner.tEvent(UserId, OrganizerId, EventName) values(0, 0, N'');

create table weddingplanner.tEvent
(
    EventId int identity(0, 1),
    UserId int not null,
    OrganisateurId int null,

    constraint PK_tEvent primary key(EventId),
    constraint FK_tEvent_tUsers foreign key(UserId) references weddingplanner.tUsers(UserId),

);

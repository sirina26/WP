create table weddingplanner.tOrganizer
(
    OrganizerId int identity(0, 1),
    UserId int not null,
    EventId int not null,

     constraint PK_tOrganizer primary key(OrganizerId),
     constraint FK_tOrganizer_tUsers foreign key(UserId) references weddingplanner.tUsers(UserId),
     constraint FK_tOrganizer_tEvent foreign key(EventId) references weddingplanner.tEvent(EventId)
);

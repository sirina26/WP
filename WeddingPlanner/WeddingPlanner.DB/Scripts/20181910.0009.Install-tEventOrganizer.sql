create table weddingplanner.tEventOrganizer
(
    OrganizerId int not null,
    EventId int not null,

     constraint PK_tEventOrganizer primary key(OrganizerId, EventId),
     constraint FK_tEventOrganizer_tEvent foreign key(EventId) references weddingplanner.tEvent(EventId),
     constraint FK_tEventOrganizer_tOrganizers foreign key(OrganizerId) references weddingplanner.tOrganizers(OrganizerId)
);
insert into weddingplanner.tEventOrganizer(
        OrganizerId,    EventId)
        values(0,       0);

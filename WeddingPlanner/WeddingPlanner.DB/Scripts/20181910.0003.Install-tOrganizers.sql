create table weddingplanner.tOrganizers
(
    OrganizerId int not null,
    UserId int not null,
    EventId int not null,
    PhoneNumber nvarchar(32) not null,

     constraint PK_tOrganizers primary key(OrganizerId),
     constraint FK_tOrganizers_tUsers foreign key(UserId) references weddingplanner.tUsers(UserId)
);
insert into weddingplanner.tOrganizers(
            UserId, OrganizerId, EventId, PhoneNumber)
            values(
            0,       0,          0,          N'');

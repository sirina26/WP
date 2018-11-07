create table weddingplanner.tOrganizers
(
    OrganizerId int not null,
    PhoneNumber nvarchar(32) not null,

     constraint PK_tOrganizers primary key(OrganizerId),
     constraint FK_tOrganizers_tUsers foreign key(OrganizerId) references weddingplanner.tUsers(UserId)
);
insert into weddingplanner.tOrganizers(
           OrganizerId, PhoneNumber)
            values(
            0,          N'');

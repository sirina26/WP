create table weddingplanner.tOrganisateur
(
    OrganisateurId int identity(0, 1),
    UserId int not null,
    EventId int not null,

     constraint PK_tOrganisateur primary key(OrganisateurId),
     constraint FK_tOrganisateur_tUsers foreign key(UserId) references weddingplanner.tUsers(UserId),
     constraint FK_tOrganisateur_tEvent foreign key(EventId) references weddingplanner.tEvent(EventId),
);

create table test.tOrganisateur
(
    Id_user int not null,
    Id_event int not null,  
    Type_user  bit 

     constraint FK_tOrganisateur_tUsers foreign key(Id_user) references test.tUsers(User_id),
     constraint FK_tOrganisateur_tEvent foreign key(Id_event) references test.tEvent(Id_event),
);

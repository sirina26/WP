create table test.tMessage
(
    Id_user int not null,
    Id_event int not null,
    Comment  nvarchar(150),

    constraint FK_tMessage_tUsers foreign key(Id_user) references test.tUsers(User_id),
    constraint FK_tMessage_tEvent foreign key(Id_event) references test.tEvent(Id_event),
);

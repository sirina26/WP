create table weddingplanner.tPasswordUser
(
    UserId     int,
    [Password] varbinary(128) not null,

    constraint PK_tPasswordUser primary key(UserId),
    constraint FK_tPasswordUser_UserId foreign key(UserId) references weddingplanner.tUsers(UserId)
);


create table weddingplanner.tPassword
(
    UserId     int,
    [Password] varbinary(128) not null,

    constraint PK_tPassword primary key(UserId),
    constraint FK_tPassword_UserId foreign key(UserId) references weddingplanner.tUsers(UserId)
);
insert into weddingplanner.tPassword(UserId, [Password]) values(0, convert(varbinary(128), newid()));

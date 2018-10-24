create table weddingplanner.tGoogle
(
    UserId       int,
    GoogleId     varchar(32) not null,
    RefreshToken varchar(64) not null,

    constraint PK_tGoogle primary key(UserId),
    constraint FK_tGoogle_UserId foreign key(UserId) references weddingplanner.tUsers(UserId),
    constraint UK_tGoogle_GoogleId unique(GoogleId)
);

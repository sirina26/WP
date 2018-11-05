create table weddingplanner.tUsers
(
    UserId int identity(0, 1),
    FirstName nvarchar(32) not null,
    LastName  nvarchar(32) not null,
    Email nvarchar(32) not null,

    constraint PK_tUsers primary key(UserId),
    constraint UK_tUser_Email unique(Email),
    constraint CK_tUsers_FirstName check(FirstName <> N''),
    constraint CK_tUsers_LastName check(LastName <> N'')
);
insert into weddingplanner.tUsers
        (FirstName,                                  LastName,                               Email)
        values(
        left(convert(nvarchar(36), newid()), 32), left(convert(nvarchar(36), newid()), 32), N'');

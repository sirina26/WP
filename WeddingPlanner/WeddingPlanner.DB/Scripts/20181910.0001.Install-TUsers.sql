create table weddingplanner.tUsers
(
    UserId int identity(0, 1),
    FirstName nvarchar(32) not null,
    LastName  nvarchar(32) not null,
    Place nvarchar(32) null,
    MaximumPrice nvarchar(32) null,
    NumberOfGuestes nvarchar(32) null,
    Note nvarchar(32) null,
    Email nvarchar(32) not null,
    PhoneNumber nvarchar(32) null,
    WeddingDate datetime2 null,
    UserType  bit,


    constraint PK_tUsers primary key(UserId),
    constraint UK_tUser_Email unique(Email),
    constraint CK_tUsers_FirstName check(FirstName <> N''),
    constraint CK_tUsers_LastName check(LastName <> N'')
);

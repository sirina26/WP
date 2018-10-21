create table test.tUsers
(
    User_id int identity(0, 1),
    FirstName nvarchar(32) not null,
    LastName  nvarchar(32) not null,
    Place nvarchar(32) not null,
    Maximum_price nvarchar(32) not null,
    Number_of_guestes nvarchar(32) not null,
    Mail nvarchar(32) not null,
    Password nvarchar(32) not null,
    Wedding_date datetime2 null,
    Wedding_date datetime2 null,


    constraint PK_tUsers primary key(User_id),
    constraint UK_tUsers_FirstName_LastName unique(FirstName, LastName),
    constraint CK_tUsers_FirstName check(FirstName <> N''),
    constraint CK_tUsers_LastName check(LastName <> N''),
);

create table weddingplanner.tCustomers
(
    CustomerId int not null,
    EventId int not null,
    UserId int not null,
    Place nvarchar(32) not null,
    MaximumPrice float not null,
    NumberOfGuestes int not null,
    Note nvarchar(32) not null,
    WeddingDate datetime2 not null,

     constraint PK_tCustomers primary key(CustomerId),
     constraint FK_tCustomers_tEvent foreign key(EventId) references weddingplanner.tEvent(EventId),
     constraint FK_tCustomers_tUsers foreign key(UserId) references weddingplanner.tUsers(UserId)
);
insert into weddingplanner.tCustomers(
    CustomerId, EventId, UserId, Place, MaximumPrice, NumberOfGuestes, Note, WeddingDate)
values(
        0,        0,       0,      N'',      0,          0,               N'', '00010101');

create table weddingplanner.tEvent
(
    EventId int identity(0, 1),
    CustomerId int not null,
    OrganizerId int not null,
    EventName nvarchar(32) not null,
    Place nvarchar(32) not null,
    MaximumPrice float not null,
    NumberOfGuestes int not null,
    Note nvarchar(32) not null,
    WeddingDate datetime2 not null,
    constraint PK_tEvent primary key(EventId),
);
insert into weddingplanner.tEvent(
        CustomerId, OrganizerId, EventName, Place,
        MaximumPrice, NumberOfGuestes, Note, WeddingDate)
        values
        (0,      0,         N'',                N'',
        0,          0,      N'',         '00010101');


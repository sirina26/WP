create table test.tEvent
(
    Id_event int identity(0, 1),
    Name_event nvarchar(50) not null,

    constraint PK_tEvent primary key(Id_event)

);

create table weddingplanner.tList
(
    ListId int identity(0, 1),
    UserId int,
    ListWish nvarchar(255),
    StateList bit, 

    constraint PK_tList Primary Key(ListId),
    constraint FK_tList_tUsers foreign key(UserId) references weddingplanner.tUsers(UserId)

);

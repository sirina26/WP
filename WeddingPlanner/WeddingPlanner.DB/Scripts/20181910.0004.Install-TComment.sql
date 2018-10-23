create table weddingplanner.tComment
(
    CommentId int identity(0, 1),
    OrganizerId int not null,
    EventId int not null,
    Comment  nvarchar(500),

    constraint PK_tComment primary key(CommentId),
    constraint FK_tComment_tOrganizer foreign key(OrganizerId) references weddingplanner.tOrganizer(OrganizerId),
    constraint FK_tComment_tEvent foreign key(EventId) references weddingplanner.tEvent(EventId)

);

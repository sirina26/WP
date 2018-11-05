create table weddingplanner.tComment
(
    CommentId int identity(0, 1),
    OrganizerId int not null,
    EventId int not null,
    Comment  nvarchar(500),

    constraint PK_tComment primary key(CommentId),
    constraint FK_tComment_tOrganizers foreign key(OrganizerId) references weddingplanner.tOrganizers(OrganizerId),
    constraint FK_tComment_tEvent foreign key(EventId) references weddingplanner.tEvent(EventId)

);
insert into weddingplanner.tComment(
        OrganizerId, EventId, Comment)
        values(
        0,          0,          N'');

create view weddingplanner.vComment
as
select
    CommentId = t.CommentId,
    OrganizerId = t.OrganizerId,
    EventId = t.EventId,
    Comment = t.Comment

from weddingplanner.tComment t;

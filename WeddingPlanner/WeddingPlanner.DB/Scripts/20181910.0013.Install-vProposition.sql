create view weddingplanner.vComment
as
select
    PropositionId = t.PropositionId,
    OrganizerId = t.OrganizerId,
    EventId = t.EventId,
    Proposition = t.Proposition,
    PropositionDate = t.Proposition

from weddingplanner.tProposition t;

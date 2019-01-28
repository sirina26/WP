create view weddingplanner.vProposition
as
select
    PropositionId = t.PropositionId,
    OrganizerId = t.OrganizerId,
    EventId = t.EventId,
    Proposition = t.Proposition,
    PropositionDate = t.PropositionDate

from weddingplanner.tProposition t;

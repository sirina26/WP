create view weddingplanner.vEvent
as
    select
        EventId = t.EventId,
        EventName = t.EventName,
        OrganisateurId = t.OrganisateurId
    from weddingplanner.tEvent t;
    

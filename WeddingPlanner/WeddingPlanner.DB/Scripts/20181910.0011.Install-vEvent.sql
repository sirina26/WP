create view weddingplanner.vEvent
as
    select
        EventId = t.EventId,
        EventName = t.EventName,
        OrganizerId = t.OrganizerId

    from weddingplanner.tEvent t;
    

create view weddingplanner.vEventOrganizer
as
    select

        OrganizerId = t.OrganizerId, 
        EventId     = t.EventId 

    from weddingplanner.tEventOrganizer t

create view weddingplanner.vOrganizerss
as
    select     
           OrganizerId =t.OrganizerId,
           UserId      =t.UserId,
           EventId     =t.EventId,
           PhoneNumber =t.PhoneNumber

    from weddingplanner.tOrganizers t;

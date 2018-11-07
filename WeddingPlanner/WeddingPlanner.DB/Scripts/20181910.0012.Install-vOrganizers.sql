create view weddingplanner.vOrganizerss
as
    select     
           OrganizerId =t.OrganizerId,
           PhoneNumber =t.PhoneNumber

    from weddingplanner.tOrganizers t;

create view weddingplanner.vOrganizers
as
    select     
           OrganizerId =t.OrganizerId,
           PhoneNumber =t.PhoneNumber

    from weddingplanner.tOrganizers t;

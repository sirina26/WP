create view weddingplanner.vEvent
as
    select
     
    EventId = v.EventId,
    CustomerId = case when v.CustomerId = 0 then N'' else v.CustomerId end,
    OrganizerId = case when v.OrganizerId = 0 then N'' else v.OrganizerId end,
    EventName = v.EventName,
    Place = v.Place,
    MaximumPrice = v.MaximumPrice,
    NumberOfGuestes = v.NumberOfGuestes ,
    Note = v.Note,
    WeddingDate = v.WeddingDate 

    from weddingplanner.tEvent v;
    

create view weddingplanner.vEvent
as
    select
     
    EventId = e.EventId,
    CustomerId = case when e.CustomerId = 0 then N'' else e.CustomerId end,
    OrganizerId = case when e.OrganizerId = 0 then N'' else e.OrganizerId end,
    EventName = e.EventName,
    Place = e.Place,
    MaximumPrice = e.MaximumPrice,
    NumberOfGuestes = e.NumberOfGuestes ,
    Note = e.Note,
    WeddingDate = e.WeddingDate 

    from weddingplanner.tEvent e;
    

create view weddingplanner.vCustomers
as
select

    CustomerId = t.CustomerId,
    EventId = t.EventId,
    UserId = t.UserId,
    Place = t.Place,
    MaximumPrice = t.MaximumPrice,
    NumberOfGuestes = t.NumberOfGuestes,
    Note = t.Note,
    WeddingDate = t.WeddingDate
        
from weddingplanner.tCustomers t;

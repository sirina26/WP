create view weddingplanner.vCustomers
as
select

    CustomerId = t.CustomerId,
    EventId = t.EventId,
    UserId = t.UserId
        
from weddingplanner.tCustomers t;

create view weddingplanner.vCustomers
as
select

    CustomerId = t.CustomerId,
    EventId = t.EventId
        
from weddingplanner.tCustomers t;

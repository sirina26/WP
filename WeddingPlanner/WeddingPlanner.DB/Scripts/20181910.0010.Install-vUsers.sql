create view weddingplanner.vUsers
as
select
    FirstName = t.FirstName,
    LastName = t.LastName,
    Email = t.Email
    
from weddingplanner.tUsers t;

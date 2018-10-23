create view weddingplanner.vUsers
as
select
    FirstName = t.FirstName,
    LastName = t.LastName,
    Place = t.Place,
    MaximumPrice = t.MaximumPrice,
    NumberOfGuestes = t.NumberOfGuestes,
    Note = t.Note,
    Email = t.Email,
    PhoneNumber = t.PhoneNumber,
    WeddingDate = t.WeddingDate,
    UserType = t.UserType

from weddingplanner.tUsers t;

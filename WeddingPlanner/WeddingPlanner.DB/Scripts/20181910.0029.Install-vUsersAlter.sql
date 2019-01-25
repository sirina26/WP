alter view weddingplanner.vUsers
as
    select UserId = u.UserId,
           Email = u.Email,
           FirstName = u.FirstName,
           LastName = u.LastName,
           [Password] = case when p.[Password] is null then 0x else p.[Password] end,
           IsOrganizer = case when o.OrganizerId is null then 0 else 1 end
           
    from weddingplanner.tUsers u
        left outer join weddingplanner.tPassword p on p.UserId = u.UserId
        left outer join weddingplanner.tOrganizers o on o.OrganizerId = u.UserId
    where u.UserId <> 0;

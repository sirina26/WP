create procedure weddingplanner.sUserUpdate
(
    @UserId int,
    @FirstName nvarchar(32),
    @LastName  nvarchar(32),
    @Email  nvarchar(64)
)
as
begin
    update weddingplanner.tUsers
    set Email = @Email,  FirstName = @FirstName,    LastName = @LastName
    where UserId = @UserId;
    return 0;
end;

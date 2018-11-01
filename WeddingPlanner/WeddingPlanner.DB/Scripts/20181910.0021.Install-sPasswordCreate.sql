create procedure weddingplanner.sPasswordUserCreate
(
    @Email    nvarchar(64),
    @Password varbinary(128),
	@UserId   int out
)
as
begin
	set transaction isolation level serializable;
	begin tran;

	if exists(select * from weddingplanner.tUsers u where u.Email = @Email)
	begin
		rollback;
		return 1;
	end;

    insert into weddingplanner.tUsers(Email) values(@Email);
    select @UserId = scope_identity();
    insert into weddingplanner.tPassword(UserId,  [Password])
                           values(@userId, @Password);
	commit;
    return 0;
end;

alter proc weddingplanner.sEventCreate
(
    
    @EventName nvarchar (32),
    @Place nvarchar (32),
    @MaximumPrice float,
    @NumberOfGuestes int,
    @Note nvarchar (32),
    @WeddingDate datetime2,
    @EventId   int out,
    @UserId int
)
as
begin
    set transaction isolation level serializable;
	begin tran;

	insert into weddingplanner.tEvent
                   (CustomerId, OrganizerId, EventName,
                    Place, MaximumPrice,NumberOfGuestes,
                    Note, WeddingDate)
        values
                    (@UserId, 0, @EventName,
                    @Place, @MaximumPrice,@NumberOfGuestes,
                    @Note, @WeddingDate);
	set @EventId = scope_identity();

    commit;
	return 0;
end;

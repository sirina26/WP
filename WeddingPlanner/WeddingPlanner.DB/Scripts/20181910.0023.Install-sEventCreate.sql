create procedure weddingplanner.sEventCreate
(
    
    @EventName nvarchar (32),
    @Place nvarchar (32),
    @MaximumPrice float,
    @NumberOfGuestes int,
    @Note nvarchar,
    @WeddingDate datetime2,
    @EventId   int out
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
                    (1, 2, @EventName,
                    @Place, @MaximumPrice,@NumberOfGuestes,
                    @Note, @WeddingDate);
	set @EventId = scope_identity();

    commit;
	return 0;
end;

alter proc weddingplanner.sEventUpdate

(
    @EventId   int,
    @EventName nvarchar (32),
    @Place nvarchar (32),
    @MaximumPrice float,
    @NumberOfGuestes int,
    @Note nvarchar (32),
    @WeddingDate datetime2
)
as
begin
    set transaction isolation level serializable;
	begin tran;

	if not exists(select * from weddingplanner.tEvent s where s.EventId = @EventId)
	begin
		rollback;
		return 1;
	end;
	
	update weddingplanner.tEvent
	set EventName = @EventName, Place = @Place, MaximumPrice = @MaximumPrice, NumberOfGuestes = @NumberOfGuestes, Note = @Note, WeddingDate = @WeddingDate
	where EventId = @EventId;

	
	commit;
    return 0;
end;

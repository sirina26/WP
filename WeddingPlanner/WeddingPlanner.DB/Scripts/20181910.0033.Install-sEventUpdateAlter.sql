create proc weddingplanner.sEventUpdate

(
    @EventId   int,
    @EventName nvarchar (32),
    @Place nvarchar (32),
    @MaximumPrice float,
    @NumberOfGuestes int,
    @Note nvarchar (32),
    @WeddingDate datetime2,
    @UserId int

   
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

	if exists(select * from weddingplanner.tEvent s where s.EventId <> @EventId)
	begin
		rollback;
		return 2;
	end;

	
	update weddingplanner.tEvent
	set EventName = @EventName, Place = @Place, MaximumPrice = @MaximumPrice, NumberOfGuestes = @NumberOfGuestes, Note = @Note
	where EventId = @EventId;

	
	commit;
    return 0;
end;

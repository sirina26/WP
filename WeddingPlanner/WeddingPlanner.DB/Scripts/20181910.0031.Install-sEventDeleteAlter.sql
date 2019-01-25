alter proc weddingplanner.sEventDelete
(
    @EventId int
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

    delete from weddingplanner.tEvent where EventId = @EventId;
    delete from weddingplanner.tEventOrganizer where EventId = @EventId;

	commit;
    return 0;
end;

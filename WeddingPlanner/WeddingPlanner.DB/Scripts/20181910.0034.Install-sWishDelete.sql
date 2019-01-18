create procedure weddingplanner.sWishDelete
(
    @TaskId int
)
as
begin
set transaction isolation level serializable;
	begin tran;

	if not exists(select * from weddingplanner.tWish s where s.TaskId = @TaskId)
	begin
		rollback;
		return 1;
	end;

   delete from weddingplanner.tWish where TaskId = @TaskId;

	commit;
    return 0;
end;

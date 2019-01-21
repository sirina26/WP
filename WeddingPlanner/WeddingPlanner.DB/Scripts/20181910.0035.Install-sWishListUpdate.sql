create proc weddingplanner.sWishListUpdate

(
    @TaskId int,
    @CustomerId int,
    @Task nvarchar(255),
    @StateTask bit
   
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
	
	update weddingplanner.tWish
	set CustomerId = @CustomerId, Task = @Task, StateTask = @StateTask
	where TaskId = @TaskId;

	
	commit;
    return 0;
end;

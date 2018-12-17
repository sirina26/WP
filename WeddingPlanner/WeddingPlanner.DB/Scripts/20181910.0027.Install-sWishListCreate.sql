create procedure weddingplanner.sWishListCreate
(    
    @CustomerId int,
    @Task  nvarchar (32),
    @StateTask bit,
    @TaskId   int out
)
as
begin
    set transaction isolation level serializable;
	begin tran;

	insert into weddingplanner.tWish
                   (CustomerId, Task, StateTask)
        values
                    (@CustomerId, @Task, @StateTask);
	set @TaskId = scope_identity();

    commit;
	return 0;
end;

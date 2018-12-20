create procedure weddingplanner.sCustomersCreate
(
    @CustomerId int,
    @EventId int 
    )
    as
    begin
    	set transaction isolation level serializable;
      	begin tran;

        insert into weddingplanner.tCustomers
            (CustomerId, EventId)
        values
            (@CustomerId, @EventId);
            	commit;
	end;

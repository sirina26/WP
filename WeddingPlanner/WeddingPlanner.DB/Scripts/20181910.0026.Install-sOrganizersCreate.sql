create procedure weddingplanner.sOrganizersCreate
(
    @OrganizerId int,
    @PhoneNumber nvarchar(32)
    )
    as
    begin
    	set transaction isolation level serializable;
      	begin tran;

        insert into weddingplanner.tOrganizers
            (OrganizerId, PhoneNumber)
        values
            (@OrganizerId, @PhoneNumber);
            commit;
	end;

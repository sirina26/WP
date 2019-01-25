create procedure weddingplanner.sPropositionCreate
(    
    @OrganizerId int,
    @EventId int,
    @Proposition  nvarchar(500),
    @PropositionDate datetime2,
    @PropositionId int out
    
)
as
begin
    set transaction isolation level serializable;
	begin tran;

	insert into weddingplanner.tProposition
       (OrganizerId, EventId, Proposition,PropositionDate)
      values
       (@OrganizerId, @EventId, @Proposition, @PropositionDate);
	set @PropositionId = scope_identity();

    commit;
	return 0;
end;

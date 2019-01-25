create proc weddingplanner.sPropositionUpdate

( 
    @OrganizerId int,
    @EventId int,
    @Proposition  nvarchar(500),
    @PropositionDate datetime2,
    @PropositionId int
    
)
as
begin
    set transaction isolation level serializable;
	begin tran;

	if not exists(select * from weddingplanner.tProposition s where s.PropositionId = @PropositionId)
	begin
		rollback;
		return 1;
	end;
	
	update weddingplanner.tProposition
	set OrganizerId = @OrganizerId, EventId = @EventId, Proposition = @Proposition, PropositionDate = @PropositionDate
	where PropositionId = @PropositionId;

	
	commit;
    return 0;
end;

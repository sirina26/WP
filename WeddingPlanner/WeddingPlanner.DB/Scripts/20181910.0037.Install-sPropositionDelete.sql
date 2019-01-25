create procedure weddingplanner.sPropositionDelete
(
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

    delete from weddingplanner.tProposition where PropositionId = @PropositionId;
	commit;
    return 0;
end;

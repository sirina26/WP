create proc weddingplanner.sAssignOrganizer
(
    @EventId int,
    @OrganizerId int
)
as
begin
    update weddingplanner.tEvent
    set OrganizerId = @OrganizerId
    where OrganizerId = @OrganizerId;
    return 0;
end;

create table weddingplanner.tProposition
(
    PropositionId int identity(0, 1),
    OrganizerId int not null,
    EventId int not null,
    Proposition  nvarchar(500),
    PropositionDate datetime2 not null,

    constraint PK_tProposition primary key(PropositionId),
    --constraint FK_tProposition_tEventOrganizer foreign key(OrganizerId, EventId) references weddingplanner.tEventOrganizer(OrganizerId,EventId),

);
insert into weddingplanner.tProposition(
        OrganizerId, EventId, Proposition, PropositionDate)
        values(
        0,          0,          N'', '00010101');

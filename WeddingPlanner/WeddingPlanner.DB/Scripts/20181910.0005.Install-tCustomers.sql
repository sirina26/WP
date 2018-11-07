create table weddingplanner.tCustomers
(
    CustomerId int not null,
    EventId int not null,
    UserId int not null,
   

     constraint PK_tCustomers primary key(CustomerId),
     constraint FK_tCustomers_tEvent foreign key(EventId) references weddingplanner.tEvent(EventId),
     constraint FK_tCustomers_tUsers foreign key(UserId) references weddingplanner.tUsers(UserId)
);
insert into weddingplanner.tCustomers(
    CustomerId, EventId, UserId)
values(
        0,        0,       0);

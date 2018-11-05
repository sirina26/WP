create table weddingplanner.tWish
(
    TaskId int identity(0, 1),
    CustomerId int not null,
    Task nvarchar(255),
    StateTask bit, 

    constraint PK_tWish Primary Key(TaskId),
    constraint FK_tWish_tCustomers foreign key(CustomerId) references weddingplanner.tCustomers(CustomerId)

);
insert into weddingplanner.tWish(
         CustomerId, Task, StateTask)
        values(
         0,          N'',    0);
                                

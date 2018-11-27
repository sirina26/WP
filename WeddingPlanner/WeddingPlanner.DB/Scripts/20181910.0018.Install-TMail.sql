create table weddingplanner.tMail
(
    MailId int identity(0, 1),
    Mail nvarchar(32) not null,
    Receiver nvarchar(32) not null,
    ObjectMail nvarchar(32) not null,
    EmitterId int not null
    
    constraint PK_tMail primary key(MailId),
    constraint FK_tMail_tUsers foreign key(EmitterId) references weddingplanner.tUsers(UserId),

);
insert into weddingplanner.tMail(

Mail, Receiver, ObjectMail,
        EmitterId)
        values
        (  N'',   N'',    N'',
        0);


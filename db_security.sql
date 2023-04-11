create database db_security collate SQL_Latin1_General_CP1_CI_AS
go

use db_security
go

create table dbo.Access
(
    id_user  int identity
        constraint PK_Access
            primary key,
    username nvarchar(max),
    password nvarchar(max)
)
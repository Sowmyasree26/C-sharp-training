create database electricitybilldb;

use electricitybilldb;


create table electricitybill (
    consumer_number varchar(20) primary key,
    consumer_name varchar(50) not null,
    units_consumed int not null,
    bill_amount float not null
)

create table adminlogin (
    username varchar(50) primary key,
    password varchar(50) not null
)


insert into adminlogin (username, password)
values ('admin', 'admin123')

create or alter proc sp_add_electricity_bill
    @consumer_number varchar(20),
    @consumer_name varchar(50),
    @units_consumed int,
    @bill_amount float
as
begin
    insert into electricitybill 
    values (@consumer_number, @consumer_name, @units_consumed, @bill_amount) 
end

create or alter proc sp_get_last_n_bills 
    @count int
as
begin
    select top (@count) * from electricitybill order by consumer_number desc 
end


select * from electricitybill





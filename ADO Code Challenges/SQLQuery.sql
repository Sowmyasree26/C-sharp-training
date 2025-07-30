create database ado_assignments

use ado_assignments


create table employee_details (
    empid int identity(1,1) primary key,
    name varchar(100),
    salary float,
    gender varchar(10),
    netsalary as (salary - (salary * 0.10))
)

create or alter procedure sp_employee_details
    @name varchar(50),
    @salary float,
    @gender varchar(10)
as
begin
    declare @final_salary float
    set @final_salary = @salary - (@salary * 0.10)

    insert into employee_details(name, salary, gender)
    output inserted.empid, inserted.salary
    values(@name, @final_salary, @gender)
end

create or alter proc sp_update_salary
    @empid int,
    @updated_salary float output
as
begin
    update employee_details
    set salary = salary + 100
    where empid = @empid
    select @updated_salary = salary
    from employee_details
    where empid = @empid
end

select * from employee_details
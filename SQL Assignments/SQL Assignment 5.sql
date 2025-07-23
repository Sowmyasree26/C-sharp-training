use Sql_Assignments

select * from emp

--1. Write a T-Sql based procedure to generate complete payslip of a given employee with respect to the following condition

create or alter proc paySlip_generation
@eid int
as
begin
	declare @sal int, @name varchar(max)
	select @sal=salary,@name=ename from emp where empno=@eid
	declare @hra float,@da float,@pf float,@it float,@deductions float,@gross float,@net float
	set @hra = @sal* 0.10
    set @da = @sal* 0.20
    set @pf = @sal* 0.08
    set @it = @sal * 0.05
    set @deductions = @pf + @it
    set @gross = @sal + @hra + @da
    set @net = @gross - @deductions

	print 'PAY SLIP of '+ @name
	print 'Employee No : ' + cast(@eid as varchar)
    print 'Employee Name : ' + @name
    print 'Basic Salary : ' + cast(@sal as varchar)
    print 'HRA (10%) : ' + cast(@hra as varchar)
    print 'DA (20%) : ' + cast(@da as varchar)
    print 'PF (8%) : ' + cast(@pf as varchar)
    print 'IT (5%) : ' + cast(@it as varchar)
    print 'Gross Salary : ' + cast(@gross as varchar)
    print 'Deductions : ' + cast(@deductions as varchar)
    print 'Net Salary : ' + cast(@net as varchar)
end

exec paySlip_generation 7499


--2.  Create a trigger to restrict data manipulation on EMP table during General holidays. Display the error message like “Due to Independence day you cannot manipulate data” or "Due To Diwali", you cannot manipulate" etc

create table holiday (
holiday_date date,
holiday_name varchar(50)
)


insert into holiday values 
('2025-01-01', 'New Year'),
('2025-01-26', 'Republic Day'),
('2025-08-15', 'Independence Day'),
('2025-12-25', 'Christmas')

insert into holiday values ('2025-07-23', 'Testing')

create or alter trigger holidays_restrict
on emp
after insert, update, delete
as
begin
    declare @today date = cast(getdate() as date);
    declare @holiday_name varchar(50)
    select @holiday_name = holiday_name
    from holiday
    where holiday_date = @today
    if @holiday_name is not null
    begin
        rollback;
        raiserror('Due to %s, you cannot manipulate data.', 16, 1, @holiday_name);
    end
end


insert into emp values (1778, 'Sowmya', 'CLERK', null, '2025-08-15', 10000, null, 10);




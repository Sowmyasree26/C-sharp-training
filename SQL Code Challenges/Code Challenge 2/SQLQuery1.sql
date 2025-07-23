use sql_Codechallenges

--1.Write a query to display your birthday( day of week)
select datename(weekday, cast('2025-06-26' as date)) as birth_day_of_week

--2.	Write a query to display your age in days
select datediff(day, '2004-06-26', getdate()) as age


create table dept(
deptno int primary key,
dname varchar(30),
loc varchar(30)
)

insert into dept values(10,'ACCOUNTING','NEW YORK'),
(20,'RESEARCH','DALLAS'),
(30,'SALES','CHICAGO' ),
(40,'OPERATIONS','BOSTON')

create table employee(
empno int primary key,
ename varchar(30) not null,
job varchar(30) not null,
mgr_id int,
hire_date datetime,
salary int,
commission int,
deptno int references dept(deptno)
)

insert into employee values (7369, 'SMITH', 'CLERK', 7902, '1980-12-17', 800, NULL, 20),
(7499, 'ALLEN', 'SALESMAN', 7698, '1981-02-20', 1600, 300, 30),
(7521, 'WARD', 'SALESMAN', 7698, '1981-02-22', 1250, 500, 30),
(7566, 'JONES', 'MANAGER', 7839, '1981-04-02', 2975, NULL, 20),
(7654, 'MARTIN', 'SALESMAN', 7698, '1981-09-28', 1250, 1400, 30),
(7698, 'BLAKE', 'MANAGER', 7839, '1981-05-01', 2850, NULL, 30),
(7782, 'CLARK', 'MANAGER', 7839, '1981-06-09', 2450, NULL, 10),
(7788, 'SCOTT', 'ANALYST', 7566, '1987-04-19', 3000, NULL, 20),
(7839, 'KING', 'PRESIDENT', NULL, '1981-11-17', 5000, NULL, 10),
(7844, 'TURNER', 'SALESMAN', 7698, '1981-09-08', 1500, 0, 30),
(7876, 'ADAMS', 'CLERK', 7788, '1987-05-23', 1100, NULL, 20),
(7900, 'JAMES', 'CLERK', 7698, '1981-12-03', 950, NULL, 30),
(7902, 'FORD', 'ANALYST', 7566, '1981-12-03', 3000, NULL, 20),
(7934, 'MILLER', 'CLERK', 7782, '1982-01-23', 1300, NULL, 10)

insert into employee values 
(8001, 'RAJESH', 'DEVELOPER', 7839, '2015-07-10', 3200, NULL, 20),
(8002, 'PRIYA', 'HR', 7839, '2012-07-25', 2800, NULL, 10),
(8003, 'VIKRAM', 'MANAGER', 7839, '2010-07-05', 4000, NULL, 30),
(8004, 'SNEHA', 'CLERK', 7839, '2018-07-15', 1500, NULL, 20),
(8005, 'ARUN', 'ANALYST', 7839, '2016-07-20', 3500, NULL, 30)

--3. Write a query to display all employees information those who joined before 5 years in the current month
select * from employee
where year(hire_date) <= year(getdate()) - 5 and month(hire_date) = month(getdate())

--4. Create table Employee with empno, ename, sal, doj columns or use your emp table and perform the following operations in a single transaction
create table employee2 (
    empno int primary key,
    ename varchar(30),
    sal int,
    doj datetime
)

begin transaction
--a. First insert 3 rows 
insert into employee2 values (1, 'AYAAN', 3000, '2017-07-10'),
 (2, 'BHAVYA', 4000, '2013-07-15'),
 (3, 'CHARAN', 3500, '2014-07-20')

 select * from employee2

-- b. update second row salary with 15% increment
update employee2 set sal = sal * 1.15
where empno = 2

save transaction s1

select * from employee2


-- c. delete first row
delete from employee2 where empno = 1

rollback transaction s1

select * from employee2

--5. Create a user defined function calculate Bonus for all employees of a  given dept using given conditions
create or alter function bonus 
(@deptno int, @salary int)
returns int
as
begin
    declare @bonus int
    if (@deptno = 10)
	begin
        set @bonus = @salary * 0.15;
	end
    else if (@deptno = 20)
	begin
        set @bonus = @salary * 0.20
	end
    else
	begin
        set @bonus = @salary * 0.05
	end
    return @bonus
end

select empno as Employee_Id,ename as Name, salary ,dbo.bonus(deptno, salary) as Bonus from employee


--6. Create a procedure to update the salary of employee by 500 whose dept name is Sales and current salary is below 1500 (use emp table)

create or alter proc update_salary
as
begin
    update e
    set e.salary = e.salary + 500
    from employee e
    join dept d on e.deptno = d.deptno
    where d.dname = 'Sales'
      and e.salary < 1500
end

exec update_salary
select * from employee



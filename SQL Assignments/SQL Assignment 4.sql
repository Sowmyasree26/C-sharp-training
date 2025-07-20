use Sql_Assignments

--Write a T-SQL Program to find the factorial of a given number.
declare @number int = 5  
declare @factorial int = 1
declare @i int = 1

while @i <= @number
begin
set @factorial=@factorial*@i
set @i=@i+1
end

print 'Factorial of ' + cast(@number as varchar) + ' is ' + cast(@factorial as varchar)

--Create a stored procedure to generate multiplication table that accepts a number and generates up to a given number. 
create or alter proc sp_multiplicatin_table 
@number int, @End int
as
begin
declare @i int=1
declare @answer int
while @i<=@end
begin
set @answer= @number * @i
print( cast(@number as varchar)+' * '+ cast(@i as varchar)+ ' = '+cast(@answer as varchar))
set @i= @i+1
end
end

exec sp_multiplicatin_table 5,10

-- Create student table
create table student (
sid int primary key,
sname varchar(50)
)

-- Create marks table
create table marks (
mid int primary key,
sid int foreign key references student(sid),
score int
)

-- Insert into student table
insert into student (sid, sname) values
(1, 'Jack'),
(2, 'Rithvik'),
(3, 'Jaspreeth'),
(4, 'Praveen'),
(5, 'Bisa'),
(6, 'Suraj');

-- Insert into marks table
insert into marks (mid, sid, score) values
(1, 1, 23),
(2, 6, 95),
(3, 4, 98),
(4, 2, 17),
(5, 3, 53),
(6, 5, 13);

--Create a function to calculate the status of the student. If student score >=50 then pass, else fail. Display the data neatly
create or alter function fn_Studentstatus (@score int)
returns varchar(10)
as
begin
declare @result varchar(10)
if @score >= 50
set @result ='Pass'
else
set @result= 'Fail'
return @result
end

select  score,dbo.fn_Studentstatus(m.score) as status
from  marks m 






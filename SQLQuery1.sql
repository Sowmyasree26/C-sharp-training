create database sql_Codechallenges

create table books(
Id int primary key,
Title varchar(100),
Author varchar(100),
Isbn float unique,
Published_date datetime)

insert into books values
(1,'My First SQL book','Mary Parker', 981483029127, '2012-02-22 12:08:17'),
(2,'My Second SQL book' , 'John Mayer', 857300923713, '1972-07-03 09:22:45'),
(3,'My Third SQL book', 'Cary Flint' , 523120967812,'2015-10-18 14:05:44')


-- Query 1(Write a query to fetch the details of the books written by author whose name ends with er.)

select * from books where author like '%er'

--Query 2(Display the Title ,Author and ReviewerName for all the books from the above table)

create table reviews(
Id int,
Book_id int references books(id),
Reviewer_name varchar(100),
content varchar(100),
rating int,
Published_date datetime)

insert into reviews values
(1,1,'John Smith','My first review',4,'2017-12-10 05:50:11.1'),
(2,2,'John Smith','My second review',5,'2017-10-13 15:05:12.6'),
(3,2,'Alice Walker','Another review',1,'2017-10-22 23:47:10')

select * from reviews


--Query 2(Display the Title ,Author and ReviewerName for all the books from the above table)

select b.title, b.author, r.reviewer_name from books b
inner join reviews r on b.id=r.book_id


-- Query 3( Display the reviewer name who reviewed more than one book.)
select reviewer_name from reviews
group by reviewer_name
having count(id)>1

create table Customers(
id int primary key,
name varchar(50),
age int,
address varchar(100),
salary float)

insert into customers values
(1,'Ramesh', 32, 'Ahmedabad',2000),
(2,'Khilan', 25, 'Delhi',1500),
(3,'kaushik', 23, 'kota',2000),
(4,'Chaitali', 25, 'Mumbai',6500),
(5,'Hardik', 27, 'Bhopal',8500),
(6,'Komal', 22, 'MP',4500),
(7,'Muffy', 24, 'Indore',10000)


-- Query 4 (Display the Name for the customer from above customer table who live in same address which has character o anywhere in address)
select name from customers where address like '%o%'

create table orders(
oid int,
date datetime,
customer_id int references customers(id),
amount int)

insert into orders values
(102,'2009-10-08 00:00:00',3,3000),
(100,'2009-10-08 00:00:00',3,1500),
(101,'2009-11-20 00:00:00',2,1560),
(103,'2008-05-20 00:00:00',4,2060)


-- Query 5 ( Write a query to display the Date,Total no of customer placed order on same Date)

select date, count( customer_id) as count 
from orders
group by date

update customers set salary = null where name ='komal'
update customers set salary = null where name ='muffy'

select * from customers

-- Query 6 (Display the Names of the Employee in lower case, whose salary is null)

select lower(name) as name from customers where salary is null

create table studentdetails(
registerNo int,
name varchar(100),
age int,
Qualification varchar(15),
mobileNo varchar(10),
Mail_Id varchar(100),
Location varchar(50),
Gender varchar(1))

insert into studentDetails values
(2,'Sai',22,'B.E', 9952836777,'Sai@gmail.com','Chennai','M'),
(3,'Kumar',20,'BSC', 7890125648,'Kumar@gmail.com','Madurai','M'),
(4,'Selvi',22,'B.Tech', 8904567342,'Selvi@gmail.com','Selam','F'),
(5,'Nisha',25,'M.E', 78345678,'Nisha@gmail.com','Theni','F'),
(6,'SaiSaran',21,'B.A', 7890345678,'saran@gmail.com','Madurai','F'),
(7,'Tom',23,'BCA', 8901234675,'Tom@gmail.com','Pune','M')

select * from studentdetails

-- Query 7(Write a sql server query to display the Gender,Total no of male and female from the above relation)
select Gender, count(gender) as Count 
from studentdetails 
group by gender
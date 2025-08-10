create database trainreservation

use trainreservation

create table trains (
train_no int primary key, 
train_name varchar(50) not null,
total_1ac int , 
available_1ac int ,
total_2ac int,  
available_2ac int , 
total_sleeper int , 
available_sleeper int ,
source varchar(50) not null, 
destination varchar(50) not null, 
isactive bit default 1 
)


alter table trains
add ticket_price_1ac float,
ticket_price_2ac float,
ticket_price_sleeper float

	
insert into trains values
(18055, 'visakha express', 10, 10, 20, 20, 30, 30,'delhi', 'visakha', 1, 2000, 1000, 800),
(18066, 'delhi express', 12, 12, 18, 18, 25, 25, 'chennai', 'delhi', 1, 2600, 1600,1000)


select*from trains


create table bookings (
booking_id int identity primary key,        
train_no int not null,                      
passenger_name varchar(50) not null,        
class varchar(20) not null check (class in ('1ac', '2ac', 'sleeper')),
berths_booked int not null,               
journey_date date not null,                 
status varchar(20) default 'booked' check (status in ('booked', 'cancelled')),
total_cost float null,                                      
foreign key (train_no) references trains(train_no) 
)
 

 select*from bookings

 
 create table admintable (
    admin_id int primary key identity,
    username varchar(50) not null unique,
    password varchar(50) not null
)

insert into admintable (username, password)
values ('sowmya', '1806652')

select *from admintable


create table cancellation (
    cancellation_id int identity primary key,
    booking_id int not null,
    ticket_cancelled bit default 1,
    refund_amount float,
    date_of_cancellation date default getdate(),
    foreign key (booking_id) references bookings(booking_id)
)


create or alter  proc sp_validateadmin
    @username varchar(50),
    @password varchar(50)
as
begin
    set nocount on;
 
    if exists (
        select 1
        from admintable
        where username = @username and password = @password
    )
    begin
        select 'valid' as status;
    end
    else
    begin
        select 'invalid' as status;
    end
end


create or alter proc sp_addtrain
    @train_no int,
    @train_name varchar(50),
    @total_1ac int,
    @total_2ac int,
    @total_sleeper int,
    @source varchar(50),
    @destination varchar(50),
    @ticket_price_1ac float,
    @ticket_price_2ac float,
    @ticket_price_sleeper float 
as
begin

    insert into trains 
    (
        train_no, train_name, total_1ac, total_2ac,  total_sleeper, available_1ac, available_2ac, available_sleeper, 
        source, destination, ticket_price_1ac, ticket_price_2ac, ticket_price_sleeper, isactive
    )
    values 
    (
        @train_no, @train_name, @total_1ac, @total_2ac,  @total_sleeper, @total_1ac,  @total_2ac, @total_sleeper,   
        @source, @destination, @ticket_price_1ac, @ticket_price_2ac, @ticket_price_sleeper, 1 
    )
end
 

create or alter proc sp_modifytrain
    @train_no int,
    @train_name varchar(50),
    @source varchar(50),
    @destination varchar(50),
    @ticket_price_1ac float,
    @ticket_price_2ac float,
    @ticket_price_sleeper float
as
begin
    update trains
    set train_name = @train_name,
        source = @source,
        destination = @destination,
        ticket_price_1ac = @ticket_price_1ac,
        ticket_price_2ac = @ticket_price_2ac,
        ticket_price_sleeper = @ticket_price_sleeper
    where train_no = @train_no and isactive = 1
end


create or alter proc sp_deletetrain
    @train_no int
as
begin
    update trains 
    set isactive = 0
    where train_no = @train_no

    if @@rowcount = 0
        print 'Train not found'
    else
        print 'Train deleted successfully'
end



create or alter proc sp_bookticket 
    @train_no int, 
    @passenger_name nvarchar(100), 
    @class nvarchar(20), 
    @berths_booked int, 
    @journey_date date, 
    @total_cost float output
as
begin
    if @journey_date < cast(getdate() as date)
    begin
        print 'error: cannot book ticket for a past date.'
        return
    end
    declare @ticket_price float, @available_berths int
    select 
        @ticket_price = case 
                            when @class = '1ac' then ticket_price_1ac 
                            when @class = '2ac' then ticket_price_2ac 
                            when @class = 'sleeper' then ticket_price_sleeper 
                        end,
        @available_berths = case 
                                when @class = '1ac' then available_1ac 
                                when @class = '2ac' then available_2ac   
                                when @class = 'sleeper' then available_sleeper 
                            end
    from trains 
    where train_no = @train_no
    if @available_berths is null
    begin
        print 'No available berths...'
        return
    end
    if @available_berths < @berths_booked
    begin
        print 'Enough berths not available :('
        return
    end
    set @total_cost = @ticket_price * @berths_booked
	insert into bookings (train_no, passenger_name, class, berths_booked, journey_date, total_cost, status)
    values (@train_no, @passenger_name, @class, @berths_booked, @journey_date, @total_cost, 'booked')
    if @class = '1ac'
        update trains set available_1ac = available_1ac - @berths_booked where train_no = @train_no
    else if @class = '2ac'
        update trains set available_2ac = available_2ac - @berths_booked where train_no = @train_no
	else if @class = 'sleeper'
        update trains set available_sleeper = available_sleeper - @berths_booked where train_no = @train_no
    print 'booking successful... total ticket cost: ' + cast(@total_cost as varchar(50))
end
 
 
 create or alter proc sp_cancelticket 
    @booking_id int, 
    @refund_amount float output
as
begin
    declare @train_no int, 
            @class varchar(20), 
            @berths_booked int, 
            @status varchar(20), 
            @total_cost float
    select @train_no = train_no, 
           @class = class, 
           @berths_booked = berths_booked, 
           @status = status, 
           @total_cost = total_cost
    from bookings 
    where booking_id = @booking_id
    if @status = 'booked'
    begin
        if @class = '1ac' 
        begin 
            update trains 
            set available_1ac = available_1ac + @berths_booked 
            where train_no = @train_no 
        end
        else if @class = '2ac' 
        begin 
            update trains 
            set available_2ac = available_2ac + @berths_booked 
            where train_no = @train_no
        end
        else if @class = 'sleeper' 
        begin 
            update trains 
            set available_sleeper = available_sleeper + @berths_booked 
            where train_no = @train_no
        end
        update bookings 
        set status = 'cancelled' 
        where booking_id = @booking_id
        set @refund_amount = @total_cost * 0.50
		insert into cancellation (booking_id, ticket_cancelled, refund_amount)
        values (@booking_id, 1, @refund_amount)
        print 'cancellation successful.'
    end
    else
    begin
        print 'cancellation failed...'
        set @refund_amount = 0
    end
end
 

create or alter proc sp_showalltrains
as
begin
    select
        train_no,
        train_name,
        source,
        destination,
        available_1ac,
        ticket_price_1ac,
        available_2ac,
        ticket_price_2ac,
        available_sleeper,
        ticket_price_sleeper
    from
        trains
    where
        isactive = 1 
    order by
        train_no
end


create or alter proc sp_showallbookings
as
begin
    select booking_id, train_no, passenger_name, class, berths_booked, journey_date, status
    from bookings
    order by journey_date desc
end
 
exec sp_showallbookings


drop table cancellation
drop table bookings
drop table trains
CREATE DATABASE Project1DB;
GO

CREATE SCHEMA pizzaproject;
GO

drop table pizzaproject.users
drop table pizzaproject.orders
drop table pizzaproject.locations

Create table pizzaproject.users
(
	username nvarchar(30) NOT NULL, 
	firstname nvarchar(30) NOT NULL,
	lastname nvarchar(30) NOT NULL,
	defaultlocationid int NOT NULL,
	primary key (username)

);



create table pizzaproject.orders
(

	locationID int NOT NULL,
	username nvarchar(30) NOT NULL foreign key references pizzaproject.users(username), 
	ordertime datetime NOT NULL,
	currentprice int NOT NULL,
	orderid int NOT NULL,  
	cheesepizza int NOT NULL,
	pepperonipizza int NOT NULL,
	sausagepizza int NOT NULL,
	primary key (orderid)
);



create table pizzaproject.locations(

	 id int NOT NULL,
	 cheeseinventory int NOT NULL,
	 pepperoniinventory int NOT NULL,
	 sausageinventory int NOT NULL,
	 orderhistory datetime NOT NULL
	 primary key (id)

);



insert into users.firstname
values('bob');

insert into users.lastname
values('barker');

insert into users.defaultlocationid
values('0');

insert into users.userorderhistory
values('');

insert into users.username
values('bobby1');




insert into orders.locationID
values('0');

insert into orders.username
values('bob');

insert into orders.ordertime
values('barker');


insert into order.currentprice
values('');

insert into orders.orderid
values('');





insert into locations.ingredients
values('cheese', 'pepperoni', 'sausage' );

insert into locations.orderhistory
values('');












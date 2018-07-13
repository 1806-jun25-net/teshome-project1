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

	locationID int NOT NULL foreign key references pizzaproject.locations(id),
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
	 primary key (id)

);



insert into pizzaproject.users
values('bobby1', 'bob', 'barker', '0');

insert into pizzaproject.users
values('lyket', 'Lyke', 'Teshome', '0');

insert into pizzaproject.users
values('mac', 'mac', 'n chesse', '1');



insert into pizzaproject.orders
values('0', 'bobby1', '7:00', '$10', '2', '7', '7', '7');


insert into pizzaproject.locations
values(0, 30, 30, 30), (1, 30, 30, 30);


select * from pizzaproject.orders

delete from pizzaproject.orders where orderid = 1










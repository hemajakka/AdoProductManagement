create database productdb
use productdb
create table product(id int identity  primary key,productname varchar(20),productdescription varchar(30),quantity int,price int  )
select * from product
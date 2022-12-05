create database likedatabase
use likedatabase



create table liketable(
    id int primary key identity,
    backgroundColor varchar(150),
    lettersColor varchar(5),
    enjoyed bit,
    customer_location varchar(200),
    customer_date datetime
)

drop table liketable

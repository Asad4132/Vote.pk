drop database VotingSystem

go

create database VotingSystem

go

use VotingSystem
--use master
go

--------------------------------------------------------
-------------------Creating Tables----------------------

--Type: 1 -- Unregistered Voter
--Type: 2 -- Registered Voter
--Type: 3 -- Admin


create table LoginTable
(
	LoginID int identity(1,1) primary key,
	Password varchar(20) not null,
	Email varchar(30) not null unique,
	Type int not null,
)

/*
insert into LoginTable values ('2580', 'admin@gmail.com', 3)
*/

go

create table Constituency
(
	Number int primary key,
	Name varchar(20)
)

go
--to make a restore point
create table DeletedConstituency
(
	ID int,
	Number int primary key,
	Name varchar(20)
)

go

create table Voter
(
	ID int primary key foreign key references LoginTable(LoginID),
	Name varchar(30) not null,
	GuardianName varchar(30) not null,
	Gender varchar(1) not null,
	DOB Date not null,
	CNIC varchar(13) not null unique,
	Phone varchar(11),
	Address varchar(40) not null,
	Constituency int foreign key references Constituency(Number),
)

go

create table Candidate
(
	ID int foreign key references Voter(ID),
	Details varchar(100) not null,
	ElectoralSignName varchar(20) not null,
	ElectoralSignImage varbinary(max) not null,
	Constituency int foreign key references Constituency(Number) not null,
	Votes int 

	primary key(ID,Constituency)
)

go

create table Vote
(
	VoterID int foreign key references Voter(ID) primary key,
	CandidateID int
)

go

select * from LoginTable
select * from Constituency
select * from Voter
select * from Candidate
select * from Vote
select * from DeletedConstituency

go
/*
drop table Voter
drop table Vote
drop table PP_Constituency
drop table NA_Constituency
drop table Candidate
drop table LoginTable
*/

insert into LoginTable values(1234,'asad@gmail.com',3)

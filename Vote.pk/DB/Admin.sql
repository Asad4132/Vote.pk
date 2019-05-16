use VotingSystem
--use master
go

create procedure Constituencies
as
begin
select * from Constituency
end

go

create procedure AddConstituency
@number int,
@name varchar(20),
@status int output

as
begin
	begin transaction transcation1
		begin try
			insert  into Constituency values (@number, @name)
			set @status = 1
			commit transaction transaction1
		end try
		begin catch
			set @status=0
			rollback transaction transaction1
		end catch
	
end

go

declare @dnumber int = 121,
@dname varchar(20) = 'Lahore',
@dstatus int
execute AddConstituency
@number = @dnumber,
@name = @dname,
@status = @dstatus output

go

/*Delete Constituency*/

create procedure DeleteConstituency
@number int,
@status int output

as
begin
	begin transaction transcation1
		begin try
			insert into DeletedConstituency values(1, @number, (select name from Constituency where Number=1))
			delete from Constituency where number=@number
			set @status = 1
			commit transaction transaction1
		end try
		begin catch
			set @status=0
			rollback transaction transaction1
		end catch
end

go

create procedure UndoDeleteConstituency
as
begin
	begin transaction transcation1
		begin try
			insert into Constituency values((select number from DeletedConstituency where id=1), (select name from DeletedConstituency where id=1))
			commit transaction transaction1
		end try
		begin catch
			rollback transaction transaction1
		end catch
end

go

/*Register a Voter */

create procedure RegisterVoter
@Name varchar(50),
@GuardianName varchar(50),
@Gender char(1),
@DOB Date,
@CNIC char(13),
@Phone varchar(50),
@Address varchar(50),
@Constituency int,
@Email varchar(50),
@ID int output,
@Status int output

as
begin
	begin transaction [transaction1]
		
		begin try
		update LoginTable set Type=2 where Email=@Email
		select @ID = LoginID from LoginTable where Email=@Email	
		insert into Voter values (@ID, @Name, @GuardianName, @Gender, @DOB, @CNIC, @Phone, @Address, @Constituency)
		set @Status=1
		commit transaction [transaction1]
		end try
		
		begin catch
		set @Status=0
		rollback transaction [transaction1]
		end catch
end

go

declare @dname varchar(50) = 'Asad',
@dguardianname varchar(50) = 'Ejaz',
@dgender varchar(1) = 'M',
@ddob date = '09-21-1996',
@dcnic varchar(13) = '3520222068721',
@dphone varchar(11) = '03048969096',
@daddress varchar(50) = 'sadubofnaiondsono',
@dconstituency int = 121,
@demail varchar(30)='asadrehman6623@gmail.com',
@did int,
@dstatus int

execute RegisterVoter

@name=@dname,
@guardianname=@dgender,
@gender=@dgender,
@dob=@ddob,
@cnic = @dcnic,
@phone=@dphone,
@address=@daddress,
@constituency = @dconstituency,
@email=@demail, 
@status=@dstatus output,
@id=@did output


go
/* Deletes the voter from voter list and change status to unregistered voter in login table*/

create procedure DeleteVoter
@CNIC varchar(13),
@status int output

as
begin
	begin transaction transcation1
		begin try
			update LoginTable set [Type] = 1 where LoginID=(select ID from Voter where CNIC=@CNIC)
			delete from Voter where CNIC=@CNIC
			
			set @status = 1
			commit transaction transaction1
		end try
		begin catch
			set @status=0
			rollback transaction transaction1
		end catch
end

go

/*Register a Candidate for Assembly*/

create procedure RegisterCandidate

@Email varchar(50),
@Constituency int,
@Details varchar(100),
@ElectoralSignName varchar(20),
@ElectoralSignImage varbinary(max),
@ID int output,
@Status int output

as
begin
	begin transaction [transaction1]
		
		begin try
		select @ID = ID from Voter V join LoginTable L on V.ID=L.LoginID where L.Email=@Email	
		insert into Candidate values (@ID, @Details, @ElectoralSignName, @ElectoralSignImage, @Constituency,0)
		set @Status=1
		commit transaction [transaction1]
		end try
		
		begin catch
		set @Status=0
		rollback transaction [transaction1]
		end catch
end

go

declare @demail varchar(30) = 'asadrehman6623@gmail.com',
@dconstituency int = 121,
@ddetails varchar(100) = 'fsdoihsdoihoisdhio',
@delectoralsignname varchar(20) = 'Eagle',
@delectoralsignimage varbinary(max) = 0xFFDFF102192F,
@did int,
@dstatus int

execute RegisterCandidate

@email = @demail,
@constituency = @dconstituency,
@details = @ddetails,
@electoralsignname = @delectoralsignname,
@electoralsignimage = @delectoralsignimage,
@id=@did output,
@status = @dstatus output

go

/*Delete Candidate*/

create procedure DeleteCandidate
@CNIC varchar(13),
@Constituency int,
@status int output

as
begin
	begin transaction transcation1
		if exists (select * from Candidate where ID=(select ID from Voter where CNIC=@CNIC) and Votes>0 )
			begin
				begin try
					delete from Candidate where ID=(select ID from Voter where CNIC=@CNIC) and Constituency=@Constituency
					set @status = 1
					commit transaction transaction1
				end try
				begin catch
					set @status=0
					rollback transaction transaction1
				end catch
			end
		else
			begin	 
				set @status=0
			end
end

go

/*This function returns th information of candidates*/
create procedure GetCandidateInfo
as
begin
	select V.Name, V.CNIC,  DATEDIFF(YEAR, V.DOB, GETDATE()) as Age, V.Gender, V.Phone, C.Constituency, C.ElectoralSignName, C.ElectoralSignImage from Candidate C join Voter V on C.ID=V.ID
end

go

/*This function returns th information of Voters*/
create procedure GetVoterInfo
as
begin
	select V.Name, V.CNIC,  DATEDIFF(YEAR, V.DOB, GETDATE()) as Age, V.Gender, V.Phone, V.Constituency, V.Address from Voter V
end

go

/*THIS TRIGGER RESTRICTS TABLE DELETE*/
create trigger DontDeleteTable
on database
for drop_table
as
begin
	print('Table deletion is not allowed')
end

go


/*THIS TRIGGER RESTRICS PROCEDURE DELETE*/
create trigger DontDeleteProcedure
on database
FOR DROP_PROCEDURE
as
begin
	print('Procedure deletion is not allowed')
end

go
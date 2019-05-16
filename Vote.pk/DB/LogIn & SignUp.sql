use VotingSystem
--use master
go

/*
Signups new unregistered voter

returns status = 1 on success
returns status = 0 if voter already exists
*/
create procedure SignUp

@email varchar(30),
@password varchar(20),
@status int output

as
begin
	if not exists(select * from LoginTable where email=@email)
	begin
		insert into LoginTable values(@password, @email, 1)
		
		set @status = 1
	end
	
	else
	begin
		set @status = 0
	end
end

go

declare @demail varchar(30)='asadrehman6623@gmail.com',
@dpassword varchar(20)='6623',
@dstatus int

execute SignUp

@email=@demail, 
@password=@dpassword, 


@status=@dstatus output


go

/*
LogIN

returns status = 0 if successful
		status = 1 if email not found
		status = 2 if password is wrong


returns ID of person and type of person i.e patient, doctor, admin on success
returns ID = 0, type = 0 on failure
--Type: 1 -- Unregistered Voter
--Type: 2 -- Registered Voter
--Type: 3 -- Admin
*/

create procedure [Login]

@email varchar(30),
@password varchar(20),
@status int output,
@ID int output,
@type int output

as
begin
	if exists(select * from LoginTable where email=@email)
	begin
		if @password = (select password from LoginTable where email=@email)
		begin
			select @ID = LoginID, @type = [type] from LoginTable where email=@email
			set @status = 0
		end

		else
		begin
			set @status = 2
			set @ID = 0
			set @type = 0
		end
	end

	else
	begin
		set @status = 1
		set @ID = 0
		set @type = 0
	end
end

go

declare @demail varchar(30)='asadrehman6623@gmail.com',
@dpassword varchar(20)='6623',

@dstatus int,
@dID int,
@dtype int 

execute [Login]
@email=@demail,
@password=@dpassword,
@status=@dstatus output,
@ID=@dID output,
@type=@dtype output


use VotingSystem
--use master

go

/*Get Voter Information*/
create procedure VoterInfo
@ID int,
@Name varchar(30) output,
@CNIC varchar(13) output,
@DOB Date output,
@Phone varchar(11) output,
@Constituency int output
as
begin
select @Name=V.Name, @CNIC=V.CNIC, @DOB=V.DOB, @Phone=V.Phone, @Constituency=V.Constituency from Voter V where V.ID=@ID
end
select V.Name, V.CNIC, V.DOB, V.Phone, V.Constituency from Voter V where V.ID=1
go

/*Voter's Constituency*/
create procedure VoterConstituency
@ID int,
@Constituency int output
as
begin
select @Constituency=Constituency from Voter where ID=@ID
end

go

/*Candidate List of a constituency*/
create procedure CandidateList
@Constituency int
as
begin
select V.Name, V.ID, C.ElectoralSignName, C.ElectoralSignImage from Candidate C join Voter V on C.ID=V.ID where C.Constituency=@Constituency
end

go

/*Vote*/
create procedure CastVote
@VoterID int,
@CandidateID int,
@Constituency int,
@status int output
as
begin
	begin transaction transcation1
		begin try
			insert  into Vote values (@VoterID,@CandidateID)
			update Candidate set Votes=Votes+1 where ID=@CandidateID and Constituency=@Constituency
			set @status = 1
			commit transaction transaction1
		end try
		begin catch
			set @status=0
			rollback transaction transaction1
		end catch

end

go

/*Candidate Details*/
create procedure CandidateDetails
@ID int
as
begin
select V.Name, DATEDIFF(YEAR, V.DOB, GETDATE()) as Age, C.Constituency, C.Details from Candidate C join Voter V on C.ID=V.ID where C.ID=@ID
end

/*Constituency Results*/
create procedure ConstituencyResult
@Constituency int
as
begin
select V.Name, C.ElectoralSignImage, C.Votes, C.ElectoralSignImage from Candidate C
join Voter V on C.ID=V.ID
where  C.Constituency=@Constituency
end

/*Already voted*/
create procedure AlreadyVoted

@ID int,
@status int output

as
begin
	if exists(select * from Vote where VoterID=@ID)
	begin
		
		set @status = 1
	end
	
	else
	begin
		set @status = 0
	end
end

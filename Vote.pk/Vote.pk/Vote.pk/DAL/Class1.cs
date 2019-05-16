using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;

namespace Vote.pk.DAL
{
    public class Class1
    {

        public int Signup(string email, string password, ref DataTable result)
        {
            string connectionString = System.Configuration.ConfigurationManager.AppSettings["sqlCon1"];
            SqlConnection connection = new SqlConnection(connectionString);
            int status = 0;
            try
            {
                SqlCommand Command = new SqlCommand("dbo.Signup", connection);
                Command.CommandType = CommandType.StoredProcedure;
                
                Command.Parameters.Add("@email", SqlDbType.NVarChar, 100);
                Command.Parameters["@email"].Value = email;
                Command.Parameters.Add("@password", SqlDbType.NVarChar, 100);
                Command.Parameters["@password"].Value = password;
                Command.Parameters.Add("@status", SqlDbType.Int).Direction = ParameterDirection.Output;

                connection.Open();
                Command.ExecuteNonQuery();
                status = Convert.ToInt32(Command.Parameters["@status"].Value);
            }

            catch
            {

            }

            finally
            {

                connection.Close();

            }
            return status;

        }


        public int Login(string email, string password, ref int id, ref int type, ref DataTable result)
        {
            string connectionString = System.Configuration.ConfigurationManager.AppSettings["sqlCon1"];
            SqlConnection connection = new SqlConnection(connectionString);
            int status = 0;
            try
            {
                SqlCommand Command = new SqlCommand("dbo.Login", connection);
                Command.CommandType = CommandType.StoredProcedure;

                Command.Parameters.Add("@email", SqlDbType.NVarChar, 100);
                Command.Parameters["@email"].Value = email;
                Command.Parameters.Add("@password", SqlDbType.NVarChar, 100);
                Command.Parameters["@password"].Value = password;

                Command.Parameters.Add("@status", SqlDbType.Int).Direction = ParameterDirection.Output;
                Command.Parameters.Add("@id", SqlDbType.Int).Direction = ParameterDirection.Output;
                Command.Parameters.Add("@type", SqlDbType.Int).Direction = ParameterDirection.Output;

                connection.Open();
                Command.ExecuteNonQuery();
                status = Convert.ToInt32(Command.Parameters["@status"].Value);
                id = Convert.ToInt32(Command.Parameters["@id"].Value);
                type = Convert.ToInt32(Command.Parameters["@type"].Value);

            }

            catch
            {

            }

            finally
            {

                connection.Close();

            }

            return status;
        }






        /////////////////////////Admin functions
        ///

        public int AddCostituency(string number, string name, ref DataTable result)
        {
            string connectionString = System.Configuration.ConfigurationManager.AppSettings["sqlCon1"];
            SqlConnection connection = new SqlConnection(connectionString);
            int status = 0;
            int a = Convert.ToInt32(number);
            try
            {
                SqlCommand Command = new SqlCommand("dbo.AddConstituency", connection);
                Command.CommandType = CommandType.StoredProcedure;

                Command.Parameters.Add("@number", SqlDbType.Int, 100);
                Command.Parameters["@number"].Value = a;
                Command.Parameters.Add("@name", SqlDbType.NVarChar, 100);
                Command.Parameters["@name"].Value = name;
                Command.Parameters.Add("@status", SqlDbType.Int).Direction = ParameterDirection.Output;

                connection.Open();
                Command.ExecuteNonQuery();
                status = Convert.ToInt32(Command.Parameters["@status"].Value);
            }

            catch
            {

            }

            finally
            {

                connection.Close();

            }
            return status;
        }



        public int DeleteConstituency(string number, ref DataTable result)
        {
            string connectionString = System.Configuration.ConfigurationManager.AppSettings["sqlCon1"];
            SqlConnection connection = new SqlConnection(connectionString);
            int status = 0;
            try
            {
                SqlCommand Command = new SqlCommand("dbo.DeleteConstituency", connection);
                Command.CommandType = CommandType.StoredProcedure;
                int a = Convert.ToInt32(number);
                Command.Parameters.Add("@number", SqlDbType.Int, 100);
                Command.Parameters["@number"].Value = a;
                Command.Parameters.Add("@status", SqlDbType.Int).Direction = ParameterDirection.Output;

                connection.Open();
                Command.ExecuteNonQuery();
                status = Convert.ToInt32(Command.Parameters["@status"].Value);
            }

            catch
            {

            }

            finally
            {

                connection.Close();

            }
            return status;
        }

        public int RegisterVoter(string name, string guardian, string gender, string dob, string cnic, string phone, string address, string constituency, string email, ref DataTable result)
        {
            string connectionString = System.Configuration.ConfigurationManager.AppSettings["sqlCon1"];
            SqlConnection connection = new SqlConnection(connectionString);
            int id = 0, status=0;
            DateTime a = Convert.ToDateTime(dob);
            int b = Convert.ToInt32(constituency);
            try
            {
                SqlCommand Command = new SqlCommand("dbo.RegisterVoter", connection);
                Command.CommandType = CommandType.StoredProcedure;

                Command.Parameters.Add("@name", SqlDbType.NVarChar, 100);
                Command.Parameters["@name"].Value = name;
                Command.Parameters.Add("@guardianname", SqlDbType.NVarChar, 100);
                Command.Parameters["@guardianname"].Value = guardian;
                Command.Parameters.Add("@gender", SqlDbType.NVarChar, 100);
                Command.Parameters["@gender"].Value = gender;

                Command.Parameters.Add("@dob", SqlDbType.Date);
                Command.Parameters["@dob"].Value = a;

                Command.Parameters.Add("@cnic", SqlDbType.NVarChar, 100);
                Command.Parameters["@cnic"].Value = cnic;

                Command.Parameters.Add("@phone", SqlDbType.NVarChar, 100);
                Command.Parameters["@phone"].Value = phone;
                Command.Parameters.Add("@address", SqlDbType.NVarChar, 100);
                Command.Parameters["@address"].Value = address;

                Command.Parameters.Add("@email", SqlDbType.NVarChar, 100);
                Command.Parameters["@email"].Value = email;

                Command.Parameters.Add("@constituency", SqlDbType.Int, 100);
                Command.Parameters["@constituency"].Value = b;

                Command.Parameters.Add("@id", SqlDbType.Int).Direction = ParameterDirection.Output;
                Command.Parameters.Add("@status", SqlDbType.Int).Direction = ParameterDirection.Output;

                connection.Open();
                Command.ExecuteNonQuery();
                id = Convert.ToInt32(Command.Parameters["@id"].Value);
                status = Convert.ToInt32(Command.Parameters["@status"].Value);

            }

            catch
            {

            }

            finally
            {

                connection.Close();

            }

            return status;
        }


        public int DeleteVoter(string id, ref DataTable result)
        {
            string connectionString = System.Configuration.ConfigurationManager.AppSettings["sqlCon1"];
            SqlConnection connection = new SqlConnection(connectionString);
            int status = 0;
            try
            {
                SqlCommand Command = new SqlCommand("dbo.DeleteVoter", connection);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.Add("@cnic", SqlDbType.NVarChar, 100);
                Command.Parameters["@cnic"].Value = id;
                Command.Parameters.Add("@status", SqlDbType.Int).Direction = ParameterDirection.Output;

                connection.Open();
                Command.ExecuteNonQuery();
                status = Convert.ToInt32(Command.Parameters["@status"].Value);
            }

            catch
            {

            }

            finally
            {

                connection.Close();

            }
            return status;
        }


        public int RegisterCandidate(string email, string constituency, string details, string electoralSignName, byte[] electoralSignImage, ref DataTable result)
        {
            string connectionString = System.Configuration.ConfigurationManager.AppSettings["sqlCon1"];
            SqlConnection connection = new SqlConnection(connectionString);
            int constituencynumber = Convert.ToInt32(constituency);
            int id = 0, status = 0;
            try
            {
                SqlCommand Command = new SqlCommand("dbo.RegisterCandidate", connection);
                Command.CommandType = CommandType.StoredProcedure;

                Command.Parameters.Add("@email", SqlDbType.NVarChar, 100);
                Command.Parameters["@email"].Value = email;
                Command.Parameters.Add("@constituency", SqlDbType.Int, 100);
                Command.Parameters["@constituency"].Value = constituencynumber;
                Command.Parameters.Add("@details", SqlDbType.NVarChar, 100);
                Command.Parameters["@details"].Value = details;

                Command.Parameters.Add("@electoralSignName", SqlDbType.NVarChar,100);
                Command.Parameters["@electoralSignName"].Value = electoralSignName;

                Command.Parameters.Add("@electoralSignImage", SqlDbType.VarBinary);
                Command.Parameters["@electoralSignImage"].Value = electoralSignImage;


                Command.Parameters.Add("@id", SqlDbType.Int).Direction = ParameterDirection.Output;
                Command.Parameters.Add("@status", SqlDbType.Int).Direction = ParameterDirection.Output;

                connection.Open();
                Command.ExecuteNonQuery();
                id = Convert.ToInt32(Command.Parameters["@id"].Value);
                status = Convert.ToInt32(Command.Parameters["@status"].Value);

            }

            catch
            {

            }

            finally
            {

                connection.Close();

            }

            return status;
        }


        public int DeleteCandidate(string cnic, string constituency, ref DataTable result)
        {
            string connectionString = System.Configuration.ConfigurationManager.AppSettings["sqlCon1"];
            SqlConnection connection = new SqlConnection(connectionString);
            int status = 0;
            int a = Convert.ToInt32(constituency);
            try
            {
                SqlCommand Command = new SqlCommand("dbo.DeleteCandidate", connection);
                Command.CommandType = CommandType.StoredProcedure;

                Command.Parameters.Add("@cnic", SqlDbType.NVarChar, 100);
                Command.Parameters["@cnic"].Value = cnic;
                Command.Parameters.Add("@constituency", SqlDbType.Int, 100);
                Command.Parameters["@constituency"].Value = a;
                Command.Parameters.Add("@status", SqlDbType.Int).Direction = ParameterDirection.Output;

                connection.Open();
                Command.ExecuteNonQuery();
                status = Convert.ToInt32(Command.Parameters["@status"].Value);
            }

            catch
            {

            }

            finally
            {

                connection.Close();

            }
            return status;
        }


        public void GetCandidateInfo(ref DataTable result)
        {
            string connectionString = System.Configuration.ConfigurationManager.AppSettings["sqlCon1"];
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                SqlCommand Command = new SqlCommand("dbo.GetCandidateInfo", connection);
                Command.CommandType = CommandType.StoredProcedure;

                DataSet ds = new DataSet();
                connection.Open();
                Command.ExecuteNonQuery();
                using (SqlDataAdapter da = new SqlDataAdapter(Command))
                    da.Fill(ds);
                result = ds.Tables[0];

            }

            catch
            {

            }

            finally
            {

                connection.Close();

            }
        }



        public void GetVoterInfo(ref DataTable result)
        {
            string connectionString = System.Configuration.ConfigurationManager.AppSettings["sqlCon1"];
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                SqlCommand Command = new SqlCommand("dbo.GetVoterInfo", connection);
                Command.CommandType = CommandType.StoredProcedure;

                DataSet ds = new DataSet();
                connection.Open();
                Command.ExecuteNonQuery();
                using (SqlDataAdapter da = new SqlDataAdapter(Command))
                    da.Fill(ds);
                result = ds.Tables[0];

            }

            catch
            {

            }

            finally
            {

                connection.Close();

            }
        }


        /////////////////////Voter Functions

        public void VoterInfo(int id, ref string name, ref string CNIC, ref string DOB, ref string phone, ref string constituency, ref DataTable result)
        {
            string connectionString = System.Configuration.ConfigurationManager.AppSettings["sqlCon1"];
            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                SqlCommand Command = new SqlCommand("dbo.VoterInfo", connection);
                Command.CommandType = CommandType.StoredProcedure;

                Command.Parameters.Add("@id", SqlDbType.Int);
                Command.Parameters["@id"].Value = id;


                Command.Parameters.Add("@name", SqlDbType.NVarChar, 100).Direction = ParameterDirection.Output;
                Command.Parameters.Add("@CNIC", SqlDbType.NVarChar, 100).Direction = ParameterDirection.Output;
                Command.Parameters.Add("@DOB", SqlDbType.Date).Direction = ParameterDirection.Output;
                Command.Parameters.Add("@phone", SqlDbType.NVarChar, 100).Direction = ParameterDirection.Output;
                Command.Parameters.Add("@constituency", SqlDbType.Int).Direction = ParameterDirection.Output;

                connection.Open();
                Command.ExecuteNonQuery();
                name = Convert.ToString(Command.Parameters["@name"].Value);
                CNIC = Convert.ToString(Command.Parameters["@CNIC"].Value);
                DOB = Convert.ToString(Command.Parameters["@DOB"].Value);
                phone = Convert.ToString(Command.Parameters["@phone"].Value);
                constituency = Convert.ToString(Command.Parameters["@constituency"].Value);


            }

            catch
            {

            }

            finally
            {

                connection.Close();

            }
        }

        public int VoterConstituency(int id, ref DataTable result)
        {
            string connectionString = System.Configuration.ConfigurationManager.AppSettings["sqlCon1"];
            SqlConnection connection = new SqlConnection(connectionString);
            int constituency = 0;
            try
            {
                SqlCommand Command = new SqlCommand("dbo.VoterConstituency", connection);
                Command.CommandType = CommandType.StoredProcedure;
                int a = Convert.ToInt32(id);
                Command.Parameters.Add("@id", SqlDbType.Int);
                Command.Parameters["@id"].Value = a;
                Command.Parameters.Add("@constituency", SqlDbType.Int).Direction = ParameterDirection.Output;

                connection.Open();
                Command.ExecuteNonQuery();
                constituency = Convert.ToInt32(Command.Parameters["@constituency"].Value);
            }

            catch
            {

            }

            finally
            {

                connection.Close();

            }
            return constituency;
        }


        public void CandidateList(int constituency, ref DataTable result)
        {
            string connectionString = System.Configuration.ConfigurationManager.AppSettings["sqlCon1"];
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                SqlCommand Command = new SqlCommand("dbo.CandidateList", connection);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.Add("@constituency", SqlDbType.Int, 100);
                Command.Parameters["@constituency"].Value = constituency;
                DataSet ds = new DataSet();
                connection.Open();
                Command.ExecuteNonQuery();
                using (SqlDataAdapter da = new SqlDataAdapter(Command))
                    da.Fill(ds);
                result = ds.Tables[0];

            }

            catch
            {

            }

            finally
            {

                connection.Close();

            }
        }


        public int VoterConstituency(string voterID, string candidateID, ref DataTable result)
        {
            string connectionString = System.Configuration.ConfigurationManager.AppSettings["sqlCon1"];
            SqlConnection connection = new SqlConnection(connectionString);
            int status = 0;
            try
            {
                SqlCommand Command = new SqlCommand("dbo.VoterConstituency", connection);
                Command.CommandType = CommandType.StoredProcedure;
                int a = Convert.ToInt32(voterID);
                int b = Convert.ToInt32(candidateID);
                Command.Parameters.Add("@VoterID", SqlDbType.Int, 100);
                Command.Parameters["@VoterID"].Value = a;
                Command.Parameters.Add("@candidateID", SqlDbType.Int, 100);
                Command.Parameters["@candidateID"].Value = b;
                Command.Parameters.Add("@status", SqlDbType.Int).Direction = ParameterDirection.Output;

                connection.Open();
                Command.ExecuteNonQuery();
                status = Convert.ToInt32(Command.Parameters["@status"].Value);
            }

            catch
            {

            }

            finally
            {

                connection.Close();

            }
            return status;
        }

        public void CandidateDetails(int id, ref DataTable result)
        {
            string connectionString = System.Configuration.ConfigurationManager.AppSettings["sqlCon1"];
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                SqlCommand Command = new SqlCommand("dbo.CandidateDetails", connection);
                Command.CommandType = CommandType.StoredProcedure;
                int a = Convert.ToInt32(id);
                Command.Parameters.Add("@constituency", SqlDbType.Int, 100);
                Command.Parameters["@constituency"].Value = a;
                DataSet ds = new DataSet();
                connection.Open();
                Command.ExecuteNonQuery();
                using (SqlDataAdapter da = new SqlDataAdapter(Command))
                    da.Fill(ds);
                result = ds.Tables[0];

            }

            catch
            {

            }

            finally
            {

                connection.Close();

            }
        }

        public void ConstituencyResult(int constituency, ref DataTable result)
        {
            string connectionString = System.Configuration.ConfigurationManager.AppSettings["sqlCon1"];
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                SqlCommand Command = new SqlCommand("dbo.ConstituencyResult", connection);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.Add("@constituency", SqlDbType.Int);
                Command.Parameters["@constituency"].Value = constituency;
                DataSet ds = new DataSet();
                connection.Open();
                Command.ExecuteNonQuery();
                using (SqlDataAdapter da = new SqlDataAdapter(Command))
                    da.Fill(ds);
                result = ds.Tables[0];

            }

            catch
            {

            }

            finally
            {

                connection.Close();

            }
        }


        public void Constituencies(ref DataTable result)
        {
            string connectionString = System.Configuration.ConfigurationManager.AppSettings["sqlCon1"];
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                SqlCommand Command = new SqlCommand("dbo.Constituencies", connection);
                Command.CommandType = CommandType.StoredProcedure;

                DataSet ds = new DataSet();
                connection.Open();
                Command.ExecuteNonQuery();
                using (SqlDataAdapter da = new SqlDataAdapter(Command))
                    da.Fill(ds);
                result = ds.Tables[0];

            }

            catch
            {

            }

            finally
            {

                connection.Close();

            }
        }

        public int AlreadyVoted(int voterID, ref DataTable result)
        {
            string connectionString = System.Configuration.ConfigurationManager.AppSettings["sqlCon1"];
            SqlConnection connection = new SqlConnection(connectionString);
            int status = 0;
            try
            {
                SqlCommand Command = new SqlCommand("dbo.AlreadyVoted", connection);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.Add("@VoterID", SqlDbType.Int, 100);
                Command.Parameters["@VoterID"].Value = voterID;
                Command.Parameters.Add("@status", SqlDbType.Int).Direction = ParameterDirection.Output;

                connection.Open();
                Command.ExecuteNonQuery();
                status = Convert.ToInt32(Command.Parameters["@status"].Value);
            }

            catch
            {

            }

            finally
            {

                connection.Close();

            }
            return status;
        }

        public int CastVote(int voterID, string candidateID, int Constituency, ref DataTable result)
        {
            string connectionString = System.Configuration.ConfigurationManager.AppSettings["sqlCon1"];
            SqlConnection connection = new SqlConnection(connectionString);
            int status = 0;
            int a = Convert.ToInt32(candidateID);
            try
            {
                SqlCommand Command = new SqlCommand("dbo.CastVote", connection);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.Add("@VoterID", SqlDbType.Int, 100);
                Command.Parameters["@VoterID"].Value = voterID;
                Command.Parameters.Add("@CandidateID", SqlDbType.Int, 100);
                Command.Parameters["@CandidateID"].Value = a;
                Command.Parameters.Add("@Constituency", SqlDbType.Int, 100);
                Command.Parameters["@Constituency"].Value = Constituency;
                Command.Parameters.Add("@status", SqlDbType.Int).Direction = ParameterDirection.Output;

                connection.Open();
                Command.ExecuteNonQuery();
                status = Convert.ToInt32(Command.Parameters["@status"].Value);
            }

            catch
            {

            }

            finally
            {

                connection.Close();

            }
            return status;
        }

        public void UndoDeleteConstituency(ref DataTable result)
        {
            string connectionString = System.Configuration.ConfigurationManager.AppSettings["sqlCon1"];
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                SqlCommand Command = new SqlCommand("dbo.CastVote", connection);
                Command.CommandType = CommandType.StoredProcedure;

                connection.Open();
                Command.ExecuteNonQuery();

            }

            catch
            {

            }

            finally
            {

                connection.Close();

            }

        }

    }
}
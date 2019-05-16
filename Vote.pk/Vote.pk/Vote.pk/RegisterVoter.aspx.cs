using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Vote.pk
{
    public partial class RegisterVoter : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DAL.Class1 userDal = new DAL.Class1();
            DataTable DT = new DataTable();
            int status = userDal.RegisterVoter(name.Text, guardianname.Text, gender.Text, dob.Text, cnic.Text, phone.Text, address.Text, constituency.Text, email.Text, ref DT);
            if (status == 1)
            {
                label1.Text = "Registeration Successfull";
            }
            else if (status == 0)
            {
                label1.Text = "Registration Unsuccessful (maybe the voter is already registered OR Voter doesnot have an account)";
            }
        }
    }
}
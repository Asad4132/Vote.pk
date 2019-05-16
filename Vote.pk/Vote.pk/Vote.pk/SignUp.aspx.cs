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
    public partial class SignUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DAL.Class1 userDal = new DAL.Class1();
            DataTable DT = new DataTable();

            int status = userDal.Signup(email.Text, password.Text, ref DT);

            if (status == 1)
            {
                label1.Text = "Your account is signed up successfully. Please visit admit to become a registered voter.";
            }
            else if (status == 0)
            {
                label1.Text = "Email already exists";
            }
        }
    }
}
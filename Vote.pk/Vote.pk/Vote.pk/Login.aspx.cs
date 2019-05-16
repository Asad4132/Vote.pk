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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DAL.Class1 userDal = new DAL.Class1();
            DataTable DT = new DataTable();
            int id = 0, type = 0;

            int status = userDal.Login(email.Text, password.Text, ref id, ref type, ref DT);

            Session["Type"] = type;
            if (status == 1)
            {
                label1.Text = "Email not found";
            }
            else if (status == 2)
            {
                label1.Text = "Password is Incorrect";
            }
            if (type == 2 && id != 0)
            {
                Session["VoterID"] = id;
                Response.Redirect("VoterHome.aspx");
            }
            else if (type == 1 && id != 0)
            {
                label1.Text = "Please visit admit to become a registered voter.";
            }
            else if (type == 3 && id != 0)
            {
                Session["AdminID"] = id;
                Response.Redirect("AdminHome.aspx");
            }
        }
    }
}
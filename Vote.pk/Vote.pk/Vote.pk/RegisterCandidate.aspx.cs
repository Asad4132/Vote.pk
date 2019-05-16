using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace Vote.pk
{
    public partial class RegisterCandidate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DAL.Class1 userDal = new DAL.Class1();
            DataTable DT = new DataTable();
            int status = userDal.RegisterCandidate(email.Text, constituency.Text, details.Text, electoralsignname.Text, file.FileBytes, ref DT);
            if (status == 1)
            {
                label1.Text = "Registeration Successfull";
            }
            else if (status == 0)
            {
                label1.Text = "Registration Unsuccessful";
            }
        }
    }
}
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
    public partial class Candidates : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DAL.Class1 userDal = new DAL.Class1();
                DataTable DT = new DataTable();
                userDal.GetCandidateInfo(ref DT);
                GridView1.DataSource = DT;
                GridView1.DataBind();
            }
        }

        protected void GridView1_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            //if (e.CommandName != "Approved") return;
            //int id = Convert.ToInt32(e.CommandArgument);
            // do something
            // int index = Convert.ToInt32(e.CommandArgument);


            //GridViewRow row = GridView1.Rows[index];

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string CommandName = btn.CommandName;
            string CommandArgument = btn.CommandArgument;
            string[] arg = new string[2];
            arg = CommandArgument.ToString().Split(';');
            DAL.Class1 userDal = new DAL.Class1();
            DataTable DT = new DataTable();
            int status = userDal.DeleteCandidate(arg[0], arg[1], ref DT);

            if (status == 1)
            {
                label1.Text = "Candidate Deleted";
            }
            else if (status == 0)
            {
                label1.Text = "Cannot Delete the Candidate";
            }

        }
    }
}
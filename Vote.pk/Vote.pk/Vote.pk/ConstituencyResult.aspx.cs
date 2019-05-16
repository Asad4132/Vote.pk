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
    public partial class Constituency_Result : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DAL.Class1 userDal = new DAL.Class1();
                DataTable DT = new DataTable();
                int constituency = Convert.ToInt32(userDal.VoterConstituency((int)Session["VoterID"], ref DT));
                userDal.ConstituencyResult(constituency, ref DT);
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
    }
}
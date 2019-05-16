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
    public partial class VoterHome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DAL.Class1 userDal = new DAL.Class1();
            DataTable DT = new DataTable();
            string myname = "a", mycnic = "b", mydob = "c", myphone = "d", myconstituency = "e";
            userDal.VoterInfo((int)Session["VoterID"], ref myname, ref mycnic, ref mydob, ref myphone, ref myconstituency, ref DT);
            name.Text = myname;
            cnic.Text = mycnic;
            
            dob.Text = mydob;
            phone.Text = myphone;
            constituency.Text = myconstituency;
            
        }
    }
}
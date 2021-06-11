using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using PraksaMid.Users;

namespace PraksaFront
{

    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblErrorMessage.Visible = false;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=167.86.127.239;Initial Catalog=Praksa2021;User ID=SerengetiUser;Password=Serengeti12345678910");
            SqlCommand cmd = new SqlCommand("select * from users where Email=@Email", con);

            cmd.Parameters.AddWithValue("@Email", txtEmail.Text);

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Open();
            cmd.ExecuteNonQuery();
            if (dt.Rows.Count > 0)
            {
                Server.Transfer("About.aspx");
            }
            else
            {
                lblErrorMessage.Visible = true;
            }



            {
                
                

            }
        }
    }
}
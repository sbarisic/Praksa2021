using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace PraksaFront
{
    public partial class Registration : System.Web.UI.Page
    {
		

		

            

     

        protected void btnReg_Click (object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=167.86.127.239;Initial Catalog=Praksa2021;User ID=SerengetiUser;Password=Serengeti12345678910");
            SqlCommand cmd = new SqlCommand("insertUser", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@FirstName", SqlDbType.VarChar, 60).Value = txtIme.Text.ToString();
            cmd.Parameters.Add("@LastName", SqlDbType.VarChar, 60).Value = txtPrezime.Text.ToString();
            cmd.Parameters.Add("@Adress", SqlDbType.VarChar, 60).Value = txtAdresa.Text.ToString();
            cmd.Parameters.Add("@OIB", SqlDbType.VarChar, 15).Value = txtOib.Text.ToString();
            cmd.Parameters.Add("@PhoneNumber", SqlDbType.VarChar, 8).Value = txtIme.Text.ToString();
            cmd.Parameters.Add("@UniqueId", SqlDbType.VarChar, 20).Value = txtUID.Text.ToString();
            cmd.Parameters.Add("@Email", SqlDbType.VarChar, 60).Value = txtIme.Text.ToString();
            cmd.Parameters.Add("@IdRole", SqlDbType.Int).Value = txtIdRole.Text.ToString();

            con.Open();
            cmd.ExecuteNonQuery();
            



        }
    }

}
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PraksaMid
{
    public class PermitName
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void createPermitName(string connectionString, PermitName permitName)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("insertPermitName", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@Name", permitName.Name));

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<PermitName> getPermitNames(string connectionString)
        {
            List<PermitName> permitNames = new List<PermitName>();

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmd = new SqlCommand("getPermitNames", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr != null)
            {
                while (dr.Read())
                {
                    PermitName permitName = new PermitName()
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        Name = dr["Naziv dozvole"].ToString()
                    };

                    permitNames.Add(permitName);
                }
            }
            return permitNames;
        }
    }
}
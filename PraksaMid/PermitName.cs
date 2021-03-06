using PraksaMid.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace PraksaMid
{
    public static class PermitName
    {
        public static void CreatePermitName(PermitNameModel permitName)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Constants.connectionString))
                {
                    SqlCommand cmd = new SqlCommand("insertPermitName", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

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

        public static List<PermitNameModel> GetPermitNames()
        {
            List<PermitNameModel> permitNames = new List<PermitNameModel>();

            SqlConnection con = new SqlConnection(Constants.connectionString);
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
                    PermitNameModel permitNameModel = new PermitNameModel()
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        Name = dr["Naziv dozvole"].ToString()
                    };

                    permitNames.Add(permitNameModel);
                }
            }
            return permitNames;
        }

        public static void DeletePermitName(int permitNameId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Constants.connectionString))
                {
                    SqlCommand cmd = new SqlCommand("deletePermitName", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Parameters.Add(new SqlParameter("@IDpermit", permitNameId));

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
        public static void EditPermitName(PermitNameModel permitName)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Constants.connectionString))
                {
                    SqlCommand cmd = new SqlCommand("updatePermitName", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@IDpermit", permitName.Id));
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

        public static PermitNameModel GetPermitName(int idPermitName)
        {
            SqlConnection con = new SqlConnection(Constants.connectionString);
            con.Open();

            SqlCommand cmd = new SqlCommand("getPermitName", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.Add(new SqlParameter("@IDPermitName", idPermitName));

            SqlDataReader dr = cmd.ExecuteReader();
            PermitNameModel permitName = new PermitNameModel();

            if (dr != null)
            {
                while (dr.Read())
                {
                    permitName.Name = dr["Naziv dozvole"].ToString();
                }
            }
            return permitName;
        }
    }
}
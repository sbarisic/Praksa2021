using PraksaMid.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace PraksaMid
{
    public static class RoleName
    {
        public static List<RoleNameModel> GetRoleNames(string connectionString)
        {
            List<RoleNameModel> roles = new List<RoleNameModel>();

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmd = new SqlCommand("getRoleNames", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr != null)
            {
                while (dr.Read())
                {
                    RoleNameModel roleName = new RoleNameModel()
                    {
                        Id = Convert.ToInt32(dr["ID"]),
                        Name = dr["Naziv uloge"].ToString()
                    };

                    roles.Add(roleName);
                }
            }
            return roles;
        }

        public static void DeleteRole(string connectionString, int idRoleName)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("deleteRoleName", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Parameters.Add(new SqlParameter("@IDrole", idRoleName));

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
    }
}
using PraksaMid.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace PraksaMid
{
    public static class RoleNames
    {
        public static List<RoleNamesModel> GetRoleNames(string connectionString)
        {
            List<RoleNamesModel> roles = new List<RoleNamesModel>();

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
                    RoleNamesModel roleName = new RoleNamesModel()
                    {
                        Id = Convert.ToInt32(dr["ID"]),
                        Name = dr["Naziv uloge"].ToString()
                    };

                    roles.Add(roleName);
                }
            }
            return roles;
        }
    }
}
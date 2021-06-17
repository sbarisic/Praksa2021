using PraksaMid.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PraksaMid
{
    public static class Role
    {
        public static List<RoleModel> GetRoles(string connectionString, int idUser)
        {
            List<RoleModel> roles = new List<RoleModel>();

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmd = new SqlCommand("getRoles", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.Add(new SqlParameter("@IDuser", idUser));
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr != null)
            {
                while (dr.Read())
                {
                    RoleModel role = new RoleModel()
                    {
                        Id = Convert.ToInt32(dr["ID"]),
                        Name = dr["Uloga"].ToString()
                    };

                    roles.Add(role);
                }
            }
            return roles;
        }

            public static List<RoleModel> GetRoleNames(string connectionString)
            {
                List<RoleModel> roles = new List<RoleModel>();

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
                        RoleModel role = new RoleModel()
                        {
                            IdName = Convert.ToInt32(dr["ID"]),
                            Name = dr["Naziv uloge"].ToString()
                        };

                        roles.Add(role);
                    }
                }
                return roles;
            }
        }
}
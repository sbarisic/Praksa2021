using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PraksaMid
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int IdName { get; set; }

        public List<Role> GetRoles(string connectionString, int idUser)
        {
            List<Role> roles = new List<Role>();

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
                    Role role = new Role()
                    {
                        Id = Convert.ToInt32(dr["ID"]),
                        Name = dr["Uloga"].ToString()
                    };

                    roles.Add(role);
                }
            }
            return roles;
        }

            public List<Role> GetRoleNames(string connectionString)
            {
                List<Role> roles = new List<Role>();

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
                        Role role = new Role()
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
using PraksaMid.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

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
                        Id = Convert.ToInt32(dr["ID Uloge"]),
                        IdName = Convert.ToInt32(dr["ID Naziva Uloge"]),
                        Name = dr["Naziv Uloga"].ToString()
                    };

                    roles.Add(role);
                }
            }
            return roles;
        }

        public static void DeleteRole(string connectionString, int idRole)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("deleteRole", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Parameters.Add(new SqlParameter("@IDrole", idRole));

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
        public static void CreateRole(string connectionString, RoleModel role)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("insertRole", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Parameters.Add(new SqlParameter("@IDuser", role.IdUser));
                    cmd.Parameters.Add(new SqlParameter("@IDrole", role.IdName));

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
        public static void EditRole(string connectionString, RoleModel role)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("updateRole", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@ID", role.Id));
                    cmd.Parameters.Add(new SqlParameter("@IDuser", role.IdUser));
                    cmd.Parameters.Add(new SqlParameter("@IDrole", role.IdName));

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
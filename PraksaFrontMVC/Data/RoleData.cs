using Microsoft.Data.SqlClient;
using PraksaFrontMVC.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace PraksaFrontMVC.Data
{
    public class RoleData
    {
        public static Task<List<Role>> GetRoles(int idUser)
        {
            List<Role> roles = new();

            SqlConnection con = ConnectionString.ConStr();
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
                    Role role = new()
                    {
                        Id = Convert.ToInt32(dr["ID Uloge"]),
                        IdRole = Convert.ToInt32(dr["ID Naziva Uloge"]),
                        Name = dr["Naziv Uloga"].ToString()
                    };

                    roles.Add(role);
                }
            }
            return Task.FromResult(roles);
        }

        public static void DeleteRole(int idRole)
        {
            try
            {
                using (SqlConnection con = ConnectionString.ConStr())
                {
                    SqlCommand cmd = new("deleteRole", con)
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
        public static void CreateRole(Role role)
        {
            try
            {
                using (SqlConnection con = ConnectionString.ConStr())
                {
                    SqlCommand cmd = new("insertRole", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Parameters.Add(new SqlParameter("@IDuser", role.IdUser));
                    cmd.Parameters.Add(new SqlParameter("@IDrole", role.IdRole));

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
        public static void EditRole(Role role)
        {
            try
            {
                using (SqlConnection con = ConnectionString.ConStr())
                {
                    SqlCommand cmd = new("updateRole", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@ID", role.Id));
                    cmd.Parameters.Add(new SqlParameter("@IDuser", role.IdUser));
                    cmd.Parameters.Add(new SqlParameter("@IDrole", role.IdRole));

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

using PraksaMid.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace PraksaMid
{
    public static class RoleName
    {
        public static List<RoleNameModel> GetRoleNames()
        {
            List<RoleNameModel> roles = new List<RoleNameModel>();

            SqlConnection con = new SqlConnection(Constants.connectionString);
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

        public static void DeleteRoleName(int idRoleName)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Constants.connectionString))
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
        public static void CreateRoleName(RoleNameModel role)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Constants.connectionString))
                {
                    SqlCommand cmd = new SqlCommand("insertRoleName", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Parameters.Add(new SqlParameter("@RoleName", role.Name));

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
        public static void EditRoleName(RoleNameModel role)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Constants.connectionString))
                {
                    SqlCommand cmd = new SqlCommand("updateRoleName", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@IDrole", role.Id));
                    cmd.Parameters.Add(new SqlParameter("@Name", role.Name));

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
        public static RoleNameModel GetRoleName(int idRoleName)
        {
            SqlConnection con = new SqlConnection(Constants.connectionString);
            con.Open();

            SqlCommand cmd = new SqlCommand("getRoleName", con)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.Add(new SqlParameter("@IDrole", idRoleName));
            SqlDataReader dr = cmd.ExecuteReader();

            RoleNameModel roleName = new RoleNameModel();

            if (dr != null)
            {
                while (dr.Read())
                {
                    roleName.Id = Convert.ToInt32(dr["ID"]);
                    roleName.Name = dr["Naziv uloge"].ToString();
                }
            }
            return roleName;
        }
    }
}
using Microsoft.Data.SqlClient;
using PraksaFrontMVC.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace PraksaFrontMVC.Data
{
    public static class RoleNameData
    {
        public static Task<List<RoleName>> GetRoleNames()
        {
            List<RoleName> roles = new();

            SqlConnection con = ConnectionString.ConStr();
            con.Open();

            SqlCommand cmd = new("getRoleNames", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr != null)
            {
                while (dr.Read())
                {
                    RoleName roleName = new()
                    {
                        Id = Convert.ToInt32(dr["ID"]),
                        Name = dr["Naziv uloge"].ToString()
                    };

                    roles.Add(roleName);
                }
            }
            return Task.FromResult(roles);
        }

        public static Task<RoleName> GetRoleName(int idRoleName)
        {
            SqlConnection con = ConnectionString.ConStr();
            con.Open();

            SqlCommand cmd = new("getRoleName", con)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.Add(new SqlParameter("@IDrole", idRoleName));
            SqlDataReader dr = cmd.ExecuteReader();

            RoleName roleName = new();

            if (dr != null)
            {
                while (dr.Read())
                {
                    roleName.Id = Convert.ToInt32(dr["ID"]);
                    roleName.Name = dr["Naziv uloge"].ToString();
                }
            }
            return Task.FromResult(roleName);
        }
    }
}

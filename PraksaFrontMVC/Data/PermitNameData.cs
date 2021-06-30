using Microsoft.Data.SqlClient;
using PraksaFrontMVC.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace PraksaFrontMVC.Data
{
    public class PermitNameData
    {
        public static void CreatePermitName(PermitName permitName)
        {
            using (SqlConnection con = ConnectionString.ConStr())
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

        public static Task<List<PermitName>> GetPermitNames()
        {
            List<PermitName> permitNames = new List<PermitName>();

            SqlConnection con = ConnectionString.ConStr();
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
                    PermitName permitNameModel = new PermitName()
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        Name = dr["Naziv dozvole"].ToString()
                    };

                    permitNames.Add(permitNameModel);
                }
            }
            return Task.FromResult(permitNames);
        }

        public static void DeletePermitName(int permitNameId)
        {
            using (SqlConnection con = ConnectionString.ConStr())
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

        public static void EditPermitName(PermitName permitName)
        {

            using (SqlConnection con = ConnectionString.ConStr())
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

        public static Task<PermitName> GetPermitName(int idPermitName)
        {
            SqlConnection con = ConnectionString.ConStr();
            con.Open();

            SqlCommand cmd = new SqlCommand("getPermitName", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.Add(new SqlParameter("@IDPermitName", idPermitName));

            SqlDataReader dr = cmd.ExecuteReader();
            PermitName permitName = new PermitName();

            if (dr != null)
            {
                while (dr.Read())
                {
                    permitName.Name = dr["Naziv dozvole"].ToString();
                }
            }
            return Task.FromResult(permitName);
        }
    }
}

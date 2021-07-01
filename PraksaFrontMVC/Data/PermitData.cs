using Microsoft.Data.SqlClient;
using PraksaFrontMVC.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace PraksaFrontMVC.Data
{
    public class PermitData
    {
        public static void CreatePermit(Permit permit)
        {
            try
            {
                using (SqlConnection con =ConnectionString.ConStr())
                {
                    SqlCommand cmd = new("insertPermit", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    DateTime date = DateTime.Parse(permit.ExpiryDate);

                    cmd.Parameters.Add(new SqlParameter("@UserID", permit.IdUser));
                    cmd.Parameters.Add(new SqlParameter("@PermitID", permit.IdPermit));
                    cmd.Parameters.Add(new SqlParameter("@Date", date));
                    cmd.Parameters.Add(new SqlParameter("@PermitNumber", permit.PermitNumber));

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

        public static Task<List<Permit>> GetPermits(int idUser)
        {
            List<Permit> permits = new();

            SqlConnection con =ConnectionString.ConStr();


            SqlCommand cmd = new("getPermits", con)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.Add(new SqlParameter("@IDuser", idUser));

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr != null)
            {
                while (dr.Read())
                {
                    Permit permit = new Permit
                    {
                        FirstName = dr["Ime"].ToString(),
                        LastName = dr["Prezime"].ToString(),
                        PermitName = dr["Dozvola"].ToString(),
                        PermitNumber = dr["Broj dozvole"].ToString(),
                        IdPermit = Convert.ToInt32(dr["ID dozvole"]),
                        Id = Convert.ToInt32(dr["ID"]),
                        ExpiryDate = DateTime.Parse(dr["Datum isteka"].ToString()).ToString("d"),
                    };

                    permits.Add(permit);
                }
            }
            return Task.FromResult(permits);
        }

        public static void DeletePermit(int IdPermit)
        {
            try
            {
                using (SqlConnection con =ConnectionString.ConStr())
                {
                    SqlCommand cmd = new("deletePermit", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Parameters.Add(new SqlParameter("@IDpermit", IdPermit));

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

        public static void EditPermit(Permit permit)
        {
            try
            {
                using (SqlConnection con =ConnectionString.ConStr())
                {
                    SqlCommand cmd = new("updatePermit", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    DateTime date = DateTime.Parse(permit.ExpiryDate);
                    cmd.Parameters.Add(new SqlParameter("@ID", permit.Id));
                    cmd.Parameters.Add(new SqlParameter("@IDpermit", permit.IdPermit));
                    cmd.Parameters.Add(new SqlParameter("@IDuser", permit.IdUser));
                    cmd.Parameters.Add(new SqlParameter("@Number", permit.PermitNumber));
                    cmd.Parameters.Add(new SqlParameter("@ExpiryDate", date));

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

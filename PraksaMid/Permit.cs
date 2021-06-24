using PraksaMid.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace PraksaMid
{
    public static class Permit
    {
        public static void CreatePermit(PermitModel permit)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Constants.connectionString))
                {
                    SqlCommand cmd = new SqlCommand("insertPermit", con);
                    cmd.CommandType = CommandType.StoredProcedure;

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

        public static List<PermitModel> GetPermits(int idUser)
        {
            List<PermitModel> permits = new List<PermitModel>();

            SqlConnection con = new SqlConnection(Constants.connectionString);


            SqlCommand cmd = new SqlCommand("getPermits", con)
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
                    PermitModel permit = new PermitModel
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
            return permits;
        }

        public static void DeletePermit(int IdPermit)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Constants.connectionString))
                {
                    SqlCommand cmd = new SqlCommand("deletePermit", con);
                    cmd.CommandType = CommandType.StoredProcedure;

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

        public static void EditPermit(PermitModel permit)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Constants.connectionString))
                {
                    SqlCommand cmd = new SqlCommand("updatePermit", con);
                    cmd.CommandType = CommandType.StoredProcedure;

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
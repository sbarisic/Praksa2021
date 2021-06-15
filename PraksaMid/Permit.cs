using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PraksaMid.Permit
{
    public class Permit
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public int IdPermit { get; set; }
        public string ExpiryDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PermitName { get; set; }
        public string PermitNumber { get; set; }


        public void CreatePermit(string connectionString, Permit permit)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("insertPermitName", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    DateTime date = DateTime.Parse(ExpiryDate); 

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

        public List<Permit> GetPermits(string connectionString, int idUser)
        {
            List<Permit> permits = new List<Permit>();

            SqlConnection con = new SqlConnection(connectionString);
            

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
                    Permit permit = new Permit
                    {
                        FirstName = dr["Ime"].ToString(),
                        LastName = dr["Prezime"].ToString(),
                        PermitName = dr["Dozvola"].ToString(),
                        PermitNumber = dr["Broj dozvole"].ToString(),
                        ExpiryDate = DateTime.Parse(dr["Datum isteka"].ToString()).ToString("d")
    
                    };

                    permits.Add(permit);
                }
            }
            return permits;
        }

        public void DeletePermit(string connectionString, int IdPermit)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
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

        public void EditPermit(string connectionString, Permit permit)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("updatePermit", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    DateTime date = DateTime.Parse(ExpiryDate);
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
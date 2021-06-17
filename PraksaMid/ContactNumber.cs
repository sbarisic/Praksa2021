using PraksaMid.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace PraksaMid
{
    public static class ContactNumber
    {
        public static List<ContactNumberModel> GetContactNumbers(string connectionString, int idUser)
        {
            List<ContactNumberModel> contactNumbers = new List<ContactNumberModel>();

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmd = new SqlCommand("getContactNumbers", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.Add(new SqlParameter("@IDuser", idUser));

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr != null)
            {
                while (dr.Read())
                {
                    ContactNumberModel contactNumber = new ContactNumberModel()
                    {
                        Id = Convert.ToInt32(dr["IDNumber"]),
                        Number = dr["Kontakt broj"].ToString()
                    };

                    contactNumbers.Add(contactNumber);
                }
            }
            return contactNumbers;
        }

        public static void CreateContactNumber(string connectionString, ContactNumberModel contactNumber)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("insertContactNumber", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Parameters.Add(new SqlParameter("@IdUser", contactNumber.IdUser));
                    cmd.Parameters.Add(new SqlParameter("@Number", contactNumber.Number));

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

        public static void EditContactNumber(string connectionString, ContactNumberModel contactNumber)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("updateContactNumber", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@ID", contactNumber.Id));
                    cmd.Parameters.Add(new SqlParameter("@Number", contactNumber.Number));

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
        public static void DeleteContactNumber(string connectionString, int idNumber)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("deleteContactNumber", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Parameters.Add(new SqlParameter("@IDNumber", idNumber));

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
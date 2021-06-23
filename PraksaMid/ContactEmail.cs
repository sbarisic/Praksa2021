using PraksaMid.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace PraksaMid
{
    public static class ContactEmail
    {
        public static List<ContactEmailModel> GetContactEmails(string connectionString, int idUser)
        {
            List<ContactEmailModel> contactEmails = new List<ContactEmailModel>();

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmd = new SqlCommand("getEmails", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.Add(new SqlParameter("@IDuser", idUser));
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr != null)
            {
                while (dr.Read())
                {
                    ContactEmailModel contactEmail = new ContactEmailModel()
                    {
                        Id = Convert.ToInt32(dr["IDEmail"]),
                        Email = dr["Epošta"].ToString()
                    };

                    contactEmails.Add(contactEmail);
                }
            }
            return contactEmails;
        }

        public static void CreateEmail(string connectionString, ContactEmailModel email)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("insertEmail", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Parameters.Add(new SqlParameter("@IdUser", email.IdUser));
                    cmd.Parameters.Add(new SqlParameter("@Email", email.Email));

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

        public static void EditEmail(string connectionString, ContactEmailModel email)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("updateEmail", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@ID", email.Id));
                    cmd.Parameters.Add(new SqlParameter("@Email", email.Email));

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

        public static int DeleteEmail(string connectionString, int idEmail)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("deleteEmail", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Parameters.Add(new SqlParameter("@IDEmail", idEmail));
                    cmd.Parameters.Add("@ReturnValue", SqlDbType.Int).Direction = ParameterDirection.Output;

                    con.Open();
                    cmd.ExecuteNonQuery();
                    int returnValue = Convert.ToInt32(cmd.Parameters["@ReturnValue"].Value);
                    con.Close();
                    return returnValue;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static ContactEmailModel GetEmail(string connectionString, int idUser, int idEmail)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmd = new SqlCommand("getEmail", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.Add(new SqlParameter("@IDUser", idUser));
            cmd.Parameters.Add(new SqlParameter("@IDEmail", idEmail));

            SqlDataReader dr = cmd.ExecuteReader();
            ContactEmailModel email = new ContactEmailModel();
            if (dr != null)
            {
                while (dr.Read())
                {
                    email.Email = dr["Epošta"].ToString();
                    email.Id = Convert.ToInt32(dr["IDEmail"]);
                }
            }
            return email;
        }
    }
}

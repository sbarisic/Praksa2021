using Microsoft.Data.SqlClient;
using PraksaFrontMVC.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace PraksaFrontMVC.Data
{
    public class ContactEmailData
    {
        public static Task<List<ContactEmail>> GetContactEmails(int idUser)
        {
            List<ContactEmail> contactEmails = new();

            SqlConnection con = ConnectionString.ConStr();
            con.Open();

            SqlCommand cmd = new("getEmails", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.Add(new SqlParameter("@IDuser", idUser));
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr != null)
            {
                while (dr.Read())
                {
                    ContactEmail contactEmail = new ContactEmail()
                    {
                        Id = Convert.ToInt32(dr["IDEmail"]),
                        Email = dr["Epošta"].ToString()
                    };

                    contactEmails.Add(contactEmail);
                }
            }
            return Task.FromResult(contactEmails);
        }

        public static void CreateEmail(ContactEmail email)
        {
            try
            {
                using (SqlConnection con = ConnectionString.ConStr())
                {
                    SqlCommand cmd = new("insertEmail", con)
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

        public static void EditEmail(ContactEmail email)
        {
            try
            {
                using (SqlConnection con = ConnectionString.ConStr())
                {
                    SqlCommand cmd = new("updateEmail", con)
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

        public static Task<int> DeleteEmail(int idEmail)
        {
            try
            {
                using (SqlConnection con = ConnectionString.ConStr())
                {
                    SqlCommand cmd = new("deleteEmail", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Parameters.Add(new SqlParameter("@IDEmail", idEmail));
                    cmd.Parameters.Add("@ReturnValue", SqlDbType.Int).Direction = ParameterDirection.Output;

                    con.Open();
                    cmd.ExecuteNonQuery();
                    int returnValue = Convert.ToInt32(cmd.Parameters["@ReturnValue"].Value);
                    con.Close();
                    return Task.FromResult(returnValue);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static Task<ContactEmail> GetEmail(int idUser, int idEmail)
        {
            SqlConnection con = ConnectionString.ConStr();
            con.Open();

            SqlCommand cmd = new("getEmail", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.Add(new SqlParameter("@IDUser", idUser));
            cmd.Parameters.Add(new SqlParameter("@IDEmail", idEmail));

            SqlDataReader dr = cmd.ExecuteReader();
            ContactEmail email = new();
            if (dr != null)
            {
                while (dr.Read())
                {
                    email.Email = dr["Epošta"].ToString();
                    email.Id = Convert.ToInt32(dr["IDEmail"]);
                }
            }
            return Task.FromResult(email);
        }
    }
}

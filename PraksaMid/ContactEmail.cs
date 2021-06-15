using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PraksaMid
{
    public class ContactEmail
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public int IdUser { get; set; }

        public List<ContactEmail> GetContactEmails(string connectionString, int idUser)
        {
            List<ContactEmail> contactEmails = new List<ContactEmail>();

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
                    ContactEmail contactEmail = new ContactEmail()
                    {
                        Id = Convert.ToInt32(dr["IDEmail"]),
                        Email = dr["Epošta"].ToString()
                    };

                    contactEmails.Add(contactEmail);
                }
            }
            return contactEmails;
        }

        public void CreateEmail(string connectionString, ContactEmail email)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("insertEmail", con);
                    cmd.CommandType = CommandType.StoredProcedure;

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

        public void EditEmail(string connectionString, ContactEmail email)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("updateEmail", con);

                    cmd.CommandType = CommandType.StoredProcedure;
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

        public void DeleteEmail(string connectionString, int idEmail)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("deleteEmail", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@IDEmail", idEmail));

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

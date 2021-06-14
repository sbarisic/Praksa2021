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
    }
}

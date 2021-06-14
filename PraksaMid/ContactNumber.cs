using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PraksaMid
{
    public class ContactNumber
    {
        public int Id { get; set; }
        public string Number { get; set; }

       public List<ContactNumber> GetContactNumbers(string connectionString, int idUser)
        {
            List<ContactNumber> contactNumbers= new List<ContactNumber>();

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
                    ContactNumber contactNumber= new ContactNumber()
                    {
                        Id = Convert.ToInt32(dr["IDNumber"]),
                        Number = dr["Kontakt broj"].ToString()
                    };

                    contactNumbers.Add(contactNumber);
                }
            }
            return contactNumbers;
        }
    }
}
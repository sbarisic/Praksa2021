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
        public int IdUser { get; set; }

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

        public void CreateContactNumber(string connectionString, ContactNumber contactNumber)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("insertContactNumber", con);
                    cmd.CommandType = CommandType.StoredProcedure;

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

        public void EditContactNumber(string connectionString, ContactNumber contactNumber)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("updateContactNumber", con);

                    cmd.CommandType = CommandType.StoredProcedure;
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
        public void DeleteContactNumber(string connectionString, int idNumber)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("deleteContactNumber", con);
                    cmd.CommandType = CommandType.StoredProcedure;

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
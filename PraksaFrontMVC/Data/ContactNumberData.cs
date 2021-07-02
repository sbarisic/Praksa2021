using Microsoft.Data.SqlClient;
using PraksaFrontMVC.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace PraksaFrontMVC.Data
{
    public class ContactNumberData
    {
        public static Task<List<ContactNumber>> GetContactNumbers(int idUser)
        {
            List<ContactNumber> contactNumbers = new();

            SqlConnection con = ConnectionString.ConStr();
            con.Open();

            SqlCommand cmd = new("getContactNumbers", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.Add(new SqlParameter("@IDuser", idUser));

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr != null)
            {
                while (dr.Read())
                {
                    ContactNumber contactNumber = new()
                    {
                        Id = Convert.ToInt32(dr["IDNumber"]),
                        Number = dr["Kontakt broj"].ToString(),
                        IdUser = Convert.ToInt32(dr["IDUser"])
                    };

                    contactNumbers.Add(contactNumber);
                }
            }
            return Task.FromResult(contactNumbers);
        }

        public static void CreateContactNumber(ContactNumber contactNumber)
        {
            try
            {
                using (SqlConnection con = ConnectionString.ConStr())
                {
                    SqlCommand cmd = new("insertContactNumber", con)
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

        public static void EditContactNumber(ContactNumber contactNumber)
        {
            try
            {
                using (SqlConnection con = ConnectionString.ConStr())
                {
                    SqlCommand cmd = new("updateContactNumber", con)
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
        public static void DeleteContactNumber(int idNumber)
        {
            try
            {
                using (SqlConnection con = ConnectionString.ConStr())
                {
                    SqlCommand cmd = new("deleteContactNumber", con)
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

        public static Task<ContactNumber> GetContactNumber(int idUser, int idNumber)
        {
            SqlConnection con = ConnectionString.ConStr();
            con.Open();

            SqlCommand cmd = new("getContactNumber", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.Add(new SqlParameter("@IDuser", idUser));
            cmd.Parameters.Add(new SqlParameter("@IDNumber", idNumber));

            SqlDataReader dr = cmd.ExecuteReader();
            ContactNumber number = new();
            if (dr != null)
            {
                while (dr.Read())
                {
                    number.Number = dr["Kontakt broj"].ToString();
                    number.Id = Convert.ToInt32(dr["IDNumber"]);
                    number.IdUser = Convert.ToInt32(dr["IDUser"]);
                }
            }
            return Task.FromResult(number);
        }
    }
}

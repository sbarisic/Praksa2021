using PraksaMid.Users;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PraksaMid
{
    public static class Authentication
    {
        public static int LogIn(string connectionString, string email, string password)
        {
            SqlConnection con = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand("login", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.Add(new SqlParameter("@Email", email));

            var salt = GetPasswordSalt(connectionString, email);

           if (salt != "") {
                cmd.Parameters.Add(new SqlParameter("@PasswordHash", PasswordManager.HashPassword(password, salt)));

                cmd.Parameters.Add("@ReturnValue", SqlDbType.Int).Direction = ParameterDirection.Output;

                con.Open();
                cmd.ExecuteNonQuery();
                int returnValue = Convert.ToInt32(cmd.Parameters["@ReturnValue"].Value);
                con.Close();

                return returnValue;
            }

            return 0;
        }

        public static string GetPasswordSalt(string connectionString, string email)
        {
            SqlConnection con = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand("getPasswordSalt", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.Add(new SqlParameter("@Email", email));

            cmd.Parameters.Add("@PasswordSalt", SqlDbType.VarChar, 255).Direction = ParameterDirection.Output;

            con.Open();
            cmd.ExecuteNonQuery();
            string salt = cmd.Parameters["@PasswordSalt"].Value.ToString();
            con.Close();

            return salt;
        }
    }
}


           



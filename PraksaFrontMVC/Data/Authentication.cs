using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace PraksaFrontMVC.Data
{
    public class Authentication
    {
        public static int LogIn(string email, string password)
        {
            SqlConnection con = ConnectionString.ConStr();

            SqlCommand cmd = new("login", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.Add(new SqlParameter("@Email", email));

            var salt = GetPasswordSalt(email);

            if (salt != "")
            {
                cmd.Parameters.Add(new SqlParameter("@PasswordHash", PasswordManager.HashPassword(password, salt)));

                cmd.Parameters.Add("@ReturnValue", SqlDbType.Int).Direction = ParameterDirection.Output;

                con.Open();
                cmd.ExecuteNonQuery();
                var returnValue = Convert.ToInt32(cmd.Parameters["@ReturnValue"].Value);
                con.Close();

                return returnValue;
            }

            return 0;
        }

        public static string GetPasswordSalt(string email)
        {
            SqlConnection con = ConnectionString.ConStr();

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

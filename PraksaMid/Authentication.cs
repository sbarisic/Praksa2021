using System;
using System.Data;
using System.Data.SqlClient;

namespace PraksaMid
{
    public static class Authentication
    {
        public static int LogIn(string email, string password)
        {
            SqlConnection con = new SqlConnection(Constants.connectionString);

            SqlCommand cmd = new SqlCommand("login", con)
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
            SqlConnection con = new SqlConnection(Constants.connectionString);

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






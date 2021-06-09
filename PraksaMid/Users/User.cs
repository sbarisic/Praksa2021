using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace PraksaMid.Users
{
    public class User
    {
        public int Id { get; set; }
        public string UniqueId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int IdRole { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Oib { get; set; }
        public string Email { get; set; }
        public string PasswordSalt { get; set; }
        public string PasswordHash { get; set; }

        

        public List<User> GetUsers(string connectionString)
        {
            List<User> users = new List<User>();

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmd = new SqlCommand("getUsers", con)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };
            SqlDataReader dr = cmd.ExecuteReader();

            if(dr != null)
            {
                while (dr.Read())
                {
                    User user = new User
                    {
                        Id = Convert.ToInt32(dr["ID"]),
                        UniqueId = dr["Jedinstveni broj člana"].ToString(),
                        FirstName = dr["Ime"].ToString(),
                        LastName = dr["Prezime"].ToString(),
                        Address = dr["Adresa"].ToString(),
                        PhoneNumber = dr["Broj mobitela"].ToString(),
                        Email = dr["Epošta"].ToString()
                    };


                    users.Add(user);

                }
            }
            return users;
        }

        public User GetUser(string connectionString, int id)
        {
            List<User> users = new List<User>();

            SqlConnection con = new SqlConnection(connectionString);
            
            SqlCommand cmd = new SqlCommand("getUser", con)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };
            SqlParameter parameter = new SqlParameter
            {
                ParameterName = "@ID",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = id
            };
            cmd.Parameters.Add(parameter);

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            User user = new User();

            if (dr != null)
            {
                while (dr.Read())
                {
                    user.UniqueId = dr["Jedinstveni broj člana"].ToString();
                    user.FirstName = dr["Ime"].ToString();
                    user.LastName = dr["Prezime"].ToString();
                    user.Address = dr["Adresa"].ToString();
                    user.PhoneNumber = dr["Broj mobitela"].ToString();
                    user.Email = dr["Epošta"].ToString();
                    user.Oib = dr["OIB"].ToString();
                }
            }
            return user;
        }

        public void EditUser(string connectionString, User user)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("updateUser", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@ID", user.Id));
                    cmd.Parameters.Add(new SqlParameter("@UniqueId", user.UniqueId));
                    cmd.Parameters.Add(new SqlParameter("@FirstName", user.FirstName));
                    cmd.Parameters.Add(new SqlParameter("@LastName", user.LastName ));
                    cmd.Parameters.Add(new SqlParameter("@Adress", user.Address ));
                    cmd.Parameters.Add(new SqlParameter("@OIB", user.Oib ));
                    cmd.Parameters.Add(new SqlParameter("@IdRole", user.IdRole ));
                    cmd.Parameters.Add(new SqlParameter("@PhoneNumber", user.PhoneNumber ));
                    cmd.Parameters.Add(new SqlParameter("@Email",  user.Email ));
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

        public void CreateUser(string connectionString, User user)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("insertUser", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@UniqueId", user.UniqueId));
                    cmd.Parameters.Add(new SqlParameter("@FirstName", user.FirstName));
                    cmd.Parameters.Add(new SqlParameter("@LastName", user.LastName));
                    cmd.Parameters.Add(new SqlParameter("@Adress", user.Address));
                    cmd.Parameters.Add(new SqlParameter("@OIB", user.Oib));
                    cmd.Parameters.Add(new SqlParameter("@IdRole", user.IdRole));
                    cmd.Parameters.Add(new SqlParameter("@PhoneNumber", user.PhoneNumber));
                    cmd.Parameters.Add(new SqlParameter("@Email", user.Email));

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
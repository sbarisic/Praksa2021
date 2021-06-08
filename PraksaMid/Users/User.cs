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
    }
}
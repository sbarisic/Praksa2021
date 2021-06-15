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
        public string RoleName { get; set; }
        public string Address { get; set; }
        public string Oib { get; set; }
        public string PasswordSalt { get; set; }
        public string PasswordHash { get; set; }
        public bool Accepted { get; set; }



        public List<User> GetUsers(string connectionString)
        {
            List<User> users = new List<User>();

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmd = new SqlCommand("getAcceptedUsers", con)
            {
                CommandType = CommandType.StoredProcedure
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
                        Oib = dr["OIB"].ToString(),
                        FirstName = dr["Ime"].ToString(),
                        LastName = dr["Prezime"].ToString(),
                        Address = dr["Adresa"].ToString()                        
                };

                    users.Add(user);

                }
            }
            return users;
        }

        public User GetUser(string connectionString, int id)
        {
            SqlConnection con = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand("getUser", con)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };

            cmd.Parameters.Add(new SqlParameter("@ID", id));

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            User user = new User();

            if (dr != null)
            {
                while (dr.Read())
                {
                    user.Id = Convert.ToInt32(dr["ID"]);
                    user.UniqueId = dr["Jedinstveni broj člana"].ToString();
                    user.FirstName = dr["Ime"].ToString();
                    user.LastName = dr["Prezime"].ToString();
                    user.Oib = dr["OIB"].ToString();
                    user.Address = dr["Adresa"].ToString();
                    user.Oib = dr["OIB"].ToString();
                    user.RoleName = dr["Uloga"].ToString();
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
                    cmd.Parameters.Add(new SqlParameter("@IDUser", user.Id));
                    cmd.Parameters.Add(new SqlParameter("@UniqueId", user.UniqueId));
                    cmd.Parameters.Add(new SqlParameter("@FirstName", user.FirstName));
                    cmd.Parameters.Add(new SqlParameter("@LastName", user.LastName ));
                    cmd.Parameters.Add(new SqlParameter("@Adress", user.Address ));
                    cmd.Parameters.Add(new SqlParameter("@OIB", user.Oib ));
                    cmd.Parameters.Add(new SqlParameter("@IdRole", user.IdRole ));

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    var i = user.Accepted;
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

        public void DeleteUser(string connectionString, int userId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("deleteUser", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@IDuser", userId));

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

        public List<User> GetRegistartionsRequestUser(string connectionString)
        {
            List<User> users = new List<User>();

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmd = new SqlCommand("getUnacceptedUsers", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr != null)
            {
                while (dr.Read())
                {
                    User user = new User
                    {
                        Id = Convert.ToInt32(dr["ID"]),
                        Oib = dr["OIB"].ToString(),
                        FirstName = dr["Ime"].ToString(),
                        LastName = dr["Prezime"].ToString(),
                        Address = dr["Adresa"].ToString()
                    };

                    users.Add(user);

                }
            }
            return users;
        }

        public void VerificateUser(string connectionString, int userId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("verificateUser", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@IDUser", userId));
                    cmd.Parameters.Add(new SqlParameter("@Accepted", true));

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
        public void RejectUser(string connectionString, int userId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("rejectUser", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@IDUser", userId));
                    cmd.Parameters.Add(new SqlParameter("@Accepted", false));

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
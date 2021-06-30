using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using PraksaFrontMVC.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;


namespace PraksaFrontMVC.Data
{
    public static class PeopleData
    {
        public static Task<List<Person>> GetUsers()
        {
            List<Person> users = new();

            SqlConnection con = ConnectionString.ConStr();
            con.Open();

            SqlCommand cmd = new SqlCommand("getAcceptedUsers", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr != null)
            {
                while (dr.Read())
                {
                    Person user = new Person
                    {
                        Id = Convert.ToInt32(dr["ID"]),
                        UniqueId = dr["Jedinstveni broj člana"].ToString(),
                        Oib = dr["OIB"].ToString(),
                        FirstName = dr["Ime"].ToString(),
                        LastName = dr["Prezime"].ToString(),
                        Address = dr["Adresa"].ToString(),
                        Email = dr["Epošta"].ToString(),
                        Number = dr["Broj mobitela"].ToString()
                    };
                    users.Add(user);
                }
            }
            return Task.FromResult(users);
        }

        public static Task<Person> GetUser(int idUser)
        {
            SqlConnection con = ConnectionString.ConStr();

            SqlCommand cmd = new SqlCommand("getUser", con)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };

            cmd.Parameters.Add(new SqlParameter("@IDuser", idUser));

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            Person user = new Person();

            if (dr != null)
            {
                while (dr.Read())
                {
                    user.Id = Convert.ToInt32(dr["ID"]);
                    user.UniqueId = dr["Jedinstveni broj člana"].ToString();
                    user.FirstName = dr["Ime"].ToString();
                    user.LastName = dr["Prezime"].ToString();
                    user.Address = dr["Adresa"].ToString();
                    user.Oib = dr["OIB"].ToString();
                }
            }
            return Task.FromResult(user);
        }

        public static void EditUser(Person user)
        {
            try
            {
                using (SqlConnection con = ConnectionString.ConStr())
                {
                    SqlCommand cmd = new SqlCommand("updateUser", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@IDUser", user.Id));
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

        public static void CreateUser(Person user)
        {
            PasswordManager.GenerateSaltHashPair(user.Password, out string hash, out string salt);
            try
            {

                using (SqlConnection con = ConnectionString.ConStr())
                {
                    SqlCommand cmd = new SqlCommand("insertUser", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@UniqueId", user.UniqueId));
                    cmd.Parameters.Add(new SqlParameter("@FirstName", user.FirstName));
                    cmd.Parameters.Add(new SqlParameter("@LastName", user.LastName));
                    cmd.Parameters.Add(new SqlParameter("@Adress", user.Address));
                    cmd.Parameters.Add(new SqlParameter("@OIB", user.Oib));
                    cmd.Parameters.Add(new SqlParameter("@Email", user.Email));
                    cmd.Parameters.Add(new SqlParameter("@Number", user.Number));
                    cmd.Parameters.Add(new SqlParameter("@PasswordSalt", salt));
                    cmd.Parameters.Add(new SqlParameter("@PasswordHash", hash));

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

        public static void DeleteUser(int userId)
        {
            try
            {
                using (SqlConnection con = ConnectionString.ConStr())
                {
                    SqlCommand cmd = new SqlCommand("deleteUser", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

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

        public static Task<List<Person>> GetRegistartionsRequestUser()
        {
            List<Person> users = new();

            SqlConnection con = ConnectionString.ConStr();
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
                    Person user = new Person
                    {
                        Id = Convert.ToInt32(dr["ID"]),
                        Oib = dr["OIB"].ToString(),
                        FirstName = dr["Ime"].ToString(),
                        LastName = dr["Prezime"].ToString(),
                        Address = dr["Adresa"].ToString(),
                        Email = dr["Epošta"].ToString(),
                        Number = dr["Broj mobitela"].ToString()
                    };
                    users.Add(user);
                }
            }
            return Task.FromResult(users);
        }

        public static void VerificateUser(int userId)
        {
            try
            {
                using (SqlConnection con = ConnectionString.ConStr())
                {
                    SqlCommand cmd = new SqlCommand("verificateUser", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
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
        public static void RejectUser(int userId)
        {
            try
            {
                using (SqlConnection con = ConnectionString.ConStr())
                {
                    SqlCommand cmd = new SqlCommand("rejectUser", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
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
        public static Task<List<Person>> GetDismissedUsers()
        {
            List<Person> users = new();

            SqlConnection con = ConnectionString.ConStr();
            con.Open();

            SqlCommand cmd = new SqlCommand("getDismissedUsers", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr != null)
            {
                while (dr.Read())
                {
                    Person user = new Person
                    {
                        Id = Convert.ToInt32(dr["ID"]),
                        Oib = dr["OIB"].ToString(),
                        FirstName = dr["Ime"].ToString(),
                        LastName = dr["Prezime"].ToString(),
                        Address = dr["Adresa"].ToString(),
                        Email = dr["Epošta"].ToString(),
                        Number = dr["Broj mobitela"].ToString(),
                        Dismissed = DateTime.Parse(dr["Datum zatvaranja"].ToString())
                    };
                    users.Add(user);
                }
            }
            return Task.FromResult(users);
        }

        public static void ActivateUser(int userId)
        {
            try
            {
                using (SqlConnection con = ConnectionString.ConStr())
                {
                    SqlCommand cmd = new SqlCommand("activateUser", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

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

        public static int GetUserId(string userEmail)
        {
            SqlConnection con = ConnectionString.ConStr();

            SqlCommand cmd = new SqlCommand("getIdUser", con)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };

            cmd.Parameters.Add(new SqlParameter("@Email", userEmail));
            cmd.Parameters.Add("@IdUser", SqlDbType.Int).Direction = ParameterDirection.Output;


            con.Open();
            cmd.ExecuteNonQuery();
            int id = Convert.ToInt32(cmd.Parameters["@IdUser"].Value);
            con.Close();

            return id;
        }
    }
}

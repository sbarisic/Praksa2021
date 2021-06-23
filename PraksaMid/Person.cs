using PraksaMid.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace PraksaMid
{
    public static class Person
    {
        public static List<PersonModel> GetUsers(string connectionString)
        {
            List<PersonModel> users = new List<PersonModel>();

            SqlConnection con = new SqlConnection(connectionString);
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
                    PersonModel user = new PersonModel
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
            return users;
        }

        public static PersonModel GetUser(string connectionString, int idUser)
        {
            SqlConnection con = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand("getUser", con)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };

            cmd.Parameters.Add(new SqlParameter("@IDuser", idUser));

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            PersonModel user = new PersonModel();

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
            return user;
        }

        public static void EditUser(string connectionString, PersonModel user)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
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

        public static void CreateUser(string connectionString, PersonModel user)
        {
            PasswordManager.GenerateSaltHashPair(user.Password, out string hash, out string salt);
            try
            {

                using (SqlConnection con = new SqlConnection(connectionString))
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

        public static void DeleteUser(string connectionString, int userId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
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

        public static List<PersonModel> GetRegistartionsRequestUser(string connectionString)
        {
            List<PersonModel> users = new List<PersonModel>();

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
                    PersonModel user = new PersonModel
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
            return users;
        }

        public static void VerificateUser(string connectionString, int userId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
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
        public static void RejectUser(string connectionString, int userId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
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
        public static List<PersonModel> GetDismissedUsers(string connectionString)
        {
            List<PersonModel> users = new List<PersonModel>();

            SqlConnection con = new SqlConnection(connectionString);
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
                    PersonModel user = new PersonModel
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
            return users;
        }
        public static void ActivateUser(string connectionString, int userId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
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

        public static int GetUserId(string connectionString, string userEmail)
        {
            SqlConnection con = new SqlConnection(connectionString);

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
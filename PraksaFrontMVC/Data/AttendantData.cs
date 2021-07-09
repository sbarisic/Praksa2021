using Microsoft.Data.SqlClient;
using PraksaFrontMVC.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace PraksaFrontMVC.Data
{
    public class AttendantData
    {
        public static Task<List<Attendant>> GetAttendants(int idJob)
        {
            List<Attendant> attendants = new List<Attendant>();

            SqlConnection con = ConnectionString.ConStr();

            SqlCommand cmd = new("getAttendants", con)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.Add(new SqlParameter("@IDjob", idJob));

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr != null)
            {
                while (dr.Read())
                {
                    Attendant attendant = new()
                    {
                        UserFirstName = dr["Ime"].ToString(),
                        IdUser = Convert.ToInt32(dr["ID Korisnika"]),
                        UserLastName = dr["Prezime"].ToString(),
                        Job = dr["Naziv posla"].ToString(),
                        Interes = dr["Interes"].ToString(),
                        Attendance = dr["Dolaznost"].ToString(),
                        SelectionTime = dr["Vrijeme odabira"].ToString(),
                        IdAttendance = Convert.ToInt32(dr["ID Dolaznosti"]),
                        IdJob = Convert.ToInt32(dr["ID Posla"])
                    };
                    attendants.Add(attendant);
                }
            }
            return Task.FromResult(attendants);
        }

        public static void CreateAttendant(Attendant attendant)
        {
            try
            {
                using (SqlConnection con = ConnectionString.ConStr())
                {
                    SqlCommand cmd = new("insertAttendant", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Parameters.Add(new SqlParameter("@IDjob", attendant.IdJob));
                    cmd.Parameters.Add(new SqlParameter("@IDuser", attendant.IdUser));
                    cmd.Parameters.Add(new SqlParameter("@IDinterest", attendant.IdInteres));

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
        public static void EditAttendant(Attendant attendant)
        {
            try
            {
                using (SqlConnection con = ConnectionString.ConStr())
                {
                    SqlCommand cmd = new("updateAttendant", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Parameters.Add(new SqlParameter("@ID", attendant.Id));
                    cmd.Parameters.Add(new SqlParameter("@IDuser", attendant.IdUser));
                    cmd.Parameters.Add(new SqlParameter("@IDjobs", attendant.IdJob));
                    cmd.Parameters.Add(new SqlParameter("@IDinterest", attendant.IdInteres));
                    cmd.Parameters.Add(new SqlParameter("@IDattendance", attendant.IdAttendance));

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
        public static Attendant GetAttendant(int idJob, int idUser)
        {
            SqlConnection con = ConnectionString.ConStr();


            SqlCommand cmd = new("getAttendant", con)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.Add(new SqlParameter("@IDjob", idJob));
            cmd.Parameters.Add(new SqlParameter("@IDuser", idUser));

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            Attendant attendant = new();
            if (dr != null)
            {
                while (dr.Read())
                {
                    attendant.Id = Convert.ToInt32(dr["ID"].ToString());
                    attendant.IdAttendance = Convert.ToInt32(dr["ID Dolaznosti"].ToString());
                    attendant.IdInteres = Convert.ToInt32(dr["ID Interesa"].ToString());
                    attendant.IdJob = Convert.ToInt32(dr["ID Posla"].ToString());
                    attendant.IdUser = Convert.ToInt32(dr["ID Korisnika"].ToString());
                }
            }
            return attendant;
        }
        public static Attendant GetAttendantId(int idJob, int idUser)
        {
            SqlConnection con = ConnectionString.ConStr();


            SqlCommand cmd = new SqlCommand("getAttendantID", con)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.Add(new SqlParameter("@IDjob", idJob));
            cmd.Parameters.Add(new SqlParameter("@IDuser", idUser));

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            Attendant attendant = new();
            if (dr != null)
            {
                while (dr.Read())
                {
                    attendant.Id = Convert.ToInt32(dr["ID"].ToString());
                }
            }
            return attendant;
        }
    }
}

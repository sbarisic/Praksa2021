using PraksaMid.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PraksaMid
{
    public static class Attendant
    {
        public static List<AttendantModel> GetAttendants(string connectionString, int idJob)
        {
            List<AttendantModel> attendants = new List<AttendantModel>();

            SqlConnection con = new SqlConnection(connectionString);


            SqlCommand cmd = new SqlCommand("getAttendants", con)
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
                    AttendantModel attendant = new AttendantModel
                    {
                        UserFirstName = dr["Ime"].ToString(),
                        UserLastName = dr["Prezime"].ToString(),
                        Job = dr["Naziv posla"].ToString(),
                        Interes = dr["Interes"].ToString(),
                        Attendance = dr["Dolaznost"].ToString(),
                        SelectionTime = dr["Vrijeme odabira"].ToString()
                    };
                    attendants.Add(attendant);
                }
            }
            return attendants;
        }

        public static void CreateAttendant(string connectionString, AttendantModel attendant)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("insertAttendant", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@IDjob", attendant.IdJob));
                    cmd.Parameters.Add(new SqlParameter("@IDuser", attendant.IdUser));
                    cmd.Parameters.Add(new SqlParameter("@IDinerest", attendant.IdInteres));
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
        public static void EditAttendant(string connectionString, AttendantModel attendant)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("updateAttendant", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@ID", attendant.Id));
                    cmd.Parameters.Add(new SqlParameter("@IDuser", attendant.IdUser));
                    cmd.Parameters.Add(new SqlParameter("@IDjob", attendant.IdJob));
                    cmd.Parameters.Add(new SqlParameter("@IDinerest", attendant.IdInteres));
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
    }
}
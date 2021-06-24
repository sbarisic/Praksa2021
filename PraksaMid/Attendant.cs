using PraksaMid.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace PraksaMid
{
    public static class Attendant
    {
        public static List<AttendantModel> GetAttendants(int idJob)
        {
            List<AttendantModel> attendants = new List<AttendantModel>();

            SqlConnection con = new SqlConnection(Constants.connectionString);

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
                        IdUser = Convert.ToInt32(dr["ID Korisnika"]),
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

        public static void CreateAttendant(AttendantModel attendant)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Constants.connectionString))
                {
                    SqlCommand cmd = new SqlCommand("insertAttendant", con)
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
        public static void EditAttendant(AttendantModel attendant)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Constants.connectionString))
                {
                    SqlCommand cmd = new SqlCommand("updateAttendant", con)
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
        public static AttendantModel GetAttendant(int idJob, int idUser)
        {
            SqlConnection con = new SqlConnection(Constants.connectionString);


            SqlCommand cmd = new SqlCommand("getAttendant", con)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.Add(new SqlParameter("@IDjob", idJob));
            cmd.Parameters.Add(new SqlParameter("@IDuser", idUser));

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            AttendantModel attendant = new AttendantModel();
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
        public static AttendantModel GetAttendantId(int idJob, int idUser)
        {
            SqlConnection con = new SqlConnection(Constants.connectionString);


            SqlCommand cmd = new SqlCommand("getAttendantID", con)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.Add(new SqlParameter("@IDjob", idJob));
            cmd.Parameters.Add(new SqlParameter("@IDuser", idUser));

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            AttendantModel attendant = new AttendantModel();
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

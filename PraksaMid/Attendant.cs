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
                        SelectionTime =dr["Vrijeme odabira"].ToString()
                    };
                    attendants.Add(attendant);
                }
            }
            return attendants;
        }

    }
}
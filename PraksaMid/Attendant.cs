using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PraksaMid
{
    public class Attendant
    {
        public int Id { get; set; }
        public int IdJob { get; set; }
        public int IdUser { get; set; }
        public int IdInteres { get; set; }
        public int IdAttendance { get; set; }
        public string SelectionTime { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string Job { get; set; }
        public string Interes { get; set; }
        public string Attendance { get; set; }


        public List<Attendant> GetAttendants(string connectionString, int idJob)
        {
            List<Attendant> attendants = new List<Attendant>();

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
                    Attendant attendant = new Attendant
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
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;

namespace PraksaMid.Works
{
    public class Work
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public int IdAttendant { get; set; }

        public List<Work> GetWorks(string connectionString)
        {
            List<Work> works = new List<Work>();

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmd = new SqlCommand("getJobs", con)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr != null)
            {
                while (dr.Read())
                {
                    Work work = new Work
                    {
                        Id = Convert.ToInt32(dr["ID"]),
                        Name = dr["Naziv akcije"].ToString(),
                        Description = dr["Opis"].ToString(),
                        Location = dr["Mjesto"].ToString(),
                        Date = DateTime.Parse(dr["Datum"].ToString()).ToString("d"),
                        Time = DateTime.Parse(dr["Datum"].ToString()).ToString("t"),
                    };

                    works.Add(work);

                }
            }
            return works;
        }
    }
}
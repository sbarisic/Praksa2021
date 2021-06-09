using System;
using System.Collections.Generic;
using System.Data;
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
        public string Obligation { get; set; }
        public int IdAttendant { get; set; }

        public List<Work> GetWorks(string connectionString)
        {
            List<Work> works = new List<Work>();

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmd = new SqlCommand("getJobs", con)
            {
                CommandType = CommandType.StoredProcedure
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
                        Obligation = dr["Obaveznost"].ToString()
                    };

                    works.Add(work);

                }
            }
            return works;
        }

        public void CreateWork(string connectionString, Work work)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("insertJob", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    string dateStr = work.Date + " " + work.Time;
                    DateTime date = DateTime.Parse(dateStr);

                    cmd.Parameters.Add(new SqlParameter("@Name", work.Name));
                    cmd.Parameters.Add(new SqlParameter("@Date", date));
                    cmd.Parameters.Add(new SqlParameter("@Location", work.Location));
                    cmd.Parameters.Add(new SqlParameter("@Description", work.Description));

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

        public Work GetWork(string connectionString, int workId)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmd = new SqlCommand("getJob", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            SqlDataReader dr = cmd.ExecuteReader();
            cmd.Parameters.Add(new SqlParameter("@ID", workId));
            Work work = new Work();

            if (dr != null)
            {
                while (dr.Read())
                {
                    work.Name = dr["Naziv akcije"].ToString();
                    work.Description = dr["Opis"].ToString();
                    work.Location = dr["Mjesto"].ToString();
                    work.Date = DateTime.Parse(dr["Datum"].ToString()).ToString("d");
                    work.Time = DateTime.Parse(dr["Datum"].ToString()).ToString("t");
                    work.Obligation = dr["Obaveznost"].ToString();

                }
            }
            return work;
        }
    }
}

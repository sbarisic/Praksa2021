using PraksaMid.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace PraksaMid
{
    public static class Work
    {
        public static List<WorkModel> GetWorks(string connectionString)
        {
            List<WorkModel> works = new List<WorkModel>();

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
                    WorkModel work = new WorkModel
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

        public static void CreateWork(string connectionString, WorkModel work)
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
                    cmd.Parameters.Add(new SqlParameter("@Obligation", Convert.ToInt32(work.Obligation)));

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

        public static WorkModel GetWork(string connectionString, int workId)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlCommand cmd = new SqlCommand("getJob", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.Add(new SqlParameter("@IDjob", workId));

            SqlDataReader dr = cmd.ExecuteReader();
            WorkModel work = new WorkModel();

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

        public static void DeleteWork(string connectionString, int workId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("deleteJob", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@IDjob", workId));

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
        public static void EditWork(string connectionString, WorkModel work)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("updateJob", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    string dateStr = work.Date + " " + work.Time;
                    DateTime date = DateTime.Parse(dateStr);
                    cmd.Parameters.Add(new SqlParameter("@ID", work.Id));
                    cmd.Parameters.Add(new SqlParameter("@Name", work.Name));
                    cmd.Parameters.Add(new SqlParameter("@Date", date));
                    cmd.Parameters.Add(new SqlParameter("@Location", work.Location));
                    cmd.Parameters.Add(new SqlParameter("@Description", work.Description));
                    cmd.Parameters.Add(new SqlParameter("@Obligation", Convert.ToInt32(work.Obligation)));

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

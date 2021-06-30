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
    public static class WorkData
    {

        public static Task<List<Work>> GetWorks()
        {
            List<Work> works = new();

            SqlConnection con = ConnectionString.ConStr();
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
            return Task.FromResult(works);
        }

        public static void CreateWork(Work work)
        {
            try
            {
                using (SqlConnection con = ConnectionString.ConStr())
                {
                    SqlCommand cmd = new SqlCommand("insertJob", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

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

        public static void DeleteWork(int workId)
        {
            try
            {
                using (SqlConnection con = ConnectionString.ConStr())
                {
                    SqlCommand cmd = new SqlCommand("deleteJob", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

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
    }
}

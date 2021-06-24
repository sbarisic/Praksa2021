using System.Web.Configuration;

namespace PraksaMid
{
    public static class Constants
    {
        public static string connectionString = WebConfigurationManager.ConnectionStrings["Praksa2021"].ConnectionString;
    }
}
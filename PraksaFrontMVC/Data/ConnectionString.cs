using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PraksaFrontMVC.Data
{
    public static class ConnectionString
    {
        public static SqlConnection ConStr()
        {
            var configuration = GetConfiguration();
            return new SqlConnection(configuration.GetSection("ConnectionStrings").GetSection("PraksaFrontMVCContext").Value);
        }
        public static IConfiguration GetConfiguration()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            return builder.Build();
        }
    }
}
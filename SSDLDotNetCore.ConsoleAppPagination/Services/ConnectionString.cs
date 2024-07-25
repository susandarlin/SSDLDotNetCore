using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSDLDotNetCore.ConsoleAppPagination.Services;

internal static class ConnectionString
{
    public static SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
    {
        DataSource = "SANDAR\\MSSQLSERVER2012",
        InitialCatalog = "SSDLDotNetCore",
        UserID = "sa",
        Password = "admin123!",
        TrustServerCertificate = true
    };
}

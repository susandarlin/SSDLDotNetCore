﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSDLDotNetCore.PizzaApi;

internal static class ConnectionString
{
    public static SqlConnectionStringBuilder SqlConnectionStringBuilder = new SqlConnectionStringBuilder()
    {
        DataSource = "SANDAR\\MSSQLSERVER2012",
        InitialCatalog = "SSDLDotNetCore",
        UserID = "sa",
        Password = "admin123!",
        TrustServerCertificate = true
    };
}

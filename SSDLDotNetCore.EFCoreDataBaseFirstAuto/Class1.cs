using Microsoft.EntityFrameworkCore;

namespace SSDLDotNetCore.EFCoreDataBaseFirstAuto
{
    public class Class1
    {
        // Scaffold-DbContext "Server= SANDAR\MSSQLSERVER2012; Database=SSDLDotNetCore; User Id=sa; Password=admin123!; TrustServerCertificate = true;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir EfCoreDataModels -Context AppDbContext -Tables Tbl_Blog


        // dotnet tool install --global dotnet-ef => this is latest version
        // dotnet tool uninstall --global dotnet-ef --version 7.0.0

        // dotnet ef dbcontext scaffold "Server= SANDAR\MSSQLSERVER2012; Database=SSDLDotNetCore; User Id=sa; Password=admin123!; TrustServerCertificate = true;" Microsoft.EntityFrameworkCore.SqlServer -o EfCoreDataModels -c AppDbContext -t Tbl_Blog


        // Force to override (-f)
        // dotnet ef dbcontext scaffold "Server= SANDAR\MSSQLSERVER2012; Database=SSDLDotNetCore; User Id=sa; Password=admin123!; TrustServerCertificate = true;" Microsoft.EntityFrameworkCore.SqlServer -o EfCoreDataModels -c AppDbContext -f

    }
}

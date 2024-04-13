// See https://aka.ms/new-console-template for more information
using System.Data;
using System.Data.SqlClient;
using System.Net.NetworkInformation;

Console.WriteLine("Hello, World!");

// Ctrl + .

SqlConnectionStringBuilder stringBuilder = new SqlConnectionStringBuilder();
stringBuilder.DataSource = "SANDAR\\MSSQLSERVER2012";
stringBuilder.InitialCatalog = "SSDLDotNetCore";
stringBuilder.UserID = "sa";
stringBuilder.Password = "admin123!";
SqlConnection connection = new SqlConnection(stringBuilder.ConnectionString);
connection.Open();
Console.WriteLine("Connection open.");

string query = "Select * from tbl_Blog";
SqlCommand command = new SqlCommand(query, connection);
SqlDataAdapter adapter = new SqlDataAdapter(command);
DataTable dt = new DataTable();
adapter.Fill(dt);

connection.Close();
Console.WriteLine("Connection close.");

// dataset => datatable
// datatable => datarow
// datarow => datacolumn

foreach(DataRow dr in dt.Rows)
{
    Console.WriteLine("Blog Id => " + dr["BlogId"]);
    Console.WriteLine("Blog Title => " + dr["BlogTitle"]);
    Console.WriteLine("Blog Author => " + dr["BlogAuthor"]);
    Console.WriteLine("Blog Content => " + dr["BlogContent"]);
    Console.WriteLine("---------------------------------------");
}

Console.ReadKey();
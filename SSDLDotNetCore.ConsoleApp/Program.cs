// See https://aka.ms/new-console-template for more information
using SSDLDotNetCore.ConsoleApp;
using System.Data;
using System.Data.SqlClient;
using System.Net.NetworkInformation;

Console.WriteLine("Hello, World!");

AdoDotNetExample adoDotNetExample = new AdoDotNetExample();
//adoDotNetExample.Read();
adoDotNetExample.Create("title", "author", "content");

Console.ReadKey();
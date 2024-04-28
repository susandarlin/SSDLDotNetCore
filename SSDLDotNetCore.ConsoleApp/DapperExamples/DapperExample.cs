using Dapper;
using SSDLDotNetCore.ConsoleApp.Dtos;
using SSDLDotNetCore.ConsoleApp.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSDLDotNetCore.ConsoleApp.DapperExamples
{
    internal class DapperExample
    {
        public void Run()
        {
            //Read();
            //Edit(1);
            //Edit(15);

            //Create("new title", "new author", "new content");
            //Update(14, "update title", "update author", "update content");
            Delete(14);
        }

        private void Read()
        {
            using IDbConnection db = new SqlConnection(ConnectionString.SqlConnectionStringBuilder.ConnectionString);
            //using (IDbConnection db1 = new SqlConnection(ConnectionString.SqlConnectionStringBuilder.ConnectionString))
            //{
            //    db1.Open();
            //}
            //db1

            List<BlogDto> lst = db.Query<BlogDto>("select * from Tbl_Blog").ToList();
            //lst[0].asdf();

            foreach (BlogDto item in lst)
            {
                Console.WriteLine(item.BlogId);
                Console.WriteLine(item.BlogTitle);
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogContent);
                Console.WriteLine("------------------------------------");
            }
        }

        public void Edit(int id)
        {
            using IDbConnection db = new SqlConnection(ConnectionString.SqlConnectionStringBuilder.ConnectionString);
            var item = db.Query<BlogDto>("select * from Tbl_Blog where BlogId = @BlogId", new BlogDto { BlogId = id }).FirstOrDefault();
            if (item is null)
            {
                Console.WriteLine("No data found.");
                return;
            }

            Console.WriteLine(item.BlogId);
            Console.WriteLine(item.BlogTitle);
            Console.WriteLine(item.BlogAuthor);
            Console.WriteLine(item.BlogContent);
        }

        public void Create(string title, string author, string content)
        {
            var item = new BlogDto
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };

            string query = @"INSERT INTO [dbo].[Tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
     VALUES
           (@BlogTitle
           ,@BlogAuthor
           ,@BlogContent)";

            using IDbConnection db = new SqlConnection(ConnectionString.SqlConnectionStringBuilder.ConnectionString);
            int result = db.Execute(query, item);

            string message = result > 0 ? "Saving Successful" : "Saving Failed";
            Console.WriteLine(message);
        }

        public void Update(int id, string title, string author, string content)
        {
            var item = new BlogDto
            {
                BlogId = id,
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };

            var query = @"UPDATE [dbo].[Tbl_Blog]
   SET [BlogTitle] = @BlogTitle
      ,[BlogAuthor] = @BlogAuthor
      ,[BlogContent] = @BlogContent
 WHERE BlogId = @BlogId";

            using IDbConnection db = new SqlConnection(ConnectionString.SqlConnectionStringBuilder.ConnectionString);
            int result = db.Execute(query, item);

            string message = result > 0 ? "Updating Successful" : "Updating Failed";
            Console.WriteLine(message);
        }

        public void Delete(int id)
        {
            var item = new BlogDto
            {
                BlogId = id
            };

            var query = @"delete from tbl_blog where BlogId = @BlogId";

            using IDbConnection db = new SqlConnection(ConnectionString.SqlConnectionStringBuilder.ConnectionString);
            int result = db.Execute(query, item);

            string message = result > 0 ? "Deleting Successful" : "Deleting Failed";
            Console.WriteLine(message);
        }
    }
}

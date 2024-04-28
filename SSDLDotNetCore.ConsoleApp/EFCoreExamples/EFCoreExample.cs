using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSDLDotNetCore.ConsoleApp.Dtos;

namespace SSDLDotNetCore.ConsoleApp.EFCoreExamples
{
    internal class EFCoreExample
    {
        AppDbContext db = new AppDbContext();
        public void Run()
        {
            //Read();
            //Edit(1);
            //Edit(15);
            //Create("ef title", "ef author", "ef content");
            //Update(16, "update ef title", "update ef author", "update ef content");
            Delete(16);
        }

        private void Read()
        {
            var lst = db.Blogs.ToList();
            foreach (BlogDto item in lst)
            {
                Console.WriteLine(item.BlogId);
                Console.WriteLine(item.BlogTitle);
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogContent);
                Console.WriteLine("------------------------------------------");
            }
        }

        private void Edit(int id)
        {
            var item = db.Blogs.FirstOrDefault(x => x.BlogId == id);

            //foreach(BlogDto x in db.Blogs)
            //{
            //    if (x.BlogId == id)
            //    {

            //    }
            //}

            if (item is null)
            {
                Console.WriteLine("No data found.");
                return;
            }

            Console.WriteLine(item.BlogId);
            Console.WriteLine(item.BlogTitle);
            Console.WriteLine(item.BlogAuthor);
            Console.WriteLine(item.BlogContent);
            Console.WriteLine("------------------------------------------");

        }

        private void Create(string title, string author, string content)
        {
            var item = new BlogDto
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };

            db.Blogs.Add(item);
            int result = db.SaveChanges();

            string message = result > 0 ? "Saveing Successful." : "Saving Failed.";
            Console.WriteLine(message);
        }

        private void Update(int id, string title, string author, string content)
        {
            var item = db.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (item is null)
            {
                Console.WriteLine("No data found.");
            }

            item.BlogTitle = title;
            item.BlogAuthor = author;
            item.BlogContent = content;

            int result = db.SaveChanges();

            string message = result > 0 ? "Updating Successful." : "Updating Failed.";
            Console.WriteLine(message);
        }

        private void Delete(int id)
        {
            var item = db.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (item is null)
            {
                Console.WriteLine("No data found.");
            }

            db.Blogs.Remove(item);
            int result = db.SaveChanges();

            string message = result > 0 ? "Deleting Successful." : "Deleting Failed.";
            Console.WriteLine(message);
        }
    }
}

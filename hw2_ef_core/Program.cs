using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw2_ef_core
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var db = new NorthWindEntities())
            {
                foreach (var item in db.Categories)
                {
                    Console.WriteLine($"Id: {item.CategoryID}, Name: {item.CategoryName}\n Description: {item.Description}");
                }

            }
            using (var db = new NorthWindEntities())
            {
                db.Categories.Add(new Categories { CategoryName = "Electronics", Description = "Phones, PC, etc." });
                db.SaveChanges();
            }
            using (var db = new NorthWindEntities())
            {
                Console.WriteLine("--------------------------------------");
                foreach (var item in db.Categories)
                {
                    Console.WriteLine($"Id: {item.CategoryID}, Name: {item.CategoryName}\n Description: {item.Description} {item.Picture}");
                }
            }
            using (var db = new NorthWindEntities())
            {
                Console.WriteLine("--------------------------------------");
                var query = db.Categories.Where(c => c.CategoryName == "Electronics");
                foreach (var item in query)
                {
                    Console.WriteLine(item.CategoryName);
                }
            }

            using(var db = new NorthWindEntities())
            {
                var categorieToDelete = db.Categories.FirstOrDefault(c => c.CategoryName == "Electronics");
                db.Categories.Remove(categorieToDelete);
                db.SaveChanges();
            }
            using (var db = new NorthWindEntities())
            {
                Console.WriteLine("--------------------------------------");
                foreach (var item in db.Categories)
                {
                    Console.WriteLine($"Id: {item.CategoryID}, Name: {item.CategoryName}\n Description: {item.Description} {item.Picture}");
                }
            }
            Console.ReadKey();
        }
    }
}

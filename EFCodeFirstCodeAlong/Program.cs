// Install NuGet Packages: (.NET Core 3.1)
// =======================
// Microsoft.EntityFrameworkCore.SqlServer
// Microsoft.EntityFrameworkCore.Tools

// Create the Models folder. Then create the EFContext and the Product classes in the Models folder..
// Note: The name of the database is determined by the "Database=" parameter in the connection string (see the appsettings.json file).
// Note: At a minimum the Context class (EFContext.cs) must inherit DbContext and override the OnConfiguring method.

// Package Manager Console supports [Tab]. Type "Add" + [Tab]

// PM> Add-Migration "NewDatabase" (Creates the Migrations folder).
// PM> Update-Database (Creates the SQL Server Database)

// Dessa NuGets fordras för att få det att funka med appsettings.json.
// PM> Install-Package Microsoft.Extensions.Configuration
// PM> Install-Package Microsoft.Extensions.Configuration.FileExtensions
// PM> Install-Package Microsoft.Extensions.Configuration.Json

// Skapa en appsettings.json i roten. Add -> New Item -> "JavaScript JSON Configuration File"
// Denna kan sedan användas för att lagra SqlConnectionString
// Copy to output directory måste sättas (h-klick på appsettings.json -> properties) och välj
// "Copy Always" eller "Copy if newer".

// Uppdatera ändringar i Models mappan (EFContext, Product, Customer).
// PM> Add-Migration "Ver2"
// PM> Update-Database

using EFCodeFirstCodeAlong.Models;
using System;
using System.Collections.Generic;

namespace EFCodeFirstCodeAlong
{
    class Program
    {
        static void Main(string[] args)
        {
            //InsertProduct();
            ReadProducts();
            //UpdateProduct();
            //DeleteProduct();

            Console.Write("Press any key to continue...");
            Console.ReadKey(true);
        }

        private static void DeleteProduct()
        {
            using var db = new EFContext();
            Product product = db.Products.Find(2);

            if (product != null)
                db.Products.Remove(product);

            db.SaveChanges();
        }

        private static void UpdateProduct()
        {
            using var db = new EFContext();
            Product product = db.Products.Find(2);

            if (product != null)
                product.Name += "!";

            db.SaveChanges();
        }

        private static void ReadProducts()
        {
            using var db = new EFContext();

            foreach (var item in db.Products)
            {
                Console.WriteLine(item.Name);
            }
        }

        private static void InsertProduct()
        {
            Console.WriteLine("Adding data to DB");

            using var db = new EFContext();

            Product product = new Product();
            product.Name = "Pen Drive";
            db.Add(product);

            product = new Product();
            product.Name = "Memory Card";
            db.Add(product);

            db.SaveChanges();
        }
    }
}
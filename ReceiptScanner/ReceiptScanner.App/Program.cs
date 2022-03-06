using DataAccess.Database;
using Domain.Models;
using Services.Implementations;
using System;

namespace Application
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Example Output");
            Console.WriteLine("");

            Database<Product> database = new Database<Product>();
            ProductService<Product> productService = new ProductService<Product>(database);

            productService.PrintDomesticProducts();
            productService.PrintImportedProducts();
            productService.PrintProductsCost();
            productService.PrintProductsCount();

            Console.ReadLine();
        }
    }
}

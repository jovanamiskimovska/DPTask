using Domain.Database;
using Domain.Models;
using Services.Implementations;
using System;

namespace ReceiptScanner
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Example Output");

            Database productDatabase = new Database();
            ProductService productService = new ProductService(productDatabase);

            productService.PrintDomesticProducts();
            productService.PrintImportedProducts();
            productService.PrintProductsCost();
            productService.PrintProductsCount();

            Console.ReadLine();
        }
    }
}

using DataAccess.Database;
using Domain.Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Implementations
{
    public class ProductService<T> : IProductService<T> where T : Product
    {

        private IDatabase<Product> _database { get; set; }

        public ProductService(Database<Product> database)
        {
            _database = SortAlphabetically(database);
        }


        public void PrintDomesticProducts()
        {
            Console.WriteLine(". Domestic");
            foreach (Product product in _database.GetAllProducts())
            {
                if (product.IsDomestic)
                {
                    PrintProductDetails(product);
                }
            }
        }

        public void PrintImportedProducts()
        {
            Console.WriteLine(". Imported");
            foreach (Product product in _database.GetAllProducts())
            {

                if (!product.IsDomestic)
                {
                    PrintProductDetails(product);
                }
            }
        }

        public void PrintProductPrice(float price)
        {
            string productPrice = price.ToString("N1");
            Console.WriteLine("    Price: " + productPrice);
        }

        public void PrintProductDescription(string description)
        {
            string shortDescription = description;
            if (description.Length > 10)
            {
                shortDescription = shortDescription.Substring(0,10);
                Console.WriteLine("    " + shortDescription+"...");
            }
            else
            {
                Console.WriteLine("    " + description);
            }         
        }

        public void PrintProductWeight(int? weight)
        {
            if(weight != null)
            {
                Console.WriteLine("    Weight: " + weight);
            }
            else
            {
                Console.WriteLine("    Weight: N/A");
            }
        }

        public IDatabase<Product> SortAlphabetically(Database<Product> database)
        {
            List<Product> alphabeticalProductList = new List<Product>();
            alphabeticalProductList = database.GetAllProducts();
            alphabeticalProductList = alphabeticalProductList.OrderBy(x => x.ProductName).ToList();
            database.UpdateProducts(alphabeticalProductList);

            return database;
        }

        public void PrintProductsCost()
        {
            double domProductCost = _database.GetAllProducts().Where(x => x.IsDomestic == true).Select(x => x.ProductPrice).Sum();
            string domProductCostToString = domProductCost.ToString("N1");
            double impProductCost = _database.GetAllProducts().Where(x => x.IsDomestic == false).Select(x => x.ProductPrice).Sum();
            string impProductCostToString = impProductCost.ToString("N1");
            Console.WriteLine("Domestic cost: $"+ domProductCostToString);
            Console.WriteLine("Imported cost: $" + impProductCostToString);
        }

        public void PrintProductsCount()
        {
            double domProductCount = _database.GetAllProducts().Where(x => x.IsDomestic == true).Count();
            double impProductCount = _database.GetAllProducts().Where(x => x.IsDomestic == false).Count();
            Console.WriteLine("Domestic count: " + domProductCount);
            Console.WriteLine("Imported count: " + impProductCount);
        }
        public void PrintProductDetails(Product product)
        {
            Console.WriteLine("... " + product.ProductName);
            PrintProductPrice(product.ProductPrice);
            PrintProductDescription(product.ProductDesc);
            PrintProductWeight(product.ProductWeight);
        }

    }
}


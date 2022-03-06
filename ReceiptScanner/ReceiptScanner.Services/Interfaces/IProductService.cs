using Domain.Models;
using System;
using System.Collections.Generic;

namespace Services.Interfaces
{
    public interface IProductService<T> where T : Product
    {
        void PrintDomesticProducts();
        void PrintImportedProducts();
        void PrintProductPrice(float price);
        void PrintProductDescription(string description);
        void PrintProductWeight(int? weight);
        void PrintProductsCost();
        void PrintProductsCount();
        void PrintProductDetails(Product product);
    }
}

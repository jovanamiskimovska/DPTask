using Domain.Models;
using System;
using System.Collections.Generic;

namespace DataAccess.Database
{
    public interface IDatabase<T> where T : Product
    {
        List<T> GetAllProducts();
        void UpdateProducts(List<T> updatedProducts);
    }
}


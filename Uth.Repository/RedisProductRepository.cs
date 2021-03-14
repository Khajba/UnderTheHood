using System;
using System.Collections.Generic;
using System.Text;
using Uth.Common.Entities;
using Uth.Repository.Abstract;

namespace Uth.Repository
{
    public class RedisProductRepository : IProductRepository
    {
        private static List<Product> Products = new List<Product>();

        public void AddProduct(Product product)
        {
            product.Id = GetNextId();
            Products.Add(product);

        }

        public bool DeleteProduct(int id)
        {
            var product = Products.Find(p => p.Id == id);

            if (product == null)
            {
                return false;
            }
            else
            {
                Products.Remove(product);
                return true;
            }

        }

        public Product GetProductById(int id)
        {
            var product = Products.Find(p => p.Id == id);
            return product;
        }

        public List<Product> GetProducts()
        {
            return Products;
        }

        public bool UpdateProduct(Product product)
        {
            var productIndex = Products.FindIndex(p => p.Id == product.Id);

            if (productIndex < 0)
            {
                return false;
            }
            else
            {
                Products[productIndex] = product;
                return true;
            }
        }

        private int GetNextId()
        {
            int maxId = 0;
            foreach (var item in Products)
            {
                if (item.Id > maxId)
                {
                    maxId = item.Id;
                }
            }
            return maxId + 1;
        }
    }
}

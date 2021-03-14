using System;
using System.Collections.Generic;
using System.Text;
using Uth.Common.Entities;

namespace Uth.Repository.Abstract
{
    public interface IProductRepository
    {
        public void AddProduct(Product product);
        public bool UpdateProduct(Product product);
        public bool DeleteProduct(int id);
        public List<Product> GetProducts();
        public Product GetProductById(int id);
    }
}

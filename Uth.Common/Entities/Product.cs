using System;
using System.Collections.Generic;
using System.Text;
using Uth.Common.Enums;

namespace Uth.Common.Entities
{
   public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public ProductType Type { get; set; }
        public DateTime? ExpirationDate { get; set; }
    }
}

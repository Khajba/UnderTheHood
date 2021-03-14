using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Uth.Common.Enums;

namespace Uth.Admin.Api.Models
{
    public class AddProductModel
    {
         [Required]
        public string Name { get; set; }

        [Required]
        public int? Price { get; set; }

        [Required]
        public ProductType? Type { get; set; }

        public DateTime? ExpirationDate { get; set; }

    }
}

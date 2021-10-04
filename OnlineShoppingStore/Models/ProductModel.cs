using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShoppingStore.Models
{
    public class ProductModel
    {
        public int Id { get; set; }

        [Required]
        public string ProductName { get; set; }
        [Required]
        public string ProductDiscription { get; set; }
        [Required]
        public string ProductRating { get; set; }
        [Required]
        public string ProductImage { get; set; }
        [Required]
        public string ProductType { get; set; }

        [Required]
        public decimal Price { get; set; }
    }
}
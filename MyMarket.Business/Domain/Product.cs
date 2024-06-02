using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyMarket.Business.Domain
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string ProductName { get; set; }

        [Required]
        public string ProductImage { get; set; }

        [Required]
        public string Description { get; set; }
    }

    public enum Currency
    {
        GBP,
        EUR,
        USD
    }
}

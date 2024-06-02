using System;
using System.Collections.Generic;
using System.Text;

namespace MyMarket.Data.Entities
{
    public class Product
    {
        public int Id { get; set; }

        public string ProductName { get; set; }

        public string ProductImage { get; set; }

        public string Description { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace DNKApp.Models
{
    public class Product
    {
        public int? productId { get; set; }
        public string ProductName { get; set;}
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public string Price { get; set; }
        public string Image { get; set; }
        public int? BrandId { get; set; }
        public string BrandName { get; set; }
        public int? CategoryId { get; set; }
        private string CategoryName { get; set; }
        
    }
}

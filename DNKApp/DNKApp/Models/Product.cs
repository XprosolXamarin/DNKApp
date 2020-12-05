using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace DNKApp.Models
{
    public class Product
    {
        public int? productId { get; set; }
        public int? id { get; set; }
        public string name { get; set; }
        public string ProductName { get; set;}
        public string description { get; set;}
        public string short_description { get; set;}
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public string Price { get; set; }
        public ObservableCollection<ImageSource> images { get; set; }
        public string Image { get; set; }
        public int? BrandId { get; set; }
        public string BrandName { get; set; }
        public ObservableCollection<CategoryName> categories { get; set; }
        
    }
    public class CategoryName
    {
        public int? id { get; set; }
        public string name { get; set; }
        public string slug { get; set; }
    }
    public class ImageSource
    {
        public int? id { get; set; }
        public string name { get; set; }
        public string src { get; set; }
        
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace DNKApp.Models
{
    public class Category
    {
        public int id { get; set; }
        public string name { get; set; }
        public string slug { get; set; }
        public string description { get; set; }
        public Image image  { get; set; }
        public int count { get; set; }
        
    }
    public class Image
    {
    public int id { get; set; }
    public string src { get; set; }
    public string alt { get; set; }

}
}

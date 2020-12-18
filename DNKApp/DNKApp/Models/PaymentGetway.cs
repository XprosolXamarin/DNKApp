using System;
using System.Collections.Generic;
using System.Text;

namespace DNKApp.Models
{
    public class PaymentGetway
    {
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public int order { get; set; }
        public Boolean enabled { get; set; }
        public string method_title { get; set; }
        public string method_description { get; set; }
        public List<Method_Supports> method_supports { get; set; }
        public Settings settings { get; set; }
    }
    public class Settings
    {
        public string id { get; set; }
        public string label { get; set; }
        public string description { get; set; }
        public string type { get; set; }
        public string value { get; set; }
       
        public string tip { get; set; }
        public string placeholder { get; set; }

    }
    public class Method_Supports
    {

    }
}

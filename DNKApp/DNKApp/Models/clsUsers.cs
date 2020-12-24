using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DNKApp.Models
{
   public class clsUsers
    {
        
        public string email { get; set; }
        
        public string first_name { get; set; }
        
        public string last_name { get; set; }
        
        public string username { get; set; }
        public Billing billing { get; set; }
        public Shipping shipping { get; set; }
    }
   
}

using System;
using System.Collections.Generic;
using System.Text;

namespace DNKApp.Models
{
   public class clsUserDataById
    {
        public int id { get; set; }
        public DateTime date_created { get; set; }
        public DateTime date_created_gmt { get; set; }
        public DateTime date_modified { get; set; }
        public DateTime date_modified_gmt { get; set; }
        public string email { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string role { get; set; }
        public string username { get; set; }
        public IList<Billing1> billing { get; set; }
        public IList<Shipping1> shipping { get; set; }
        public bool is_paying_customer { get; set; }
        public ImageSource avatar_url { get; set; }
    }
    public class Billing1
    {
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string company { get; set; }

        public string address_1 { get; set; }
        public string address_2 { get; set; }
        public string city { get; set; }
        public string postcode { get; set; }
        public string country { get; set; }
        public string state { get; set; }



        public string email { get; set; }

        public string phone { get; set; }
    }
  public  class Shipping1
    {
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string company { get; set; }

        public string address_1 { get; set; }
        public string address_2 { get; set; }
        public string city { get; set; }
        public string postcode { get; set; }
        public string country { get; set; }
        public string state { get; set; }

    }
   
}

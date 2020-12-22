using DNKApp.ViewModels;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace DNKApp.Models
{
    public class PaymentGetway:BaseViewModel
    {
        private string _id;
        public string id 
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
                OnPropertyChanged();

            } 
        }
        private string _title;
        public string title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
                OnPropertyChanged();

            }
        }
        //public string description { get; set; }
        //public int order { get; set; }
        //public bool enabled { get; set; }
        //public string method_title { get; set; }
        //public string method_description { get; set; }
        //public List method_supports {get; set;}
        //public Settings settings { get; set; }
       
    }
    public class Settings
    {
        public Title title { get; set; }
        public Instructions instructions { get; set; }

       

    }
    public class Title
    {
        public string id { get; set; }
        public string label { get; set; }
        public string description { get; set; }
        public string type { get; set; }
        public string value { get; set; }

        public string tip { get; set; }
        public string placeholder { get; set; }
    }
    public class Instructions
    {
        public string id { get; set; }
        public string label { get; set; }
        public string description { get; set; }
        public string type { get; set; }
        public string value { get; set; }

        public string tip { get; set; }
        public string placeholder { get; set; }

    }


}

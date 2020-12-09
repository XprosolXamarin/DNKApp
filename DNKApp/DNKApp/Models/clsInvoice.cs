using DNKApp.ViewModels;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace DNKApp.Models
{
    public class clsInvoice : BaseViewModel

    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string ProductName { get; set; }
        public string Price { get; set; }
        public int? Qty { get; set; }
        public string imagepath { get; set; }

    }
}

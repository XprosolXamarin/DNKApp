using DNKApp.ViewModels;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace DNKApp.Models
{
    public class clsInvoice : BaseViewModel

    {
        [PrimaryKey]
        public int id { get; set; }
        public string name { get; set; }
       
        private int _SRate;
        public int SRate
        {
            get { return _SRate; }
            set
            {
                _SRate = value;

                OnPropertyChanged();
            }
        }
        public int FRate { get; set; }
        private int _quantity { get; set; }
        public int quantity
        {
            get { return _quantity; }
            set
            {
                if (value > 1)
                    _quantity = value;
                else
                    _quantity = 1;
                OnPropertyChanged();
            }
        }
        public string imagepath { get; set; }
        public DateTime DateTime { get; set; }
        public string price => FRate.ToString();

    }
}

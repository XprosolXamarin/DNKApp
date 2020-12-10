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
        private int _Qty { get; set; }
        public int Qty
        {
            get { return _Qty; }
            set
            {
                if (value > 1)
                    _Qty = value;
                else
                    _Qty = 1;
                OnPropertyChanged();
            }
        }
        public string imagepath { get; set; }

    }
}

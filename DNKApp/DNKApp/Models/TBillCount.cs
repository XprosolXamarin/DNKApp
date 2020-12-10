using DNKApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DNKApp.Models
{
    public class TBillCount : BaseViewModel
    {
        private int _TBill;
        public int TBill
        {
            get { return _TBill; }
            set
            {
                _TBill = value;

                OnPropertyChanged();
            }
        }
        private int _TCount;
        public int TCount
        {
            get { return _TCount; }
            set
            {
                _TCount = value;

                OnPropertyChanged();
            }
        }
    }
}

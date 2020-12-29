using System;
using System.Collections.Generic;
using System.Text;

namespace DNKApp.ViewModels
{
    public class OrderAcceptedviewModel:BaseViewModel
    {
        private string _orderid;
        public string orderid
        {
            get { return _orderid; }
            set
            {
                _orderid = value;
                OnPropertyChanged();
            }
        }

        public OrderAcceptedviewModel(string orderid)
        {
            this.orderid = orderid;
        }
    }
}

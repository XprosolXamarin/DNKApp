using DNKApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DNKApp.Models
{
    class clsResponse:BaseViewModel
    {
        public bool Status { get; set; }
        public string Message { get; set; }

       
        private string _OrderNumber { get; set; }

        public string OrderNumber
        {
            get { return _OrderNumber; }
            set
            {
                _OrderNumber = value;

                OnPropertyChanged();
            }
        }
    }
}

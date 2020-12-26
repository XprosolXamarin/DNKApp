using DNKApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DNKApp.ViewModels
{
    class ProductDetailViewModel:BaseViewModel
    {
        private Product _productDetailView;
        public Product productDetailView
        {
            get
            {
                return _productDetailView;

            }
            set
            {
                _productDetailView = value;
                OnPropertyChanged();
            }
        }
        private int _Quantity;
        public int Quantity
        {
            get { return _Quantity; }
            set
            {
                if (value > 1)
                    _Quantity = value;
                else
                    _Quantity = 1;
                OnPropertyChanged();
            }
        }



        public ProductDetailViewModel(Product productDetailView)
        {
            this.productDetailView = productDetailView;
            Quantity = 0;
        }
    }
}

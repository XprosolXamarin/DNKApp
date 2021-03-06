﻿using DNKApp.Models;
using DNKApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DNKApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductDetailView : ContentPage
    {
        public ProductDetailView(Product productDetailView)
        {
            InitializeComponent();
            BindingContext = new ProductDetailViewModel(productDetailView);
        }
    }
}
using DNKApp.Models;
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
    public partial class PaymentPage : ContentPage
    {
        public PaymentPage()
        {
            InitializeComponent();
            BindingContext = new GetwayViewModel();
        }

        private async void PaymentMethods_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var Methods = e.CurrentSelection.FirstOrDefault() as PaymentGetway;
            if (Methods == null)
                return;
            await Navigation.PushAsync(new OrderDetailPage(Methods));
            _ = ((CollectionView)sender).SelectedItem == null;

        }
    }
}
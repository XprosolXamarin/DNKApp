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
    public partial class OrderDetailPage : ContentPage
    {
        public OrderDetailPage(Models.PaymentGetway methods)
        {
            InitializeComponent();
            BindingContext = new SummaryViewModel(Navigation);
        }
    }
}
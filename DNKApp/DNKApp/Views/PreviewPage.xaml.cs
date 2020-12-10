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
    public partial class PreviewPage : ContentPage
    {
        
        public PreviewPage(string name, Models.ImageSource imageSource, int price, string longDescription, CategoryName categoryName, string description)
        {
            InitializeComponent();
            BindingContext = new PreviewPageViewModel(name, imageSource, price, longDescription, categoryName, description);
        }

        
    }
}
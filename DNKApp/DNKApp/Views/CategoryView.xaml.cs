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
    public partial class CategoryView : ContentPage
    {
        public CategoryView(Category category)
        {
            InitializeComponent();
            BindingContext = new CategoryViewModel(category);
        }

        private async void Categories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var ProductDetailView = e.CurrentSelection.FirstOrDefault() as Product;
            if (ProductDetailView == null)
                return;
            await Navigation.PushModalAsync(new ProductDetailView(ProductDetailView));
            _ = ((CollectionView)sender).SelectedItem == null;

        }
    }
}
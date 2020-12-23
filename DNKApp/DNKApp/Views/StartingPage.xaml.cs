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
    public partial class StartingPage : ContentPage
    {
        public StartingPage()
        {
            InitializeComponent();
            BindingContext = new StartingViewModel(Navigation);
        }
    }
}
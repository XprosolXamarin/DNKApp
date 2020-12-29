using DNKApp.Utlities;
using DNKApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DNKApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HeaderContentView : ContentView
    {
        public  HeaderContentView()
        {
            InitializeComponent();
            BindingContext = new HeaderContentViewModel();
        }
    }
}
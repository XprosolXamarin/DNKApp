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
    public partial class SummaryPage : ContentPage
    {
        private bool codcheckbox;
        private string card_Name;
        private string card_Number;
        private string cVV;

        public SummaryPage(bool codcheckbox, string card_Name, string card_Number, string cVV)
        {
            InitializeComponent();
            BindingContext = new SummaryViewModel(Navigation, codcheckbox, card_Name,card_Number, cVV);
        }

       
    }
}
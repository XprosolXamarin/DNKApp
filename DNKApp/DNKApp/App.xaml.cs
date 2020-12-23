using DNKApp.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DNKApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
           
            MainPage = new NavigationPage(new StartingPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

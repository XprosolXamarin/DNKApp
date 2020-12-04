using Android.App;
using DNKApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Application = Xamarin.Forms.Application;

namespace DNKApp.ViewModels
{
  public class SplashViewModel
    {
        public SplashViewModel()
        {
            _ = DelayFun();
        }
        public async Task<int> DelayFun()
        {
            await Task.Delay(3000);
            Application.Current.MainPage = new AppShell();
            return 1;

        }
    }

}

using Android.App;
using DNKApp.Models;
using DNKApp.Services;
using DNKApp.Views;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Application = Xamarin.Forms.Application;

namespace DNKApp.ViewModels
{
  public class SplashViewModel
    {
        public List<PaymentGetway> paymentGetways { get; set; }
        private readonly PaymentGetwayService _paymentGetwayService;
        private SQLiteAsyncConnection _connection;

        public SplashViewModel()
        {
            // _ = DelayFun();
            _connection = Xamarin.Forms.DependencyService.Get<ISQLiteDb>().GetConnection();
            _connection.CreateTableAsync<PaymentGetway>();
            _connection.Table<PaymentGetway>().ToListAsync();
            
            _paymentGetwayService = new PaymentGetwayService();
            _ = GetListPaymentGetwayAsync();
            
        }
         private async Task GetListPaymentGetwayAsync()
        {
            //paymentGetways = new ObservableCollection<PaymentGetway>();
            var current = Connectivity.NetworkAccess;

            if (current == NetworkAccess.Internet)
            {
                paymentGetways = await _paymentGetwayService.GetPaymentGetwaysAsync();
                
                if (paymentGetways != null)
                {
                    foreach (var method in paymentGetways)
                    {
                        PaymentGetway list = new PaymentGetway();
                        list.id = method.id;
                        list.title = method.title;



                        await _connection.InsertAsync(list);
                    }
                }


                Application.Current.MainPage = new NavigationPage(new StartingPage());
                
                
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("", "Please Connect with Internet.", "ok");
                //Isbusy = false;
            }
        }
        //public async Task DelayFun()
        //{


        //    await Task.Delay(3000);
        //    Application.Current.MainPage = new AppShell();
        //    return 1;

        //}
    }

}

using Android.App;
using DNKApp.Models;
using DNKApp.Services;
using DNKApp.Utlities;
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
        private readonly LoginService _loginService;
        
        public List<PaymentGetway> paymentGetways { get; set; }
        private readonly PaymentGetwayService _paymentGetwayService;
        private SQLiteAsyncConnection _connection;

        public SplashViewModel()
        {
            // _ = DelayFun();
            _loginService = new LoginService();
            
            _connection = Xamarin.Forms.DependencyService.Get<ISQLiteDb>().GetConnection();
            _connection.CreateTableAsync<PaymentGetway>();
            _connection.Table<PaymentGetway>().ToListAsync();
            
            _paymentGetwayService = new PaymentGetwayService();
            _ = GetListPaymentGetwayAsync();
            LoginExist();

        }
        public async void LoginExist()
        {

            try
            {
                var username = Utilty.GetSecureStorageValueFor(Utilty.UserName);
                var password = Utilty.GetSecureStorageValueFor(Utilty.Password);
                var response1 = await _loginService.UserLoginAsync(username.Result, password.Result);
                if (response1.Status)
                {
                    
                    Application.Current.MainPage = new AppShell();
                    
                }
                else
                {
                    Application.Current.MainPage = new NavigationPage(new StartingPage());
                }
            }
            catch (Exception ex)
            {
                // Possible that device doesn't support secure storage on device.
            }

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

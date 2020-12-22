using DNKApp.Models;
using DNKApp.Services;
using DNKApp.Views;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace DNKApp.ViewModels
{
    class PaymentMethodViewModel: BaseViewModel
    {
        #region
        private DatePicker _ExDate;
        public DatePicker ExDate
        {
            get { return _ExDate; }
            set
            {
                _ExDate = value;

                OnPropertyChanged();
            }
        }
        private bool _codcheckbox;
        public bool codcheckbox
        {
            get { return _codcheckbox; }
            set
            {
                _codcheckbox = value;

                OnPropertyChanged();
            }
        }
        private string _Card_Name;
        public string Card_Name
        {
            get { return _Card_Name; }
            set
            {
                _Card_Name = value;

                OnPropertyChanged();
            }
        }
        private string _Card_Number;
        public string Card_Number
        {
            get { return _Card_Number; }
            set
            {
                _Card_Number = value;

                OnPropertyChanged();
            }
        }

        private string _CVV;
        private INavigation navigation;
        private SQLiteAsyncConnection _connection;

        public string CVV
        {
            get { return _CVV; }
            set
            {
                _CVV = value;

                OnPropertyChanged();
            }
        }
        #endregion
        private readonly PaymentGetwayService _paymentGetwayService;
        public List<PaymentGetway> MethodList { get; set; }
        public ObservableCollection<PaymentGetway> paymentGetways { get; set; }
       
        //public ObservableCollection<PaymentGetway> paymentGetways
        //{
        //    get { return _paymentGetways; }
        //    set { _paymentGetways = value; }
        //}

        public PaymentMethodViewModel(INavigation navigation)
        {
            
            this.navigation = navigation;
            _connection = Xamarin.Forms.DependencyService.Get<ISQLiteDb>().GetConnection();
            paymentGetways = new ObservableCollection<PaymentGetway>();
            _ = getallMethodAsync();
            //_paymentGetwayService = new PaymentGetwayService();

            //_ = GetListPaymentGetwayAsync();

        }

        private async Task getallMethodAsync()
        {
          
            MethodList = await _connection.Table<PaymentGetway>().ToListAsync();
            await _connection.DropTableAsync<PaymentGetway>();
            paymentGetways = new ObservableCollection<PaymentGetway>(MethodList);
        }

        //private async Task GetListPaymentGetwayAsync()
        //{
        //    //paymentGetways = new ObservableCollection<PaymentGetway>();
        //    var current = Connectivity.NetworkAccess;

        //    if (current == NetworkAccess.Internet)
        //    {
        //        paymentGetways = await _paymentGetwayService.GetPaymentGetwaysAsync();


        //    }
        //    else
        //    {
        //        await Application.Current.MainPage.DisplayAlert("", "Please Connect with Internet.", "ok");
        //        //Isbusy = false;
        //    }
        //}

        public Command<PaymentGetway> NavigateSummaryPage
        {

            get
            {

                return new Command<PaymentGetway>(async (PaymentGetway P) =>
                {
                    //await navigation.PushAsync(new SummaryPage(P.id,P.title));
                    //if (codcheckbox)
                    //{
                    //    await navigation.PushAsync(new SummaryPage(codcheckbox,Card_Name,Card_Number,CVV));
                    //}

                    //else if (Card_Name == null || Card_Number == null || CVV == null)
                    //{
                    //    //DependencyService.Get<IMessage>().Longtime("Please Enter Complete Detail");
                    //    await Application.Current.MainPage.DisplayAlert("", "Please enter Complete Detail", "OK");
                    //}
                    //else
                    //{
                    //    await navigation.PushAsync(new SummaryPage(codcheckbox, Card_Name, Card_Number, CVV));
                    //}
                });
            }
        }
        public Command popCommand
        {

            get
            {

                return new Command(async () =>
                {
                    await Application.Current.MainPage.Navigation.PopAsync();
                });
            }
        }
       
    }
}

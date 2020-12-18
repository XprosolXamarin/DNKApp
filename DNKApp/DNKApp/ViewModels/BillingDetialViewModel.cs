using DNKApp.Models;
using DNKApp.Views;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace DNKApp.ViewModels
{
    class BillingDetialViewModel:BaseViewModel
    {
        private SQLiteAsyncConnection _connection;
        #region
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
       
        private string _first_name;
        public string first_name
        {
            get { return _first_name; }
            set
            {
                _first_name = value;

                OnPropertyChanged();
            }
        }
        private string _last_name;
        public string last_name
        {
            get { return _last_name; }
            set
            {
                _last_name = value;

                OnPropertyChanged();
            }
        }

        private string _company;
        public string company
        {
            get { return _company; }
            set
            {
                _company = value;

                OnPropertyChanged();
            }
        }
        private string _address_1;
        public string address_1
        {
            get { return _address_1; }
            set
            {
                _address_1 = value;

                OnPropertyChanged();
            }
        }
        private string _address_2;
        public string address_2
        {
            get { return _address_2; }
            set
            {
                _address_2 = value;

                OnPropertyChanged();
            }
        }
        private string _city;
        public string city
        {
            get { return _city; }
            set
            {
                _city = value;

                OnPropertyChanged();
            }
        }
        private string _state;
        public string state
        {
            get { return _state; }
            set
            {
                _state = value;

                OnPropertyChanged();
            }
        }
        private string _postcode;
        public string postcode
        {
            get { return _postcode; }
            set
            {
                _postcode = value;

                OnPropertyChanged();
            }
        }
        private string _country;
        public string country
        {
            get { return _country; }
            set
            {
                _country = value;

                OnPropertyChanged();
            }
        }
        private string _email;
        public string email
        {
            get { return _email; }
            set
            {
                _email = value;

                OnPropertyChanged();
            }
        }
        private string _phone;
        private INavigation navigation;

        public string phone
        {
            get { return _phone; }
            set
            {
                _phone = value;

                OnPropertyChanged();
            }
        }

        #endregion
        public BillingDetialViewModel(INavigation navigation)
        {
            this.navigation = navigation;
            _connection = Xamarin.Forms.DependencyService.Get<ISQLiteDb>().GetConnection();
            _connection.CreateTableAsync<Billing>();
            _connection.Table<Billing>().FirstAsync();
            _connection.CreateTableAsync<Shipping>();
            _connection.Table<Shipping>().FirstAsync();
            //_connection.CreateTableAsync<ShippingLine>();
            //_connection.Table<ShippingLine>().ToListAsync();
        }

      

        public Command NavigateToPaymentMethodCommand
        {

            get
            {

                return new Command(async () =>
                {
                    var billing = new Billing { first_name = first_name, last_name = last_name, address_1 = address_1, city = city, state = state, postcode = postcode, country = country, email = email, phone = phone };

                    await _connection.InsertAsync(billing);
                    var shipping = new Shipping { first_name = first_name, last_name = last_name, address_1 = address_1, city = city, state = state, postcode = postcode, country = country };

                    await _connection.InsertAsync(shipping);
                    
                    //var shippingLine = new ShippingLine { method_title = "Flat Rate", method_id = "flat_rate", total = TBill.ToString() };
                    //await _connection.InsertAsync(shippingLine);
                  await navigation.PushAsync(new PaymentPage());
                });
            }
        }
        public Command popCommand
        {

            get
            {

                return new Command(async () =>
                {
                    await navigation.PopAsync();
                });
            }
        }
    }
}

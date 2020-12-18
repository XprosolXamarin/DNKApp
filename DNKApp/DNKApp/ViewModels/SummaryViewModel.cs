﻿using DNKApp.Models;
using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DNKApp.ViewModels
{
    class SummaryViewModel:BaseViewModel
    {
        private SQLiteAsyncConnection _connection;
        private INavigation navigation;
        public List<clsInvoice> _myCollection;
        private bool codcheckbox;
        private string card_Name;
        private string card_Number;
        private string cVV;

        public List<clsInvoice> myCollection
        {
            get
            {
                return _myCollection;
            }
            set
            {
                _myCollection = value;
                OnPropertyChanged();


            }
        }
        private ObservableCollection<clsInvoice> _invoice { get; set; }
        public ObservableCollection<clsInvoice> invoice
        {
            get
            {
                return _invoice;
            }
            set
            {
                _invoice = value;
                OnPropertyChanged();
            }
        }
       
        public SummaryViewModel(INavigation navigation, bool codcheckbox, string card_Name, string card_Number, string cVV)
        {
            this.codcheckbox = codcheckbox;
            this.card_Name = card_Name;
            this.card_Number = card_Number;
            this.cVV = cVV;
            this.navigation = navigation;
            _connection = Xamarin.Forms.DependencyService.Get<ISQLiteDb>().GetConnection();
            _ = getallcaetitem();
        }

        private async Task getallcaetitem()
        {
            try
            {
                myCollection = await _connection.Table<clsInvoice>().ToListAsync();
                invoice = new ObservableCollection<clsInvoice>(myCollection);

               

            }
            catch (Exception ex)
            {

            }
        }

        public Xamarin.Forms.Command PlaceOrder
        {
            get
            {
                return new Xamarin.Forms.Command(async () =>
                {
                    OrderDetailModel order = new OrderDetailModel();
                    if (codcheckbox && card_Name != null && card_Number != null && cVV != null)
                    {

                    }
                    else if (codcheckbox)
                    {
                        order.payment_method = "cod";
                        order.payment_method = "Cash on delivery";
                        order.set_paid = false;
                    }
                    else
                    {

                    }


                    // await _placeorderapi.OrderAsync();



                    order.billing = await _connection.Table<Billing>().FirstAsync();
                    order.shipping = await _connection.Table<Shipping>().FirstAsync();
                    order.line_items = await _connection.Table<LineItems>().ToListAsync();
                    var Httpclient = new HttpClient();

                    var url = "https://qepdns.com/wp-json/wc/v3/orders?consumer_key=ck_c822f95423287f7ccd15df53b7e56d3de3d5468d&consumer_secret=cs_e1f61450a3c4a7430ce1f493b116912ed60929b5";

                    var uri = new Uri(string.Format(url, string.Empty));

                    var json = JsonConvert.SerializeObject(order);

                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = null;

                    response = await Httpclient.PostAsync(uri, content);

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

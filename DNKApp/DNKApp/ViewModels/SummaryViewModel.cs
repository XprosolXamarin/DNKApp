using DNKApp.Models;
using DNKApp.Services;
using DNKApp.Utlities;
using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DNKApp.ViewModels
{
    class SummaryViewModel:BaseViewModel
    {
        private readonly GetBillingDetailbyId _BillingDetailService;
        private readonly LoginService _loginService;
        private SQLiteAsyncConnection _connection;
        private INavigation navigation;
        public List<clsInvoice> _myCollection;
        private string id;
        private string title;
        private PaymentGetway methods;

        //private bool codcheckbox;
        //private string card_Name;
        //private string card_Number;
        //private string cVV;

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
       
       
        public SummaryViewModel(INavigation navigation /*PaymentGetway _paymentGetway*/)
        {
            _BillingDetailService = new GetBillingDetailbyId();
            _loginService = new LoginService();
            //this.codcheckbox = codcheckbox;
            //this.card_Name = card_Name;
            //this.card_Number = card_Number;
            //this.cVV = cVV;
            //this.methods = _paymentGetway;

            this.navigation = navigation;
            _connection = Xamarin.Forms.DependencyService.Get<ISQLiteDb>().GetConnection();
            _ = getallcaetitem();
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

                    await _BillingDetailService.GetDetailAsync(response1.UserId);

                }
                else
                {
                    
                }
            }
            catch (Exception ex)
            {
                // Possible that device doesn't support secure storage on device.
            }

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
                myCollection = await _connection.Table<clsInvoice>().ToListAsync();
                foreach (var b in myCollection)
                {
                        List<LineItems> a = new List<LineItems>();
                        a.Add(new LineItems
                        {
                            product_id = b.id,
                            quantity = b.quantity,
                            tax_class = "1",
                            subtotal = "300",
                            subtotal_tax = "2",
                            total = "500",
                            total_tax = "10",
                            price = b.SRate,


                        });
                        order.line_items = new List<LineItems>(a);

                    }

                   
                    //if (codcheckbox && card_Name != null && card_Number != null && cVV != null)
                    //{

                    //}
                    //else if (codcheckbox)
                    //{
                    //    order.payment_method = "cod";
                    //    order.payment_method = "Cash on delivery";
                    //    order.set_paid = false;
                    //}
                    //else
                    //{

                    //}

                    order.payment_method = id;
                    order.payment_method_title = title;

                    // await _placeorderapi.OrderAsync();

                    

                    order.billing = await _connection.Table<Billing>().FirstAsync();
                    order.shipping = await _connection.Table<Shipping>().FirstAsync();
                    //order.line_items = await _connection.Table<LineItems>().ToListAsync();
                    
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

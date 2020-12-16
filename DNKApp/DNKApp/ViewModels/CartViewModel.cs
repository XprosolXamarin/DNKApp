using DNKApp.Models;
using DNKApp.Services;
using DNKApp.Views;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace DNKApp.ViewModels
{
    public class CartViewModel:BaseViewModel
    {
        private readonly PlaceOrderApi _placeorderapi;
        public OrderDetailModel orderDetail { get; set; }
        #region
        private int _TBill;
        public int TBill
        {
            get { return _TBill; }
            set
            {
                _TBill = value;

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
        private INavigation navigation;
       
        private SQLiteAsyncConnection _connection;
        public List<clsInvoice> _myCollection;
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

        public  CartViewModel(INavigation navigation)
        {
            this.navigation = navigation;
            _connection = Xamarin.Forms.DependencyService.Get<ISQLiteDb>().GetConnection();
            _connection.CreateTableAsync<Billing>();
            _connection.Table<Billing>().FirstAsync();
            _connection.CreateTableAsync<Shipping>();
            _connection.Table<Shipping>().FirstAsync();
            _ = getallcaetitem();
            
        }

        private async Task getallcaetitem()
        {
            try
            {
                myCollection = await _connection.Table<clsInvoice>().ToListAsync();
                invoice = new ObservableCollection<clsInvoice>(myCollection);
                
                TBill = invoice.Sum(s => s.SRate);
               
            }
            catch(Exception ex)
            {

            }

            //Items.Add(new clsInvoice { 
            //ProductName=invoice[0].ProductName,
            //Price=invoice[0].Price,
            //Qty=invoice[0].Qty,
            //});
           // Items = new ObservableCollection<clsInvoice>((IEnumerable<clsInvoice>)invoice);

           
           
        }

       
        public Xamarin.Forms.Command PlaceOrder
        {
            get
            {
                return new Xamarin.Forms.Command(async() =>
                {

                    OrderDetailModel order = new OrderDetailModel();
                    
                   
                    order.payment_method_title = "Cash on delivery";
                    order.billing = await _connection.Table<Billing>().FirstAsync();
                    order.shipping= await _connection.Table<Shipping>().FirstAsync();
                    order.line_items = await _connection.Table<LineItems>().ToListAsync();
                    
                    clsInvoice list = new clsInvoice();
                    
                var Httpclient = new HttpClient();

                var url = "https://qepdns.com/wp-json/wc/v3/orders?consumer_key=ck_c822f95423287f7ccd15df53b7e56d3de3d5468d&consumer_secret=cs_e1f61450a3c4a7430ce1f493b116912ed60929b5";

                var uri = new Uri(string.Format(url, string.Empty));

                var json = JsonConvert.SerializeObject(order);

                var content = new StringContent(json, Encoding.UTF8, "application/x-www-form-urlencoded");

                HttpResponseMessage response = null;

                response = await Httpclient.PostAsync(uri, content);


                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        var responseContent = await response.Content.ReadAsStringAsync();

                        var jObject = JObject.Parse(responseContent);

                    }
                   

                    //response1 = new clsResponse
                    //{
                    //    Status = (bool)jObject.GetValue("Status"),

                    //    Message = jObject.GetValue("Message").ToString(),
                    //    OrderNumber = jObject.GetValue("orderNumber").ToString(),

                    //};
                    //await _placeorderapi.PlaceOrder(order);


                    //  await _connection.DropTableAsync<clsInvoice>();
                    //await navigation.PushAsync(new OrderAcceptedPage());
                    // Application.Current.MainPage = new NavigationPage(new OrderAcceptedPage());
                });
            }
        }
       
        
        public Command<clsInvoice> IncreaseQtyCommand
        {

            get
            {

                return new Command<clsInvoice>(async(clsInvoice p) =>
                {
                    p.quantity++;
                    p.SRate = p.FRate * p.quantity;
                    TBill = invoice.Sum(s => s.SRate);
                    var invoiceU = new clsInvoice { id = p.id, name = p.name, SRate = p.SRate, FRate = p.FRate, quantity = p.quantity, imagepath = p.imagepath };
                    var abc = await _connection.UpdateAsync(invoiceU);
                    // var a = invoice[p.ID];
                    // await _connection.UpdateAsync(a);

                    //int m = Convert.ToInt32(p.Price);
                    // total.TBill = invoice.Sum(s => s.Price);
                });
            }
        }

        public Xamarin.Forms.Command<clsInvoice> DecreaseQtyCommand
        {
            get
            {
                return new Xamarin.Forms.Command<clsInvoice>(async(clsInvoice p) =>
                {
                    p.quantity -= 1;
                    if (p.quantity == 1)
                    {
                        p.SRate = p.FRate;
                        TBill = invoice.Sum(s => s.SRate);
                    }
                    else
                    {
                        TBill = TBill - p.FRate;

                        
                        p.SRate = p.SRate - p.FRate;
                        TBill = invoice.Sum(s => s.SRate);
                    }
                    //var abc= _connection.Table<clsInvoice>().Where(x => x.ID == p.ID ).ToListAsync();


                    var invoiceU = new clsInvoice {id = p.id, name = p.name, SRate = p.SRate, FRate = p.FRate, quantity = p.quantity, imagepath = p.imagepath };
                    var abc = await _connection.UpdateAsync(invoiceU);


                    // p.Qty--;
                    // TBill = invoice.Sum(s => s.SRate);
                    // await _connection.UpdateAsync(p);
                });
            }
        }

        public Command<clsInvoice> RemoveItem
        {
            get
            {
                return new Command<clsInvoice>(async(clsInvoice p) =>
                {

                     //int b = --p.productId;
                    
                    await _connection.DeleteAsync(p);
                    invoice.Remove(p);
                    //Items.Remove(product);
                    TBill = TBill - p.SRate;
                    //Total.TCount--;

                });
            }
        }

        public Command<string> CheckoutCommand
        {
            get
            {
                return new Command<string>(async(string pageNo) =>
                {
                    if (pageNo.Equals("pop"))
                    {
                       await navigation.PopAsync();
                    }
                    else if (pageNo.Equals("pushbillingdetail"))
                    {
                        
                       await navigation.PushAsync(new BillingdetailsPage());
                    }
                    else if (pageNo.Equals("pushPayment"))
                    {
                        var billing = new Billing { first_name = first_name, last_name = last_name, company = company, address_1 = address_1, address_2 = address_2, city = city, state = state, postcode = postcode, country = country, email = email, phone = phone };

                         await _connection.InsertAsync(billing);
                        var shipping = new Shipping { first_name = first_name, last_name = last_name, company = company, address_1 = address_1, address_2 = address_2, city = city, state = state, postcode = postcode, country = country };

                        await _connection.InsertAsync(shipping);
                        await navigation.PushAsync(new PaymentPage());
                    }
                    else if (pageNo.Equals("pushSummary"))
                    {
                        await navigation.PushAsync(new SummaryPage());
                    }
                    else if (pageNo.Equals("pushOrderAccepted"))
                    {
                       await navigation.PushAsync(new OrderAcceptedPage());
                    }
                });
            }
        }
    }
}

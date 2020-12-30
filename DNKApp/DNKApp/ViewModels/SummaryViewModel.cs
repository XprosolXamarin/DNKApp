using DNKApp.Models;
using DNKApp.Services;
using DNKApp.Utlities;
using DNKApp.Views;
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
        private readonly PlaceOrderApi placeOrderApi;
        private SQLiteAsyncConnection _connection;
        private INavigation navigation;
        public List<clsInvoice> _myCollection;
        private string id;
        private string title;
        public GetDetailById getDetailById { get; set; }
        public OrderDetailModel order { get; set; }
        private PaymentGetway methods;
        public List<LineItems> Itemlst { get; set; }

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
       
       
        public SummaryViewModel(INavigation navigation ,PaymentGetway _paymentGetway)
        {
            this.methods = _paymentGetway;
            Itemlst = new List<LineItems>();
            _BillingDetailService = new GetBillingDetailbyId();
            placeOrderApi=new PlaceOrderApi();
            getDetailById = new GetDetailById();
            _loginService = new LoginService();
            order = new OrderDetailModel();
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
                    myCollection = await _connection.Table<clsInvoice>().ToListAsync();
                    foreach (var b in myCollection)
                    {
                        
                        Itemlst.Add(new LineItems
                        {
                            product_id = b.id,
                            quantity = b.quantity,
                            tax_class = "0",
                            subtotal = b.price,
                            subtotal_tax = "0.00",
                            total = b.price,
                            total_tax = "0.00",
                            price = b.SRate,


                        });
                        

                    }


                    try
                    {
                        var username = Utilty.GetSecureStorageValueFor(Utilty.UserName);
                        var password = Utilty.GetSecureStorageValueFor(Utilty.Password);
                        var response1 = await _loginService.UserLoginAsync(username.Result, password.Result);
                        if (response1.Status)
                        {

                            getDetailById = await _BillingDetailService.GetDetailAsync(response1.UserId);
                            order.payment_method = methods.id;
                            order.payment_method_title = methods.title;
                            order.customer_id = Convert.ToInt32(response1.UserId);
                            order.billing = getDetailById.billing;
                            order.shipping = getDetailById.shipping;
                            
                            order.line_items = new List<LineItems>(Itemlst);
                            
                           string orderid= await placeOrderApi.PlaceOrderAsync(order);
                          await navigation.PushModalAsync(new OrderAcceptedPage(orderid));
                        }
                        else
                        {
                            order.payment_method = methods.id;
                            order.payment_method_title = methods.title;
                            order.customer_id = 0;
                            order.billing= await _connection.Table<Billing>().FirstAsync();
                            order.shipping = new Shipping
                            {
                                first_name = order.billing.first_name,
                                last_name = order.billing.last_name,
                                company = order.billing.company,
                                address_1 = order.billing.address_1,
                                address_2 = order.billing.address_2,
                                city = order.billing.city,
                                state = order.billing.state,
                                postcode = order.billing.postcode,
                                country = order.billing.country
                            };
                            order.line_items = new List<LineItems>(Itemlst);
                            string orderid = await placeOrderApi.PlaceOrderAsync(order);
                            await navigation.PushModalAsync(new OrderAcceptedPage(orderid));
                        }
                    }
                    catch (Exception ex)
                    {
                        // Possible that device doesn't support secure storage on device.
                    }
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

using DNKApp.Helpers;
using DNKApp.Models;
using DNKApp.Services;
using DNKApp.Utlities;
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
       
        private INavigation navigation;
        private readonly LoginService _loginService;
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
           
            _ = getallcaetitem();
            _loginService = new LoginService();



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

        public Command NavigateBillingDetail
        {

            get
            {

                return new Command(async () =>
                {
                    try
                    {
                        var username = Utilty.GetSecureStorageValueFor(Utilty.UserName);
                        var password = Utilty.GetSecureStorageValueFor(Utilty.Password);
                        var response1 = await _loginService.UserLoginAsync(username.Result, password.Result);
                        if (response1.Status)
                        {
                          await  navigation.PushAsync(new PaymentPage());
                        }
                        else
                        {
                          await  navigation.PushAsync(new BillingdetailsPage());
                        }
                    }
                    catch (Exception ex)
                    {
                        // Possible that device doesn't support secure storage on device.
                    }

                   // await navigation.PushAsync(new BillingdetailsPage());
                });
            }
        }
    }
}

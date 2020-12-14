using DNKApp.Models;
using DNKApp.Services;
using DNKApp.Views;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DNKApp.ViewModels
{
    public class CartViewModel:BaseViewModel
    {
        private int _SRate;
        public int SRate
        {
            get { return _SRate; }
            set
            {
                _SRate = value;

                OnPropertyChanged();
            }
        }
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

        public Command CartView
        {
            get
            {
                return new Command(() =>
                {
                    navigation.PushAsync(new CartViewPage());
                });
            }
        }
        public Xamarin.Forms.Command PlaceOrder
        {
            get
            {
                return new Xamarin.Forms.Command(async() =>
                {
                    //  await _connection.DropTableAsync<clsInvoice>();
                    await navigation.PushAsync(new OrderAcceptedPage());
                  // Application.Current.MainPage = new NavigationPage(new OrderAcceptedPage());
                });
            }
        }
        public Command PaymentCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await navigation.PushAsync(new PaymentPage());
                });
            }
        }
        public Command SummaryCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await navigation.PushAsync(new SummaryPage());
                });
            }
        }
        public Command BillingDetailCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await navigation.PushAsync(new BillingdetailsPage());
                });
            }
        }
        
        public Command<clsInvoice> IncreaseQtyCommand
        {

            get
            {

                return new Command<clsInvoice>(async(clsInvoice p) =>
                {
                    p.Qty++;
                    p.SRate = p.FRate * p.Qty;
                    TBill = invoice.Sum(s => s.SRate);
                    var invoiceU = new clsInvoice { id = p.id, ProductName = p.ProductName, SRate = p.SRate, FRate = p.FRate, Qty = p.Qty, imagepath = p.imagepath };
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
                    p.Qty -= 1;
                    if (p.Qty == 1)
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


                    var invoiceU = new clsInvoice {id = p.id, ProductName = p.ProductName, SRate = p.SRate, FRate = p.FRate, Qty = p.Qty, imagepath = p.imagepath };
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
    }
}

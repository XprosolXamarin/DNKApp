using DNKApp.Models;
using DNKApp.Services;
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
        public List<clsInvoice> _invoice { get; set; }
        public List<clsInvoice> invoice
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
                invoice = await _connection.Table<clsInvoice>().ToListAsync();
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
                return new Xamarin.Forms.Command(() =>
                {
                    

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
                    var a = invoice[p.ID];
                    await _connection.UpdateAsync(a);
                    
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
                    p.Qty--;
                    TBill = invoice.Sum(s => s.SRate);
                   await _connection.UpdateAsync(p);
                });
            }
        }
        public Command<clsInvoice> RemoveItem
        {
            get
            {
                return new Command<clsInvoice>(async(clsInvoice p) =>
                {
                    //invoice.Remove(p);
                    int b = p.ID--;
                    var a = invoice[b];
                   await _connection.DeleteAsync(a);
                    //Items.Remove(product);
                    //Total.TBill = Total.TBill - product.SRate;
                    //Total.TCount--;
                });
            }
        }
    }
}

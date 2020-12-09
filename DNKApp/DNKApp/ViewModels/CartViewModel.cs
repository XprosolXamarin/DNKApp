using DNKApp.Models;
using DNKApp.Services;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DNKApp.ViewModels
{
    public class CartViewModel:BaseViewModel
    {
        private INavigation navigation;
        public ObservableCollection<clsTest> _Items { get; set; } 
        public ObservableCollection<clsTest> Items
        {
            get
            {
                return _Items;
            }
            set
            {
                _Items = value;
                OnPropertyChanged();


            }
        }
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
    }
}

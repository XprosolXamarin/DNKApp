using DNKApp.Models;
using DNKApp.Services;
using DNKApp.Views;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;


namespace DNKApp.ViewModels
{
   public class PreviewPageViewModel:BaseViewModel
    {
        private string _name;
        public string name
        {
            get { return _name; }
            set
            {
                _name = value;

                OnPropertyChanged();
            }
        }
      

        private ImageSource _imageSource;
        public ImageSource imageSource
        {
            get { return _imageSource; }
            set
            {
                _imageSource = value;
                OnPropertyChanged();
            }
        }
        
        private int _price;
        public int price
        {
            get { return _price; }
            set
            {
                _price = value;

                OnPropertyChanged();
            }
        }
        
        private string _longDescription;
        public string longDescription
        {
            get { return _longDescription; }
            set
            {
                _longDescription = value;

                OnPropertyChanged();
            }
        }
        public CategoryName categoryName;
        
        private string _description;
        public string description
        {
            get { return _description; }
            set
            {
                _description = value;

                OnPropertyChanged();
            }
        }
        private int _Qty;
        public int Qty
        {
            get { return _Qty; }
            set
            {
                if (value > 1)
                    _Qty = value;
                else
                    _Qty = 1;
                OnPropertyChanged();
            }
        }
        private string _img;
        public string img
        {
            get { return _img; }
            set
            {
                _img = value;

                OnPropertyChanged();
            }
        }
        private string _Category;
        public string Category
        {
            get { return _Category; }
            set
            {
                _Category = value;

                OnPropertyChanged();
            }
        }
        private int _id;
        public int id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
                OnPropertyChanged();
            }
        }
        private List<clsInvoice> _Cartlst;
        public List<clsInvoice> Cartlst
        {
            get
            {
                return _Cartlst;
            }
            set
            {
                _Cartlst = value;
                OnPropertyChanged();
            }
        }
        
        private SQLiteAsyncConnection _connection;
        public PreviewPageViewModel(int id, string name, ImageSource imageSource, int price, string longDescription, CategoryName categoryName, string description)
        {
            this.id = id;
            this.name = name;
            this.imageSource = imageSource;
            this.price = price;
            this.longDescription = longDescription;
            this.categoryName = categoryName;
            this.description = description;
            img = imageSource.src;
            Category = categoryName.name;
            Qty = 0;
            _connection = Xamarin.Forms.DependencyService.Get<ISQLiteDb>().GetConnection();
            _connection.CreateTableAsync<clsInvoice>();
            _connection.Table<clsInvoice>().ToListAsync();
            
        }
       
        public Xamarin.Forms.Command IncreaseQtyCommand
        {

            get
            {

                return new Xamarin.Forms.Command(() =>
                {
                    Qty++;
                });
            }
        }
        public Xamarin.Forms.Command DecreaseQtyCommand
        {
            get
            {
                return new Xamarin.Forms.Command(() =>
                {
                    Qty--;
                });
            }
        }
       
        public Xamarin.Forms.Command<clsInvoice> AddtoCart
        {
            get
            {
                return new Xamarin.Forms.Command<clsInvoice>(async (clsInvoice _clsInvoice) =>
                {

                    //if (!await _connection.Table<clsInvoice>("select * from clsInvoice").FirstOrDefaultAsync();
                    //{
                    //    var invoice = new clsInvoice { id = id, ProductName = name, SRate = price, FRate = price, Qty = ++Qty, imagepath = img };
                    //    var abc = await _connection.UpdateAsync(invoice);
                    //}
                    //else
                    //{
                        var invoice = new clsInvoice { id = id, ProductName = name, SRate = price, FRate = price, Qty = Qty, imagepath = img, DateTime= System.DateTime.Now };
                  //await  Xamarin.Forms.Application.Current.MainPage.DisplayAlert("", invoice.DateTime, "ok");
                        var abc = await _connection.InsertAsync(invoice);
                    //}

                    //Xamarin.Forms.DependencyService.Get<ISQLite>().GetConnectionWithCreateDatabase();
                    
                   

                    //bool res = Xamarin.Forms.DependencyService.Get<ISQLite>().SaveEmployee(employee);
                    //if (res)
                    //{
                    //  Xamarin.Forms.Application.Current.MainPage.Navigation.PopAsync();
                    //}
                    //else
                    //{
                    //    Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Message", "Data Failed To Save", "Ok");
                    //}





                    //Cartlst = new List<clsInvoice>();
                    //Cartlst.Add(new clsInvoice
                    //{
                    //    ProductName = name,
                    //    Qty = Qty,
                    //    Price=price,
                    //});
                   await Xamarin.Forms.Application.Current.MainPage.Navigation.PopAsync();
                });
            }
        }
    }
}

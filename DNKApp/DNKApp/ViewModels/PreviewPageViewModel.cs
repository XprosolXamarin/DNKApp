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
        public PreviewPageViewModel(string name, ImageSource imageSource, int price, string longDescription, CategoryName categoryName, string description)
        {
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
       
        public Xamarin.Forms.Command AddtoCart
        {
            get
            {
                return new Xamarin.Forms.Command(async () =>
                {

                    //Xamarin.Forms.DependencyService.Get<ISQLite>().GetConnectionWithCreateDatabase();
                    var invoice = new clsInvoice { ProductName = name, SRate = price, Qty=Qty,imagepath=img };
                    var abc=await _connection.InsertAsync(invoice);
                   

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
                    Xamarin.Forms.Application.Current.MainPage.Navigation.PopAsync();
                });
            }
        }
    }
}

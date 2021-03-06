﻿using DNKApp.Models;
using DNKApp.Services;
using DNKApp.Utlities;
using DNKApp.Views;
using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace DNKApp.ViewModels
{
    public class ShopPageViewModel:BaseViewModel
    {
        private bool _Isbusy;
        public bool Isbusy
        {
            get
            {
                return _Isbusy;
            }
            set
            {
                _Isbusy = value;
                if (_Isbusy)
                {
                    navigation.PushPopupAsync(new IndicatorActity());

                }
                else
                {
                    navigation.PopPopupAsync();

                }

                OnPropertyChanged();
            }
        }
        private string _UserName;

        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Category> _MyCollections { get; set; }
        public ObservableCollection<Category> MyCollections
        {
            get { return _MyCollections; }
            set
            {
                _MyCollections = value;

                OnPropertyChanged();
            }
        }
        public ObservableCollection<Product> _CollectionsList { get; set; }
        public ObservableCollection<Product> CollectionsList
        {
            get { return _CollectionsList; }
            set
            {
                _CollectionsList = value;

                OnPropertyChanged();
            }
        }
        private INavigation navigation;
        private readonly ItemsListApi _itemlistapi;
        private readonly CategoriesService _categoriesService;
        public List<Banner> Banners { get => GetBanners(); }
        //public ObservableCollection<Product> CollectionsList { get; set; }
        //public List<Product> CollectionsList { get => GetCollections(); }
        public List<Product> TrendsList { get => GetTrends(); }
        public ShopPageViewModel(INavigation navigation)
        {
           
            this.navigation = navigation;
            _itemlistapi = new ItemsListApi();
            _categoriesService = new CategoriesService();
            Isbusy = true;
            
            _ = GetListOfItemsAsync();
            _ = GetCategoriesAsync();

        }
         private async Task GetCategoriesAsync()
        {
            MyCollections = new ObservableCollection<Category>();
            var current = Connectivity.NetworkAccess;

            if (current == NetworkAccess.Internet)
            {
                MyCollections = await _categoriesService.GetListofCategories();
                Isbusy = false;

            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("", "Please Connect with Internet.", "ok");
                Isbusy = false;
            }
        }
        private async Task GetListOfItemsAsync()
        {
            UserName =await Utilty.GetSecureStorageValueFor(Utilty.display_name);
            //Isbusy = true;

            CollectionsList = new ObservableCollection<Product>();
            var current = Connectivity.NetworkAccess;

            if (current == NetworkAccess.Internet)
            {
                CollectionsList = await _itemlistapi.GetListofItems();
                 
                
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("", "Please Connect with Internet.", "ok");
                Isbusy = false;
            }

        }
       
        private List<Banner> GetBanners()
        {
            var bannerList = new List<Banner>();
            bannerList.Add(new Banner { Heading = "SUMMER COLLECTION", Message = "40% Discount", Caption = "BEST DISCOUNT THIS SEASON", Image = "classic.png" });
            bannerList.Add(new Banner { Heading = "WOMEN'S CLOTHINGS", Message = "UP TO 50% OFF", Caption = "GET 50% OFF ON EVERY ITEM", Image = "womenCol.png" });
            bannerList.Add(new Banner { Heading = "ELEGANT COLLECTION", Message = "20% Discount", Caption = "UNIQUE COMBINATIONS OF ITEMS", Image = "elegantCol.png" });
            return bannerList;
        }

        //private void GetCollections()
        //{
        //    var ite = (from c in CollectionsList

        //               select new Product
        //               {
        //                   id = c.id,
        //                   Image = c.images[0].src,
        //                   Price=c.Price,
        //                   name=c.name,
        //               }).FirstOrDefault();
            
        //    CollectionsList.Add(ite);
            
        //    //var trendList = new List<Product>();
        //    //trendList.Add(new Product { Image = "floral.png", ProductName = "Floral Bag + Hat", Price = "$123.50" });
        //    //trendList.Add(new Product { Image = "satchel.png", ProductName = "Satchel Bag", Price = "$49.99" });
        //    //trendList.Add(new Product { Image = "leatherBag.png", ProductName = "Leather Bag", Price = "$40.99" });
        //    //return trendList;
        //}

        private List<Product> GetTrends()
        {
            var colList = new List<Product>();
            colList.Add(new Product { Image = "heeledShoe.png", ProductName = "Beige Heeled Shoe", Price = "$109.99" });
            colList.Add(new Product { Image = "dressShoe.png", ProductName = "Shoe + Addons", Price = "$225.99" });
            return colList;
        }
        public Command<Product> Preview
        {
            get
            {
                return  new Command<Product>((Product product) =>
                {
                    navigation.PushAsync(new PreviewPage(product.id,product.name, product.images[0], product.FPrice, product.LongDescription, product.categories[0], product.description));
                });
            }
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
        public Command Mens
        {
            get
            {
                return new Command(() =>
                {
                    navigation.PushAsync(new CartViewPage());
                });
            }
        }
        public Command Womens
        {
            get
            {
                return new Command(() =>
                {
                    int a = 41;
                    _ =GetCatgory(a);
                });
            }
        }

        private object GetCatgory(int a)
        {
            var ite = (from c in CollectionsList
                       where c.categories[0].id == a
                       select new clsInvoice
                       {

                       });
            return 0;
        }

        public Command Childern
        {
            get
            {
                return new Command(() =>
                {
                    navigation.PushAsync(new CartViewPage());
                });
            }
        }


    }
}

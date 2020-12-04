using DNKApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Timers;
using Xamarin.Forms;

namespace DNKApp.ViewModels
{
    public class ShopPageViewModel
    {
        private INavigation navigation;
        
        public List<Banner> Banners { get => GetBanners(); }
        public List<Product> CollectionsList { get => GetCollections(); }
        public List<Product> TrendsList { get => GetTrends(); }
        public ShopPageViewModel(INavigation navigation)
        {
            this.navigation = navigation;
        }
        private List<Banner> GetBanners()
        {
            var bannerList = new List<Banner>();
            bannerList.Add(new Banner { Heading = "SUMMER COLLECTION", Message = "40% Discount", Caption = "BEST DISCOUNT THIS SEASON", Image = "classic.png" });
            bannerList.Add(new Banner { Heading = "WOMEN'S CLOTHINGS", Message = "UP TO 50% OFF", Caption = "GET 50% OFF ON EVERY ITEM", Image = "womenCol.png" });
            bannerList.Add(new Banner { Heading = "ELEGANT COLLECTION", Message = "20% Discount", Caption = "UNIQUE COMBINATIONS OF ITEMS", Image = "elegantCol.png" });
            return bannerList;
        }

        private List<Product> GetCollections()
        {
            var trendList = new List<Product>();
            trendList.Add(new Product { Image = "floral.png", ProductName = "Floral Bag + Hat", Price = "$123.50" });
            trendList.Add(new Product { Image = "satchel.png", ProductName = "Satchel Bag", Price = "$49.99" });
            trendList.Add(new Product { Image = "leatherBag.png", ProductName = "Leather Bag", Price = "$40.99" });
            return trendList;
        }

        private List<Product> GetTrends()
        {
            var colList = new List<Product>();
            colList.Add(new Product { Image = "heeledShoe.png", ProductName = "Beige Heeled Shoe", Price = "$109.99" });
            colList.Add(new Product { Image = "dressShoe.png", ProductName = "Shoe + Addons", Price = "$225.99" });
            return colList;
        }
       
    }
}

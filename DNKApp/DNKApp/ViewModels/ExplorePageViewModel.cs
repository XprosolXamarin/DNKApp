using DNKApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace DNKApp.ViewModels
{
    public class ExplorePageViewModel
    {
        private INavigation navigation;
        public List<Category> AllCategories { get => GetCategories(); }
        public ExplorePageViewModel(INavigation navigation)
        {
            this.navigation = navigation;
        }
        private List<Category> GetCategories()
        {
            var catList = new List<Category>();
            catList.Add(new Category { Image = "summerCol.png", Title = "SUMMER COLLECTION", Caption = "BEST DISCOUNT THIS SEASON" });
            catList.Add(new Category { Image = "womenCol.png", Title = "WOMEN'S CLOTHINGS", Caption = "UP TO 50% OFF ON EVERY ITEM" });
            catList.Add(new Category { Image = "elegantCol.png", Title = "ELEGANT CLOTHINGS", Caption = "UNQUE COLLECTIONS AND STYLES" });
            return catList;
        }
    }
}

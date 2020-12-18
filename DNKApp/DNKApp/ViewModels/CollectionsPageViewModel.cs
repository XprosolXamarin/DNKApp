using DNKApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace DNKApp.ViewModels
{
    public class CollectionsPageViewModel
    {
        private INavigation navigation;
       // public List<Category> MyCollections { get => GetCollections(); }
        public CollectionsPageViewModel(INavigation navigation)
        {
            this.navigation = navigation;
        }
        //private List<Category> GetCollections()
        //{
        //    var colList = new List<Category>();
        //    colList.Add(new Category { Image = "watches.png", Title = "MEN'S WRISTWATCHES" });
        //    colList.Add(new Category { Image = "minidress.png", Title = "WOMEN'S MINI DRESSES" });
        //    colList.Add(new Category { Image = "coats.png", Title = "WOMEN'S COATS" });
        //    return colList;
        //}
    }
}

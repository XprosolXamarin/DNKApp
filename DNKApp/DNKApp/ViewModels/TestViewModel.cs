using DNKApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace DNKApp.ViewModels
{
   public class TestViewModel:BaseViewModel
    {
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
        public TestViewModel()
        {
        }
    }
}

using DNKApp.Models;
using DNKApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNKApp.ViewModels
{
    public class CategoryViewModel : BaseViewModel
    {
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
        private Category _SelectedCategory;

        public Category SelectedCategory
        {
            get
            {
                return _SelectedCategory;
            }
            set
            {
                _SelectedCategory = value;
                OnPropertyChanged();
            }
        }
        private readonly ItemsListApi _itemlistapi;
        public ObservableCollection<Product> ProductsByCategory { get; set; }
        private int _TotalProduuctItems;

        public int TotalProduuctItems
        {
            get
            {
                return _TotalProduuctItems;
            }
            set
            {
                _TotalProduuctItems = value;
                OnPropertyChanged();
            }
        }
        public CategoryViewModel(Category category)
        {
            SelectedCategory = category;
            ProductsByCategory = new ObservableCollection<Product>();
            _itemlistapi = new ItemsListApi();
            GetFoodItems(category.id);

        }
       
        private async void GetFoodItems(int categoryID)
        {
            CollectionsList = await _itemlistapi.GetListofItems();
            var ProductItemsByCategory = new ObservableCollection<Product>();
            var items = CollectionsList.Where(p => p.categories[0].id == categoryID).ToList();
            foreach (var item in items)
            {
                ProductItemsByCategory.Add(item);
            }

           
            ProductsByCategory.Clear();
            foreach (var item in ProductItemsByCategory)
            {
                ProductsByCategory.Add(item);
            }
            TotalProduuctItems = ProductsByCategory.Count;
        }
    }
}

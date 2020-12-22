using DNKApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace DNKApp.ViewModels
{
   public class GetwayViewModel:BaseViewModel
    {
        private ObservableCollection<PaymentGetway> _Mthds { get; set; }
        public ObservableCollection<PaymentGetway> Mthds
        {
            get { return _Mthds; }
            set
            {
                _Mthds = value;

                OnPropertyChanged();
            }
        }
        private List<PaymentGetway> _lst;
        private SQLiteAsyncConnection _connection;

        public List<PaymentGetway> lst
        {
            get
            {
                return _lst;
            }
            set
            {
                _lst = value;
                OnPropertyChanged();


            }
        }
        public GetwayViewModel()
        {
            _connection = Xamarin.Forms.DependencyService.Get<ISQLiteDb>().GetConnection();
            _ = getallcaetitem();
        }

        private async Task getallcaetitem()
        {
            try
            {
                lst = await _connection.Table<PaymentGetway>().ToListAsync();
              await  _connection.DropTableAsync<PaymentGetway>();
                Mthds = new ObservableCollection<PaymentGetway>(lst);



            }
            catch (Exception ex)
            {

            }
        }
    }
}

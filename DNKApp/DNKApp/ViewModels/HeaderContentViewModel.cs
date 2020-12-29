using DNKApp.Utlities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DNKApp.ViewModels
{
   public class HeaderContentViewModel:BaseViewModel
    {
        private string _Username;

        public string Username
        {
            get { return _Username; }
            set { _Username = value;
                OnPropertyChanged();
            }
        }
        private string _UserEmail;

        public string UserEmail
        {
            get { return _UserEmail; }
            set
            {
                _UserEmail = value;
                OnPropertyChanged();
            }
        }
        

        public HeaderContentViewModel()
        {
            _ = getDatail();
        }

        private async Task getDatail()
        {
            Username=await Utilty.GetSecureStorageValueFor(Utilty.display_name);
            UserEmail= await Utilty.GetSecureStorageValueFor(Utilty.UserEmail);
        }
    }
}

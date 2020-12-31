using DNKApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DNKApp.Models
{
   public class clsUpdateAccountDetail:BaseViewModel
    {
        private string _first_name;

        public string first_name
        {
            get 
            {
                return _first_name; 
            }
            set
            {
                _first_name = value;
                OnPropertyChanged();
            }
        }

        private string _last_name;

        public string last_name
        {
            get
            {
                return _last_name;
            }
            set
            {
                _last_name = value;
                OnPropertyChanged();
            }
        }

        private string _username;

        public string username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
                OnPropertyChanged();
            }
        }

        private string _email;

        public string email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }
        
    }
}

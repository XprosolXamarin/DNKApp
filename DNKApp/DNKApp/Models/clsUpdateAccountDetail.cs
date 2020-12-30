using DNKApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DNKApp.Models
{
   public class clsUpdateAccountDetail:BaseViewModel
    {
        private string _FName;

        public string FName
        {
            get 
            {
                return _FName; 
            }
            set
            {
                _FName = value;
                OnPropertyChanged();
            }
        }

        private string _LName;

        public string LName
        {
            get
            {
                return _LName;
            }
            set
            {
                _LName = value;
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
        private string _Email;

        public string Email
        {
            get
            {
                return _Email;
            }
            set
            {
                _Email = value;
                OnPropertyChanged();
            }
        }
        
    }
}

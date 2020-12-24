using DNKApp.Models;
using DNKApp.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace DNKApp.ViewModels
{
    public class SignupViewModel:BaseViewModel
    {
        #region
        private String  _FName;

        public String Fname
        {
            get
            { 
                return  _FName;
            }
            set 
            { 
                _FName = value;
                OnPropertyChanged();
            }
        }
        private String _LName;

        public String LName
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
        private String _UserName;

        public String UserName
        {
            get
            {
                return _UserName;
            }
            set
            {
                _UserName = value;
                OnPropertyChanged();
            }
        }
        private String _Email;

        public String Email
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
        private String _Address;

        public String Address
        {
            get
            {
                return _Address;
            }
            set
            {
                _Address = value;
                OnPropertyChanged();
            }
        }
        private String _Sate;

        public String Sate
        {
            get
            {
                return _Sate;
            }
            set
            {
                _Sate = value;
                OnPropertyChanged();
            }
        }
        private String _PostCode;

        public String PostCode
        {
            get
            {
                return _PostCode;
            }
            set
            {
                _PostCode = value;
                OnPropertyChanged();
            }
        }
        private String _PhoneNo;

        public String PhoneNo
        {
            get
            {
                return _PhoneNo;
            }
            set
            {
                _PhoneNo = value;
                OnPropertyChanged();
            }
        }
        private String _Password;

        public String Password
        {
            get
            {
                return _Password;
            }
            set
            {
                _Password = value;
                OnPropertyChanged();
            }
        }
        private String _ConfirmPassword;

        public String ConfirmPassword
        {
            get
            {
                return _ConfirmPassword;
            }
            set
            {
                _ConfirmPassword = value;
                OnPropertyChanged();
            }
        }
        #endregion
        private readonly RegisterService _registerService;
        public SignupViewModel()
        {
            _registerService = new RegisterService();
        }
        public ICommand RegisterCommand
        {
            get
            {
                return new Command(async () =>
                {


                    var user = new clsUsers
                    {
                        email = Email,
                        first_name=Fname,
                        last_name=LName,
                        username=UserName,
                        billing=new Billing
                        {
                            first_name = Fname,
                            last_name = LName,
                            address_1=Address,
                            city="Gujrat",
                            state=Sate,
                            postcode=PostCode,
                            country="pakistan",
                            email=Email,
                            phone=PhoneNo

                        },
                        shipping=new Shipping
                        {
                            first_name = Fname,
                            last_name = LName,
                            address_1 = Address,
                            city = "Gujrat",
                            state = Sate,
                            postcode = PostCode,
                            country = "pakistan",
                        }

                    };
                    var current = Connectivity.NetworkAccess;

                    if (current == NetworkAccess.Internet)
                    {
                        await _registerService.RegisterUserAsync(user);
                    }                        
                });
            }
        }
    }
}

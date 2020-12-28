using DNKApp.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace DNKApp.ViewModels
{
    public class LoginViewModel:BaseViewModel
    {
        private string _user_login;

        public string user_login
        {
            get { return _user_login; }
            set { _user_login = value;
                OnPropertyChanged();
            }
        }
        private string _password;

        public string password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }
        private readonly LoginService _loginService;
        public LoginViewModel()
        {
            _loginService = new LoginService();
        }
        public ICommand LoginCommand
        {
            get
            {
                return new Command(async () =>
                {


                    

                    var current = Connectivity.NetworkAccess;

                    if (current == NetworkAccess.Internet)
                    {
                       
                       var response=     await _loginService.UserLoginAsync(user_login, password);
                        
                        if (response.Status)
                        {
                             Application.Current.MainPage = new AppShell();
                        }
                        else
                        {
                            await Application.Current.MainPage.DisplayAlert("", response.Message, "ok");
                        }
                    }
                });
            }
        }

    }
}

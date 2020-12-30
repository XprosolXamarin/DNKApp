using DNKApp.Models;
using DNKApp.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace DNKApp.ViewModels
{
   public class UpdatePasswordVM
    {
        public UpdatePasswordVM()
        {
            account = new clsUpdatePassword();
            accountDetailsService = new AccountDetailsService();
        }
        public clsUpdatePassword account { get; set; }
        public readonly AccountDetailsService accountDetailsService;
       
        public ICommand SavechangesCommand
        {
            get
            {
                return new Command(async () =>
                {
                    if (account.Newpassword == account.ConfirmNewpassword)
                    {
                        await accountDetailsService.AccountDetailsAsync(account);
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("", "Password didn't Matched", "Ok");
                    }

                });
            }
        }
    
    }
}

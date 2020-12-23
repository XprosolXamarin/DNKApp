using DNKApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace DNKApp.ViewModels
{
  public  class StartingViewModel
    {
        private INavigation navigation1;
        public StartingViewModel(INavigation navigation)
        {
            this.navigation1 = navigation;     
        }
        public Command<string> MainNavigation
        {
            get
            {
                return new Command<string>(async(string pageNo) =>
                {
                    if (pageNo.Equals("pop"))
                    {
                       await navigation1.PopAsync();
                    }
                    else if (pageNo.Equals("pushSignin"))
                    {
                        await navigation1.PushAsync(new SigninPage());
                    }
                    else if (pageNo.Equals("pushSignup"))
                    {
                        await navigation1.PushAsync(new SignupPage());
                    }
                    else if (pageNo.Equals("pushAppShell"))
                    {
                       Application.Current.MainPage = new AppShell();
                    }
                   
                });
            }
        }

    }
}

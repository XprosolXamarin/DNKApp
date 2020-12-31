using DNKApp.Models;
using DNKApp.Services;
using DNKApp.Utlities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace DNKApp.ViewModels
{
   public class AccountDetailsVM:BaseViewModel
    {
        private readonly GetBillingDetailbyId _BillingDetailService;
        public GetDetailById getDetailById { get; set; }
        public clsUpdateAccountDetail clsUpdateAccount { get; set; }
        public readonly UpdateADetailsService accountDetailsService;
        public AccountDetailsVM()
        {
            clsUpdateAccount = new clsUpdateAccountDetail();
            accountDetailsService =new UpdateADetailsService();
            _BillingDetailService = new GetBillingDetailbyId();
            getDetailById = new GetDetailById();
            _ = getdata();
        }

        private async Task getdata()
        {
            string id = await Utilty.GetSecureStorageValueFor(Utilty.UserId);
            getDetailById = await _BillingDetailService.GetDetailAsync(id);
            clsUpdateAccount.first_name = getDetailById.first_name;
            clsUpdateAccount.last_name = getDetailById.last_name;
            clsUpdateAccount.username = getDetailById.username;
            clsUpdateAccount.email = getDetailById.email;
        }

        public ICommand SaveAccountchangesCommand
        {
            get
            {
                return new Command(async() =>
                {
                  
                        await accountDetailsService.AccountDetailsAsync(clsUpdateAccount);
                  
                   

                });
            }
        }
    }
}

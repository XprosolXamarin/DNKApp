using DNKApp.Models;
using DNKApp.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace DNKApp.ViewModels
{
   public class AccountdetailsViewModel
    {
        private readonly GetBillingDetailbyId _BillingDetailService;
        public GetDetailById getDetailById { get; set; }
        public clsUpdateAccountDetail clsUpdateAccount { get; set; }
        public readonly UpdateADetailsService accountDetailsService;
        public AccountdetailsViewModel()
        {
            clsUpdateAccount = new clsUpdateAccountDetail();
            accountDetailsService = new UpdateADetailsService();
            _BillingDetailService = new GetBillingDetailbyId();
            getDetailById = new GetDetailById();
           // _ = getdata();
        }
    }
}

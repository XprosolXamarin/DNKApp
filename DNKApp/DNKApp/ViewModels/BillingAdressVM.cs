using DNKApp.Models;
using DNKApp.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace DNKApp.ViewModels
{
    
   public class BillingAdressVM
    {
        public Billing billing { get; set; }
        public readonly UpdateBAddressService updateBilling;
        public BillingAdressVM()
        {
            billing = new Billing();
            updateBilling = new UpdateBAddressService();

        }
        public Command NavigateBillingAdressPage
        {
            get
            {
                return new Command(async() =>
                {
                    await updateBilling.UpdateBillingAddressAsync(billing);

                });
            }
        }
    }
}

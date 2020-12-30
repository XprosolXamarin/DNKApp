using DNKApp.Models;
using DNKApp.Services;
using DNKApp.Utlities;
using DNKApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace DNKApp.ViewModels
{
   public class AddressesViewModel:BaseViewModel
    {
        public Billing billing { get; set; }
        private String _BillingAddress;
        
        public String BillingAddress
        {
            get { return _BillingAddress; }
            set { _BillingAddress = value;
                OnPropertyChanged();
            }
        }
        private String _ShippingAddress;

        public String ShippingAddress
        {
            get { return _ShippingAddress; }
            set
            {
                _ShippingAddress = value;
                OnPropertyChanged();
            }
        }
        public GetDetailById getDetailById { get; set; }
        private readonly GetBillingDetailbyId _BillingDetailService;
        public AddressesViewModel()
        {
            billing = new Billing();
            getDetailById = new GetDetailById();
            _BillingDetailService = new GetBillingDetailbyId();
            AddressDetails();
        }

        private async void AddressDetails()
        {
            string id = await Utilty.GetSecureStorageValueFor(Utilty.UserId);

            getDetailById = await _BillingDetailService.GetDetailAsync(id);
            BillingAddress = getDetailById.billing.address_1+","+ getDetailById.billing.address_2 + "," + getDetailById.billing.city + "," + getDetailById.billing.state + "," + getDetailById.billing.country;
        }
        public Command NavigateBillingAdressPage
        {
            get
            {
                return new Command(() =>
                {
                    Application.Current.MainPage.Navigation.PushAsync(new BillingAdressPage());

                });
            }
        }
    }
}

using DNKApp.Models;
using DNKApp.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace DNKApp.ViewModels
{
    public class ShippingAddressVM
    {
        public readonly UpdateSAddressService updateSAddressService;
        public Shipping shipping { get; set; }

        public ShippingAddressVM(Shipping shippings)
        {
            shipping = new Shipping();
            this.shipping = shippings;
            updateSAddressService = new UpdateSAddressService();
        }
        public Command SaveShippingAddress
        {
            get
            {
                return new Command(async () =>
                {
                    await updateSAddressService.UpdateShippingAddressAsync(shipping);

                });
            }
        }
    }
}

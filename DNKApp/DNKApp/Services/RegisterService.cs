using DNKApp.Models;
using DNKApp.Utlities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DNKApp.Services
{
    class RegisterService
    {
        internal async Task RegisterUserAsync(clsUsers user)
        {
            var Httpclient = new HttpClient();

            var url = Constants.BaseApiAddress + "wp-json/wc/v3/customers" + Constants.Consumer_Key;

            var uri = new Uri(string.Format(url, string.Empty));
            var json = JsonConvert.SerializeObject(user);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = null;

            response = await Httpclient.PostAsync(uri, content);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                await Xamarin.Forms.Application.Current.MainPage.DisplayAlert("", "sucessfully Register", "Ok");

            }
        }
    }
}

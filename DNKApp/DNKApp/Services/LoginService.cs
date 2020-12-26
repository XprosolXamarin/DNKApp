using DNKApp.Utlities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace DNKApp.Services
{
    public class LoginService
    {
        internal async Task UserLoginAsync(string user_login, string password)
        {
            var Httpclient = new HttpClient();
        
            var url1 = "http://qepdns.com/api/login.php?user_login=" + user_login + "&password=" + password;
            var uri1 = new Uri(string.Format(url1, string.Empty));
           
           
            HttpResponseMessage response = null;
            response = await Httpclient.PostAsync(uri1, null);

            if (response.StatusCode == HttpStatusCode.OK)
            {

                
                var responseContent1 = await response.Content.ReadAsStringAsync();
                var jObject1 = JObject.Parse(responseContent1);
                string msg = (string)jObject1.GetValue("msg");
                string id = (string)jObject1.GetValue("user_id");
                if (id != null)
                {
                    await SecureStorage.SetAsync("tokenp", "user_login");
                    await SecureStorage.SetAsync("tokenn", "password");
                    await SecureStorage.SetAsync("tokenid", "id");

                }
                await Xamarin.Forms.Application.Current.MainPage.DisplayAlert("", msg, "Ok");
            }
            
        }
    }
}

using DNKApp.Models;
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
        internal async Task<clsLoginResponse> UserLoginAsync(string user_login, string password)
        {
            clsLoginResponse res = new clsLoginResponse();
            res = new clsLoginResponse()
            {
                Message = "",
                Status = false,
                UserId = ""
            };
            var Httpclient = new HttpClient();
        
            var url1 = "http://qepdns.com/api/login.php?user_login=" + user_login + "&password=" + password;
            var uri1 = new Uri(string.Format(url1, string.Empty));
           
           
            HttpResponseMessage response = null;
            response = await Httpclient.PostAsync(uri1, null);

            if (response.StatusCode == HttpStatusCode.OK)
            {
               
               

               var responseContent1 = await response.Content.ReadAsStringAsync();
                var jObject1 = JObject.Parse(responseContent1);
              bool  status = (bool)jObject1.GetValue("status");
              string  id = (string)jObject1.GetValue("user_id");
                res =new clsLoginResponse()
                {
                  Message = (string)jObject1.GetValue("msg"),
                UserId = (string)jObject1.GetValue("user_id"),
                UserEmail= (string)jObject1.GetValue("email"),
                Status =status,
            };
                string UserEmail = (string)jObject1.GetValue("email");
                string display_name = (string)jObject1.GetValue("display_name");
                if (status)
                {
                    await Utilty.SetSecureStorageValue(Utilty.UserName, user_login);
                    await Utilty.SetSecureStorageValue(Utilty.display_name, display_name);
                    await Utilty.SetSecureStorageValue(Utilty.Password, password);
                    await Utilty.SetSecureStorageValue(Utilty.UserId, id);
                    await Utilty.SetSecureStorageValue(Utilty.UserEmail, UserEmail);
                    
                   
                    

                }
              //  await Xamarin.Forms.Application.Current.MainPage.DisplayAlert("", msg, "Ok");
            }
            return res;
            
        }
    }
}

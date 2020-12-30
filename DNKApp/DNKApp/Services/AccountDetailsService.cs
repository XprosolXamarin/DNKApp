using DNKApp.Models;
using DNKApp.Utlities;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DNKApp.Services
{
    public class AccountDetailsService
    {
        internal async Task AccountDetailsAsync(clsUpdatePassword account)
        {
            string id =await Utilty.GetSecureStorageValueFor(Utilty.UserId);
            int UserId = Convert.ToInt32(id);
            var Httpclient = new HttpClient();

            var url1 = "http://qepdns.com/api/changepassword.php?user_id="+UserId+"&new_password="+account.Newpassword+ "&password=" + account.password;
            var uri1 = new Uri(string.Format(url1, string.Empty));


            HttpResponseMessage response = null;
            response = await Httpclient.GetAsync(uri1);

            if (response.StatusCode == HttpStatusCode.OK)
                
            {



                var responseContent1 = await response.Content.ReadAsStringAsync();
                var jObject1 = JObject.Parse(responseContent1);
                
                string msg = (string)jObject1.GetValue("msg");
                await Application.Current.MainPage.DisplayAlert("",msg, "Ok");
            }
        }
    }
}

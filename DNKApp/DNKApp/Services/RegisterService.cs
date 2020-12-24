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

namespace DNKApp.Services
{
    class RegisterService
    {
        internal async Task RegisterUserAsync(clsUsers user,string paswd)
        {
            var Httpclient = new HttpClient();

            var url = Constants.BaseApiAddress + "wp-json/wc/v3/customers" + Constants.Consumer_Key;

            var uri = new Uri(string.Format(url, string.Empty));
            var json = JsonConvert.SerializeObject(user);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = null;

            response = await Httpclient.PostAsync(uri, content);
           
            if (response.StatusCode == HttpStatusCode.Created)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var jObject = JObject.Parse(responseContent);
                var id = (string)jObject.GetValue("id");
                var url1 = "http://qepdns.com/api/changepasswordfirst.php?user_id="+id+"&new_password="+paswd;
                var uri1 = new Uri(string.Format(url1, string.Empty));
                //var changepswd = new clsChangePassword
                //{
                //    user_id = id,
                //    new_password=paswd
                //};
                //var json1 = JsonConvert.SerializeObject(changepswd);
                //var content1 = new StringContent(json1, Encoding.UTF8, "application/json");
                HttpResponseMessage response1 = null;
                response1 = await Httpclient.PostAsync(uri1,null);
                await Xamarin.Forms.Application.Current.MainPage.DisplayAlert("", "sucessfully Register", "Ok");
                var responseContent1 = await response1.Content.ReadAsStringAsync();
                var jObject1 = JObject.Parse(responseContent1);
                var msg = (string)jObject1.GetValue("msg");
            }
        }
    }
}

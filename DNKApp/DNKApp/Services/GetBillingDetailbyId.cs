using DNKApp.Models;
using DNKApp.Utlities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DNKApp.Services
{
    public  class GetBillingDetailbyId
    {
        internal async Task GetDetailAsync(string userId)
        {
            var Httpclient = new HttpClient();

            var url =Constants.BaseApiAddress+ "/wp-json/wc/v3/customers/" + userId + Constants.Consumer_Key;
            var uri = new Uri(string.Format(url, string.Empty));
            HttpResponseMessage response = null;
            response = await Httpclient.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {

                using (var client = new HttpClient())
                {

                    var result = await client.GetStringAsync(uri);
                    clsUserDataById userDataById = JsonConvert.DeserializeObject<clsUserDataById>(result.ToString());
                   // dynamic resObj = JsonConvert.DeserializeObject<dynamic>(result);
                    
                   
                    
                    
                }
                    //   var responseContent1 = await response.Content.ReadAsStringAsync();
                    //   JArray loi = (JArray)jObject1.GetValue("billing");
                    //var   getresponse = loi.ToObject<List<Billing>>();

                }

        }
    }
}

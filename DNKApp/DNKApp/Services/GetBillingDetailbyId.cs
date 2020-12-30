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
        internal async Task<GetDetailById> GetDetailAsync(string userId)
        {
            GetDetailById getDetailById = new GetDetailById(); 
            var Httpclient = new HttpClient();

            var url =Constants.BaseApiAddress+ "/wp-json/wc/v3/customers/" + userId + Constants.Consumer_Key;
            var uri = new Uri(string.Format(url, string.Empty));
            HttpResponseMessage response = null;
            response = await Httpclient.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {

                //using (var client = new HttpClient())
                //{

                //    var result = await client.GetStringAsync(uri);
                //    //clsUserDataById userDataById = JsonConvert.DeserializeObject<clsUserDataById>(result.ToString());
                     

                //}
                   var responseContent1 = await response.Content.ReadAsStringAsync();
                dynamic resObj = JsonConvert.DeserializeObject<dynamic>(responseContent1);
                string abc = resObj.username;
                string asd= resObj.billing.email;
                //  var a = JsonConvert.DeserializeObject<clsUserDataById>(resObj);
                getDetailById.first_name = resObj.first_name;
                getDetailById.last_name = resObj.last_name;
                getDetailById.username = resObj.username;
                getDetailById.email = resObj.email;
                getDetailById.billing = new Billing
                {
                    first_name = resObj.billing.first_name,
                    last_name = resObj.billing.last_name,
                    company = resObj.billing.company,
                    address_1 = resObj.billing.address_1,
                    address_2 = resObj.billing.address_2,
                    city = resObj.billing.city,
                    postcode = resObj.billing.postcode,
                    country = resObj.billing.country,
                    state = resObj.billing.state,
                    email = resObj.billing.email,
                    phone = resObj.billing.phone,

                };
                getDetailById.shipping = new Shipping
                {
                    first_name = resObj.billing.first_name,
                    last_name = resObj.billing.last_name,
                    company = resObj.billing.company,
                    address_1 = resObj.billing.address_1,
                    address_2 = resObj.billing.address_2,
                    city = resObj.billing.city,
                    postcode = resObj.billing.postcode,
                    country = resObj.billing.country,
                    state = resObj.billing.state,
                };

                //   JArray loi = (JArray)jObject1.GetValue("billing");
                //var   getresponse = loi.ToObject<List<Billing>>();

            }
            return getDetailById;

        }
    }
}

using DNKApp.Models;
using DNKApp.Utlities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DNKApp.Services
{
   public class PaymentGetwayService
    {
        public async Task<ObservableCollection<PaymentGetway>> GetPaymentGetwaysAsync()
        {
            ObservableCollection<PaymentGetway> getresponse = new ObservableCollection<PaymentGetway>();
            var Httpclient = new HttpClient();

            var url = Constants.BaseApiAddress + "wp-json/wc/v3/payment_gateways" + Constants.Consumer_Key;

            var uri = new Uri(string.Format(url, string.Empty));

            HttpResponseMessage response = null;

            response = await Httpclient.GetAsync(uri);




            if (response.StatusCode == HttpStatusCode.OK)
            {
                using (var client = new HttpClient())
                {

                    var result = await client.GetStringAsync(uri);


                    var EmployeeList = JsonConvert.DeserializeObject<List<PaymentGetway>>(result);

                    getresponse = new ObservableCollection<PaymentGetway>(EmployeeList);

                }
                //var responseContent = await response.Content.ReadAsStringAsync();
                //var jObject = JObject.Parse(responseContent);
                //JArray loi = (JArray)jObject.GetValue("categories");
                //getresponse = loi.ToObject<List<Product>>();

            }
            return getresponse;

        }
    }
}

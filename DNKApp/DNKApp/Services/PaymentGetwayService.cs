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
using Microsoft.CSharp;
using Microsoft.CSharp.RuntimeBinder;


namespace DNKApp.Services
{
   public class PaymentGetwayService
    {
        public async Task<List<PaymentGetway>> GetPaymentGetwaysAsync()
        {
            List<PaymentGetway> getresponse = new List<PaymentGetway>();
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
                    //dynamic resObj = JsonConvert.DeserializeObject(result.ToString());
                    List<dynamic> resObj = JsonConvert.DeserializeObject<List<dynamic>>(result);
                    List<PaymentGetway> PaymentMethodList =new List<PaymentGetway>();
                    if (resObj != null)
                    {
                        foreach (var vrec in resObj)
                        {
                            PaymentGetway sublist = new PaymentGetway();
                            sublist.id = vrec.id;
                            sublist.title = vrec.title;
                           
                         
                              
                            PaymentMethodList.Add(sublist);
                        }
                    }

                    //var PaymentMethodList = JsonConvert.DeserializeObject<List<PaymentGetway>>(result);

                    getresponse = new List<PaymentGetway>(PaymentMethodList);

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

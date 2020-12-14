using DNKApp.Models;
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
    public class PlaceOrderApi
    {
        internal async Task<clsResponse> PlaceOrder(clsInvoice items)
        {
            clsResponse response1 = new clsResponse();

            var Httpclient = new HttpClient();

            var url =  "myapi/insertupdatesaleorder";

            var uri = new Uri(string.Format(url, string.Empty));

            var json = JsonConvert.SerializeObject(items);

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = null;

            response = await Httpclient.PostAsync(uri, content);


            if (response.StatusCode == HttpStatusCode.OK)
            {
                var responseContent = await response.Content.ReadAsStringAsync();

                var jObject = JObject.Parse(responseContent);



                response1 = new clsResponse
                {
                    Status = (bool)jObject.GetValue("Status"),

                    Message = jObject.GetValue("Message").ToString(),
                    OrderNumber = jObject.GetValue("orderNumber").ToString(),

                };



            }

            return response1;
        }
    }
}

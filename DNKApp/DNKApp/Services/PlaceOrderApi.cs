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
        //internal async Task PlaceOrder()
        //{
        //    clsResponse response1 = new clsResponse();

        //    var Httpclient = new HttpClient();

        //    var url = "https://example.com/wp-json/wc/v3/orders/consumer_key=ck_c822f95423287f7ccd15df53b7e56d3de3d5468d&consumer_secret=cs_e1f61450a3c4a7430ce1f493b116912ed60929b5";

        //    var uri = new Uri(string.Format(url, string.Empty));

        //    var json = JsonConvert.SerializeObject(order);

        //    var content = new StringContent(json, Encoding.UTF8, "application/json");

        //    HttpResponseMessage response = null;

        //    response = await Httpclient.PostAsync(uri, content);


        //    if (response.StatusCode == HttpStatusCode.OK)
        //    {
        //        var responseContent = await response.Content.ReadAsStringAsync();

        //        var jObject = JObject.Parse(responseContent);



        //        response1 = new clsResponse
        //        {
        //            Status = (bool)jObject.GetValue("Status"),

        //            Message = jObject.GetValue("Message").ToString(),
        //            OrderNumber = jObject.GetValue("orderNumber").ToString(),

        //        };



        //    }

            
        //}

        internal Task PlaceOrder(OrderDetailModel order)
        {
            throw new NotImplementedException();
        }
    }
}

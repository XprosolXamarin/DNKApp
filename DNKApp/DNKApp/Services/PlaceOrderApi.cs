

using DNKApp.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SQLite;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DNKApp.Services
{
    public class PlaceOrderApi
    {
       

        internal async Task<string> PlaceOrderAsync(OrderDetailModel order)
        {
            string id = "";
            var Httpclient = new HttpClient();

            var url = "https://qepdns.com/wp-json/wc/v3/orders?consumer_key=ck_c822f95423287f7ccd15df53b7e56d3de3d5468d&consumer_secret=cs_e1f61450a3c4a7430ce1f493b116912ed60929b5";

            var uri = new Uri(string.Format(url, string.Empty));

            var json = JsonConvert.SerializeObject(order);

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = null;

            response = await Httpclient.PostAsync(uri, content);
            if (response.StatusCode == HttpStatusCode.Created)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var jObject = JObject.Parse(responseContent);
                id = (string)jObject.GetValue("id");

            }
            return id;

        }
    }
}

﻿using DNKApp.Models;
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
    public class UpdateADetailsService
    {
        internal async Task AccountDetailsAsync(clsUpdateAccountDetail clsUpdateAccount)
        {
            string id = await Utilty.GetSecureStorageValueFor(Utilty.UserId);
            var Httpclient = new HttpClient();

            var url =Constants.BaseApiAddress+ "wp-json/wc/v3/customers/"+id + Constants.Consumer_Key;

            var uri = new Uri(string.Format(url, string.Empty));

            var json = JsonConvert.SerializeObject(clsUpdateAccount);

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = null;

            response = await Httpclient.PutAsync(uri, content);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var jObject = JObject.Parse(responseContent);
               

            }
           
        }
    }
}

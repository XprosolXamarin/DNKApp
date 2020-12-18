﻿using DNKApp.Models;
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
    public class ItemsListApi
    {
        public async Task<ObservableCollection<Product>> GetListofItems()
        {
            ObservableCollection<Product> getresponse = new ObservableCollection<Product>();
            var Httpclient = new HttpClient();

            var url = Constants.BaseApiAddress + "wp-json/wc/v2/products"+Constants.Consumer_Key;

            var uri = new Uri(string.Format(url, string.Empty));

            HttpResponseMessage response = null;

            response = await Httpclient.GetAsync(uri);

            
                
            
            if (response.StatusCode == HttpStatusCode.OK)
            {
                using (var client = new HttpClient())
                {

                    var result = await client.GetStringAsync(uri);


                    var EmployeeList = JsonConvert.DeserializeObject<List<Product>>(result);
                    
                    getresponse = new ObservableCollection<Product>(EmployeeList);
                    
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

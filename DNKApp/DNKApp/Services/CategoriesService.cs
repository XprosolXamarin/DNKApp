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
   public class CategoriesService
    {
        public async Task<ObservableCollection<Category>> GetListofCategories()
        {
            ObservableCollection<Category> getresponse = new ObservableCollection<Category>();
            var Httpclient = new HttpClient();

            var url = Constants.BaseApiAddress + "wp-json/wc/v3/products/categories" + Constants.Consumer_Key;

            var uri = new Uri(string.Format(url, string.Empty));

            HttpResponseMessage response = null;

            response = await Httpclient.GetAsync(uri);




            if (response.StatusCode == HttpStatusCode.OK)
            {
                using (var client = new HttpClient())
                {

                    var result = await client.GetStringAsync(uri);


                    var EmployeeList = JsonConvert.DeserializeObject<List<Category>>(result);

                    getresponse = new ObservableCollection<Category>(EmployeeList);

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

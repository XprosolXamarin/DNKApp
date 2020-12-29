using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace DNKApp.Utlities
{
   public class Utilty
    {
        public static string UserName = "Username";
        public static string Password = "Password";
        public static string UserId = "UserId";
        public static string UserEmail = "UserEmail";
        public static string display_name = "display_name";

        public static async Task SetSecureStorageValue(string key, string value)
        {
            try
            {
                await SecureStorage.SetAsync(key, value);
            }
            catch (Exception ex)
            {
                App.Current.Properties[key] = value;
            }

        }

        public static async Task<string> GetSecureStorageValueFor(string key)
        {
            string value = "";
            try
            {
                value = await SecureStorage.GetAsync(key);
            }
            catch (Exception ex)
            {
                value = App.Current.Properties[key] as string;
            }

            return value;
        }
    }
}

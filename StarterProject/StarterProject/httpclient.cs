using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace StarterProject
{
    
    class httpclient
    {
        static HttpClient mClient;
        public static void initialize()
        {
            mClient = new HttpClient();

        }
        public static async Task<string> getFromFirebase()
        {
            HttpResponseMessage res = await mClient.GetAsync("https://firestore.googleapis.com/v1/projects/sharezeug/databases/(default)/documents/items");
            Console.WriteLine(" statuscode: "+ res.StatusCode + " reason: " + res.ReasonPhrase + " content: "+ res.Content);
            string body = await res.Content.ReadAsStringAsync();
            return body;
        }

        public static async void postItem()
        {
            //HttpContent mContent = new HttpContent();

           // HttpResponseMessage res = await mClient.PostAsync("https://firestore.googleapis.com/v1/projects/sharezeug/databases/(default)/documents/items", "test");
        }

        public static void setToken()
        {
            string token = (string)Xamarin.Forms.Application.Current.Properties["token"];
            mClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }
    }
}

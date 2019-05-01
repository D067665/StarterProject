using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Firebase.Storage;
using Xam.Plugin.DownloadManager;

using System.IO;
using System.Net;
using Plugin.DownloadManager;
using Plugin.FirebaseStorage;

namespace StarterProject
{
    
    class httpclient
    {
        static HttpClient mClient;
        static WebClient mWebClient;
        public static void initialize()
        {
            mClient = new HttpClient();
            mWebClient = new WebClient();

        }
        public static async Task<string> getFromFirebase()
        {
            HttpResponseMessage res = await mClient.GetAsync("https://firestore.googleapis.com/v1/projects/sharezeug/databases/(default)/documents/items");
            Console.WriteLine(" statuscode: "+ res.StatusCode + " reason: " + res.ReasonPhrase + " content: "+ res.Content);
            string body = await res.Content.ReadAsStringAsync();
            return body;
        }
        public static async void downloadPhoto(string docname) {

            var reference = CrossFirebaseStorage.Current.Instance.RootReference.GetChild("ItemsPhotos").GetChild(docname+".jpg");

            await reference.GetFileAsync("/test");
            /*
            var downloadmanager = CrossDownloadManager.Current;
            var file = downloadmanager.CreateDownloadFile("https://firebasestorage.googleapis.com/v0/b/sharezeug.appspot.com/o/ItemsPhotos%2F" + docname + ".jpg?alt=media");
            Console.WriteLine("Path Name: "+ file.DestinationPathName);
            downloadmanager.Start(file);
            try
            {
              mWebClient.DownloadFile("https://firebasestorage.googleapis.com/v0/b/sharezeug.appspot.com/o/ItemsPhotos%2F" + docname + ".jpg?alt=media", "/"+docname+".jpg");

                //mWebClient.DownloadFile("https://firebasestorage.googleapis.com/v0/b/sharezeug.appspot.com/o/ItemsPhotos%2F" + docname + ".jpg?alt=media", docname + ".jpg");
            }catch(Exception es)
            {
                Console.WriteLine(es.Message);

            }*/
        }
        public static async Task<string> getFromFirebaseAvailability()
        {
            HttpResponseMessage res = await mClient.GetAsync("https://firestore.googleapis.com/v1/projects/sharezeug/databases/(default)/documents/availability");
            Console.WriteLine(" statuscode: " + res.StatusCode + " reason: " + res.ReasonPhrase + " content: " + res.Content);
            string body = await res.Content.ReadAsStringAsync();
            return body;
        }

        public static async void postItem(JObject mjObject, Stream imageStream)
        {
            // Database
            var content = new StringContent(mjObject.ToString(), Encoding.UTF8, "application/json");
            var result = await mClient.PostAsync("https://firestore.googleapis.com/v1/projects/sharezeug/databases/(default)/documents/items", content);
            Console.WriteLine(result.StatusCode + result.ReasonPhrase);
            string body = await result.Content.ReadAsStringAsync();

            string[] test = body.Split('\"');
            Console.WriteLine(test);
            string[] test2 = test[3].Split('/');
            string name = test2[test2.Length - 1];
            //Photo
            var stroageImage = await new FirebaseStorage("sharezeug.appspot.com")
            .Child("ItemsPhotos")
            .Child(name+".jpg")
            .PutAsync(imageStream);
            


            //HttpContent mContent = new HttpContent();
            // HttpResponseMessage res = await mClient.PostAsync("https://firestore.googleapis.com/v1/projects/sharezeug/databases/(default)/documents/items", "test");
        }
        public static async void deleteItem(string docname)
        {
            var result = await mClient.DeleteAsync("https://firestore.googleapis.com/v1/projects/sharezeug/databases/(default)/documents/items/" + docname);
            Console.WriteLine(result.StatusCode + result.ReasonPhrase);
        }
        public static void setToken()
        {
            string token = (string)Xamarin.Forms.Application.Current.Properties["token"];
            mClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }


    }
}

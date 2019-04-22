using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Firebase.Auth;
//using Firebase;
//using Firebase.Firestore;
using StarterProject;
using UsingDependencyService.Android;

[assembly: Xamarin.Forms.Dependency(typeof(RegisterAndroid))]
namespace UsingDependencyService.Android
{
    class RegisterAndroid : IRegister
    {
        private FirebaseAuth mAuth;
        public async Task<string> registerWithEmailPassword(string email, string password)
        {
            mAuth = FirebaseAuth.Instance;
            IAuthResult result = await mAuth.CreateUserWithEmailAndPasswordAsync(email, password);
            var token = await result.User.GetIdTokenAsync(false);
            return token.Token;
            Console.WriteLine(result);
        }

        /*
        public void testFirestore()
        {

            // This HACK will be not needed, fixed in https://github.com/xamarin/GooglePlayServicesComponents/commit/723ebdc00867a4c70c51ad2d0dcbd36474ce8ff1
            var options = new Firebase.FirebaseOptions.Builder().SetProjectId("sharezeug").Build();
            Firebase.FirebaseApp.InitializeApp(Application.Context, options, "sharezeug");
            //FirebaseApp.InitializeApp(Application.Context, );
            FirebaseFirestore db = FirebaseFirestore.GetInstance(FirebaseApp.Instance);
            DocumentReference docRef = db.Collection("users").Document("alovelace");
            Dictionary<string, Java.Lang.Object> user = new Dictionary<string, Java.Lang.Object>
            {
                { "First", "Ada" },
                { "Last", "Lovelace" },
                { "Born", 1815 }
            };
            //await docRef.Set(user);
            db.Collection("test").Add(user);
            /*
            // Create a new user with a first and last name
            Map<string, Object> user = new HashMap<>();
            user.put("first", "Ada");
            user.put("last", "Lovelace");
            user.put("born", 1815);

            FirebaseFirestore db = FirebaseFirestore.GetInstance(FirebaseApp.Instance);
            db.Collection("test").Add()
            
        }*/
    
    }
}
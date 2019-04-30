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
using Firebase;
using Firebase.Auth;
//using Firebase.Firestore;
using StarterProject;
using StarterProject.Droid;
using UsingDependencyService.Android;
using Xamarin.Forms;

[assembly: Dependency(typeof(FirebaseAuthenticator))]
namespace UsingDependencyService.Android
{
    class FirebaseAuthenticator : IFirebaseAuthenticator
    {
        private FirebaseAuth mAuth;
        public async Task<string> LoginWithEmailPassword(string email, string password)
        {
            mAuth = FirebaseAuth.Instance;
            var user = await FirebaseAuth.Instance.
                            SignInWithEmailAndPasswordAsync(email, password);
            var token = await user.User.GetIdTokenAsync(false);
            Xamarin.Forms.Application.Current.Properties["uid"] = user.User.Uid;
            /*
            FirestoreService.Instance.Collection("items").
            var doc = FirebaseFirestore.Instance.Document("items").Get();
            var result = doc.Result;
            Console.WriteLine("doc: " + doc + " result: " + result);
            */
            return token.Token;
            
        }
        /*public async void firestoreget()
        {
            var doc = FirebaseFirestore.Instance.Document("items").Get();
            var result = doc.Result;
            Console.WriteLine("doc: " + doc + " result: " + result);


        }*/
    }
}
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
using StarterProject;
using UsingDependencyService.Android;

[assembly: Xamarin.Forms.Dependency(typeof(RegisterAndroid))]
namespace UsingDependencyService.Android
{
    class RegisterAndroid : IRegister
    {
        public async Task<string> registerWithEmailPassword(string email, string password)
        {
            IAuthResult result = await FirebaseAuth.Instance.CreateUserWithEmailAndPasswordAsync(email, password);
            var token = await result.User.GetIdTokenAsync(false);
            return token.Token;
            Console.WriteLine(result);
        }
    }
}
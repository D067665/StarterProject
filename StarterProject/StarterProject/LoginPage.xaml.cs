using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StarterProject
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            myLocalImage.Source = ImageSource.FromFile("toolkit.png");
            httpclient.initialize();
        }
        private void Onclick(object sender, EventArgs e)
        {
            //Navigation.PushAsync(new MainPage());

        }

        private void Btn_SignUp_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Register());
            // DependencyService.Get<IRestService<Event>>().GetAllAsync();
            // DependencyService.Get<IRegister>().testFirestore();


        }
        private async void Btn_SignIn_Clicked(object sender, EventArgs e)
        {


            try
            {
                string token = await DependencyService.Get<IFirebaseAuthenticator>().LoginWithEmailPassword(Entry_EMailAdress.Text, Entry_Password.Text);
                Console.WriteLine("token: " + token);
                Application.Current.Properties["token"] = token;

                httpclient.setToken();
                await Navigation.PushAsync(new LandingPage());
            }
            catch (Exception f)
            {
                DependencyService.Get<IToast>().ShortAlert("Check your input!");
                Console.WriteLine("Exception: " + f);
            }
        }

            /*private async void Btn_SignIn_Clicked(object sender, EventArgs e)
             {
                 Console.WriteLine("gesendet");

                 try
                 {
                     string token = await DependencyService.Get<IFirebaseAuthenticator>().LoginWithEmailPassword(Entry_EMailAdress.Text, Entry_Password.Text);
                     Console.WriteLine("token: " + token);
                     Navigation.PushAsync(new LandingPage());
                 }
                 catch (Exception f)
                 {
                     DependencyService.Get<IToast>().ShortAlert("Überprüfe deine Eingaben!");
                     Console.WriteLine("Exception: " + f);
                 }


                 /*string test = Entry_EMailAdress.Text;
                 string user = await IFirebaseAuthenticator.LoginWithEmailPassword(Entry_EMailAdress.Text, Entry_Password.Text);

             }*/
        
    }
}

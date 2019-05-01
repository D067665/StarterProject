using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace StarterProject
{
    public partial class App : Application
    {
        public App()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("ODUzMjJAMzEzNzJlMzEyZTMwTWFlOUtLRHpzK2pTNTBIUnhGZC9KS2JKYk9sUUowc1M1eTUyVFJGeHN0ST0 =");
            InitializeComponent();

            // MainPage = new LoginPage();
            MainPage = new NavigationPage(new LoginPage())
            {
                BarBackgroundColor = Color.FromHex("#FFAD26"),
                BarTextColor = Color.Gray,
                Icon = "logo.png",


            };
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}

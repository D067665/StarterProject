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
		public LoginPage ()
		{
			InitializeComponent ();
           myLocalImage.Source = ImageSource.FromFile("toolkit.png");
		}
        private void Onclick(object sender, EventArgs e)
        {
            //Navigation.PushAsync(new MainPage());

        }

        private void Btn_SignUp_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Register());

        }

        private void Btn_SignIn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LandingPage());

        }
    }
}
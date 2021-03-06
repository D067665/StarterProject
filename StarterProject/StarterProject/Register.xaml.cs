﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StarterProject
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Register : ContentPage
	{
		public Register ()
		{
			InitializeComponent ();
		}
        private async void Btn_Signup_Clicked(object sender, EventArgs e)
        {
            if (Entry_Password.Text.Equals(Entry_ConfirmPw.Text))
            {
                try
                {
                    string token = await DependencyService.Get<IRegister>().registerWithEmailPassword(Entry_Email.Text, Entry_Password.Text);
                    Console.WriteLine(token);
                    Application.Current.Properties["token"] = token;
                    DependencyService.Get<IToast>().ShortAlert("Erfolgreich registriert!");
                    httpclient.setToken();
                    Navigation.PushAsync(new LandingPage());

                }
                catch (Exception ex)
                {
                    DependencyService.Get<IToast>().LongAlert("Da ist wohl etwas schief gelaufen: " + ex.Message);
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                DependencyService.Get<IToast>().ShortAlert("Passwörter stimmen nicht überein!");
            }

        }
        private void Btn_GoToSignin_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LoginPage());

        }
    }
}
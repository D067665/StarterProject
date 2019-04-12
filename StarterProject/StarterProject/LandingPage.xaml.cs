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
	public partial class LandingPage : ContentPage
	{
		public LandingPage ()
		{
			InitializeComponent ();
            
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            // Navigation.PushAsync(new SearchPage());
            Navigation.PushAsync(new ToolOverviewPage());
        }

        private void TapGestureRecognizer_TappedAdd(object sender, EventArgs e)

        {
            Navigation.PushAsync(new TakePhotoPage());

        }

        private void TapGestureRecognizer_TappedHistory(object sender, EventArgs e)

        {
            Navigation.PushAsync(new HistoryPage());

        }
    }
}
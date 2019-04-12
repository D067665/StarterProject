using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Geolocator;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StarterProject
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class GeoPage : ContentPage
	{
		public GeoPage ()
		{
			InitializeComponent ();
		}
        private async void Button_Clicked(object sender, EventArgs e)
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 50;
            var position = await locator.GetPositionAsync(TimeSpan.FromSeconds(10000));

            Lbl_Lat.Text = position.Latitude.ToString();
            Lbl_Long.Text = position.Longitude.ToString();




        }
    }
}
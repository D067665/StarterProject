using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Maps;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Geolocator;

namespace StarterProject
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MapOverviewPage : ContentPage
	{
		public MapOverviewPage ()
		{
			InitializeComponent ();
           MyMap.MoveToRegion(
                MapSpan.FromCenterAndRadius(
                    new Position(37, -122), Distance.FromMiles(1)));
            
            

            var position1 = new Position(36.8961, 10.1865);
            var position2 = new Position(36.891, 10.181);
            var position3 = new Position(36.567, 10.897);


            var pin1 = new Pin
            {
                Type = PinType.Place,
                Position = position1,
                Label = "Top Hammer",
                Address = "BeiSchmidts"
            };

            var pin2 = new Pin
            {
                Type = PinType.Place,
                Position = position2,
                Label = "Neuer Hammer",
                Address = "BeiMüllers"
            };
            var pin3 = new Pin
            {
                Type = PinType.Place,
                Position = position3,
                Label = "Kostenloser Hammer",
                Address = "BeiMeiyers"
            };

            MyMap.Pins.Add(pin1);
            MyMap.Pins.Add(pin2);
            MyMap.Pins.Add(pin3);
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
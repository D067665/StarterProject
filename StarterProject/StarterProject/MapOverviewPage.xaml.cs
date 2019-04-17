using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Maps;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Geolocator;
using StarterProject.ViewModel;

namespace StarterProject
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MapOverviewPage : ContentPage
	{
        ToolViewModel tvm;
        public MapOverviewPage ()
		{
			InitializeComponent ();
            tvm = new ToolViewModel();
            
            BindingContext = tvm;

            //placing Center of Map at own location
            GetLocation(MyMap);
            var pin = new Pin { };
           
            //place pin for each tool in Tool Model
            foreach (var tool in tvm.Tools)
            {
                var toolLat = tool.ToolLat;
                var toolLong = tool.ToolLong;
                var position = new Position(toolLat, toolLong);
                pin = new Pin { Type = PinType.SearchResult, Position = position, Label = tool.ToolDescription, BindingContext = tool };
                
                pin.Clicked += Pin_Clicked;
                MyMap.Pins.Add(pin);
            }
            
           
            
            
            
            

           /* var position1 = new Position(36.8961, 10.1865);
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
            MyMap.Pins.Add(pin3);*/

            
        }
        private static async void GetLocation(Map MyMap)
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 50;
            var position = await locator.GetPositionAsync(TimeSpan.FromSeconds(10000));
            MyMap.MoveToRegion(
               MapSpan.FromCenterAndRadius(
                   new Position(position.Latitude, position.Longitude), Distance.FromKilometers(5)));


        }

        private async void Pin_Clicked(object sender, EventArgs eventArgs)
        {
            var selectedPin = sender as Pin;

            //returns binding context during runtime, how to access it here?
            var tool = (StarterProject.Model.Tool) selectedPin.BindingContext;
            
            var answer = await DisplayAlert(selectedPin?.Label, "Want to see details?", "See Details", "Close");
            if (answer)
            {
                
                //musst access BindingContext to display
                await Navigation.PushAsync(new ToolDetailPage(tool.ToolDescription, tool.ToolLocation, tool.ToolPrice, tool.ToolImage, tool.ToolLat, tool.ToolLong, tool.OwnerPhone));
            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 50;
            var position = await locator.GetPositionAsync(TimeSpan.FromSeconds(100000));

            Lbl_Lat.Text = position.Latitude.ToString();
            Lbl_Long.Text = position.Longitude.ToString();




        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Maps;
using StarterProject.Model;
using StarterProject.ViewModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Geolocator;


namespace StarterProject
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MapOverviewPage : ContentPage
	{
        //ToolViewModel tvm;
        public MapOverviewPage (IEnumerable<Tool> tools)
		{
			InitializeComponent ();
           // tvm = new ToolViewModel();
            
            //BindingContext = tvm;
            
            
            //placing Center of Map at own location
            GetLocation(MyMap);
            var pin = new Pin { };

            //place pin for each tool in Tool Model
            foreach (var tool in tools)
            {
                var toolLat = tool.ToolLat;
                var toolLong = tool.ToolLong;
                var position = new Position(toolLat, toolLong);
                pin = new Pin { Type = PinType.SearchResult, Position = position, Label = tool.ToolDescription, BindingContext = tool };

                pin.Clicked += Pin_Clicked;
                MyMap.Pins.Add(pin);
            }

            
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
                await Navigation.PushAsync(new ToolDetailPage(tool.ToolDescription, tool.ToolLocation,  tool.CombinedPrice, tool.ToolImage, tool.ToolLat, tool.ToolLong, tool.OwnerPhone, tool.ToolDatabaseNameSub, tool.minDateUser, tool.maxDateUser));
            }
        }

        
    }
}
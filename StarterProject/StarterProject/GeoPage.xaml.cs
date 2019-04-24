using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Plugin.Geolocator;
using StarterProject.Model;
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
        private  void Button_Clicked(object sender, EventArgs e)
        {
           /* var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 50;
            var position = await locator.GetPositionAsync(TimeSpan.FromSeconds(10000));

            Lbl_Lat.Text = position.Latitude.ToString();
            Lbl_Long.Text = position.Longitude.ToString();*/

            Tool tool = new Tool()
            {
                ToolDescription = "Hammer - wie neu!",
                ToolLocation = "Mannheim",
                ToolPrice = 1,
                ToolPriceSpan = "pro Woche",
                ToolImage = "hammer.png",
                ToolLat = 49.49671,
                ToolLong = 8.47955,
                OwnerPhone = "+496224567867"
            };

            string strResultJson = JsonConvert.SerializeObject(tool);
            Console.WriteLine(strResultJson);
            File.WriteAllText(@"student.json", strResultJson);




        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Maps;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Messaging;

namespace StarterProject
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ToolDetailPage : ContentPage
	{
        private string OwnerPhone;
		public ToolDetailPage ( string ToolDescription, string ToolLocation, string ToolPrice, string ToolImage, double ToolLat, double ToolLong, string OwnerPhone)
		{
			InitializeComponent ();
            Label_ToolDescription.Text = ToolDescription;
            Label_ToolLocation.Text = ToolLocation;
            Label_ToolPrice.Text = ToolPrice;
            Image_Tool.Source = ToolImage;
            MapDetail.MoveToRegion(
              MapSpan.FromCenterAndRadius(
                  new Position(ToolLat, ToolLong), Distance.FromKilometers(1)));
           var pin = new Pin { Type = PinType.SearchResult, Position = new Position(ToolLat, ToolLong), Label = ToolDescription };
            MapDetail.Pins.Add(pin);
            this.OwnerPhone = OwnerPhone;

        }

        private void Btn_Call_Clicked(object sender, EventArgs e)
        {
            var phoneDialer = CrossMessaging.Current.PhoneDialer;
            if (phoneDialer.CanMakePhoneCall)
                phoneDialer.MakePhoneCall(OwnerPhone);

        }

        private void Btn_GoToBooking_Clicked(object sender, EventArgs e)
        {
            var ToolDescription = Label_ToolDescription.Text;
            var ToolLocation = Label_ToolLocation.Text;
            var ToolPrice = Label_ToolPrice.Text;
            var ToolImage = Image_Tool.Source.ToString();
            Navigation.PushAsync(new BookingPage(ToolDescription, ToolLocation, ToolPrice, ToolImage));

        }


        /* public ToolDetailPage()
{


}*/

    }
}
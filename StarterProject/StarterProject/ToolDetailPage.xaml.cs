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
        private string ToolDatabaseNameSub;
        private DateTime MinUserDate;
        private DateTime MaxUserDate;
		public ToolDetailPage ( string ToolDescription, string ToolLocation, string CombinedPrice, string ToolImage, double ToolLat, double ToolLong, string OwnerPhone, string ToolDatabaseNameSub, DateTime MinUserDate, DateTime MaxUserDate)
		{
			InitializeComponent ();
            Label_ToolDescription.Text = ToolDescription;
            Label_ToolLocation.Text = ToolLocation;
            Label_ToolPrice.Text = CombinedPrice;
            Image_Tool.Source = ToolImage;
            Label_Startdate.Text = "From " + MinUserDate.ToString("dd/MM/yyyy");
            Label_Enddate.Text = "till " + MaxUserDate.ToString("dd/MM/yyyy");
            MapDetail.MoveToRegion(
              MapSpan.FromCenterAndRadius(
                  new Position(ToolLat, ToolLong), Distance.FromKilometers(1)));
           var pin = new Pin { Type = PinType.SearchResult, Position = new Position(ToolLat, ToolLong), Label = ToolDescription };
            MapDetail.Pins.Add(pin);
            this.OwnerPhone = OwnerPhone;
            this.ToolDatabaseNameSub = ToolDatabaseNameSub;
            this.MinUserDate = MinUserDate;
            this.MaxUserDate = MaxUserDate;

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
            Navigation.PushAsync(new BookingPage(ToolDescription, ToolLocation, ToolPrice, ToolImage, ToolDatabaseNameSub, MinUserDate, MaxUserDate));

        }

    }
}
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
	public partial class ToolDetailPage : ContentPage
	{
		public ToolDetailPage ( string ToolDescription, string ToolLocation, string ToolPrice, string ToolImage)
		{
			InitializeComponent ();
            Label_ToolDescription.Text = ToolDescription;
            Label_ToolLocation.Text = ToolLocation;
            Label_ToolPrice.Text = ToolPrice;
            Image_Tool.Source = ToolImage;

		}

        private void Btn_Call_Clicked(object sender, EventArgs e)
        {

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
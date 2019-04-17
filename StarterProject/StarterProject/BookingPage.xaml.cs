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
	public partial class BookingPage : ContentPage
	{
		public BookingPage (string ToolDescription, string ToolLocation, string ToolPrice, string ToolImage)
		{
			InitializeComponent ();
            Label_ToolDescription.Text = ToolDescription;
            Label_ToolLocation.Text = ToolLocation;
            Label_ToolPrice.Text = ToolPrice;
            Image_Tool.Source = ToolImage;
            
		}

        private void Calendar_SelectionChanged(Syncfusion.SfCalendar.XForms.SfCalendar sender, Syncfusion.SfCalendar.XForms.SelectionChangedEventArgs e)
        {
            // var pickedDate = e.DateAdded;
            // var pickedDateArray = pickedDate.ToArray;
            // var pickedDateString= pickedDateArray[0].ToString();
           
            if (sender.SelectedRange != null)
            {
                var startDateObj = (Syncfusion.SfCalendar.XForms.SelectionRange) sender.SelectedRange;
                var startDate = startDateObj.StartDate.ToString();
                var endDateObj = (Syncfusion.SfCalendar.XForms.SelectionRange)sender.SelectedRange;
                var endDate = endDateObj.EndDate.ToString();
                /*var rangeArray = range.ToArray();
                var startDate = range[0].ToString();
                var endDate = range[rangeArray.Length - 1].ToString();*/
                Label_Start.Text = startDate;
                Label_End.Text = endDate;
            }

            
        }
    }
}
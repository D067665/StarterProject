using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syncfusion.SfCalendar;
using Syncfusion.SfCalendar.XForms;
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
            //Image_Tool.Source = ToolImage;
            //set Range that owner published at min, max date - test hard coded
            //get Availability for displayed tool
            DateTime minDateUser = new DateTime(2019, 1, 20);
            //compare when user starts sharing tool - if already started in past -> min date is today
            DateTime today = DateTime.Now;
            var value = DateTime.Compare(minDateUser, today);

            if (value > 0) // minDateUser later than today
                calendar.MinDate = minDateUser;

            else if (value < 0) // minDateUser earlier than today
                calendar.MinDate = today;

            else //minDateUser = today
                calendar.MinDate = today;

            DateTime maxDateUser = new DateTime(2019, 7, 12);
            calendar.MaxDate = maxDateUser;
        

        //Test Blackout Dates - blackout dates that other users booked the tool - test hard coded
        string endDate = "5/20/2019";
            string startDate = "5/10/2019";
            DateTime enteredDate = DateTime.Parse(endDate);
            DateTime enteredDateStart = DateTime.Parse(startDate);
            var dateRange = Enumerable.Range(0, 1 + enteredDate.Subtract(enteredDateStart).Days)
            .Select(offset => enteredDateStart.AddDays(offset))
            .ToArray();
            List<DateTime> black_dates = new List<DateTime>();
            black_dates.Add(new DateTime(2019, 5, 20));
            black_dates.Add(new DateTime(2019, 4, 21));
            black_dates.Add(new DateTime(2019, 4, 22));
            black_dates.Add(new DateTime(2019, 1, 23));
            black_dates.AddRange(dateRange);
            calendar.BlackoutDates = black_dates;
        }

        private void Calendar_SelectionChanged(Syncfusion.SfCalendar.XForms.SfCalendar sender, Syncfusion.SfCalendar.XForms.SelectionChangedEventArgs e)
        {
            
           
            if (sender.SelectedRange != null)
            {
                var startDateObj = (Syncfusion.SfCalendar.XForms.SelectionRange) sender.SelectedRange;
                var startDate = startDateObj.StartDate.ToString();
                //just include date, not time
                var justStartDate = startDate.Substring(0, 10);
                //convert to DateTime to enable Substract method later on
                DateTime startDateDate = DateTime.Parse(justStartDate);
                
                var endDateObj = (Syncfusion.SfCalendar.XForms.SelectionRange)sender.SelectedRange;
                var endDate = endDateObj.EndDate.ToString();
                //just include date, not time
                var justEndDate = endDate.Substring(0, 10);
                DateTime endDateDate = DateTime.Parse(justEndDate);
                //get all dates inbetween - store it that way , or convert it when displying
                Enumerable.Range(0, 1 + endDateDate.Subtract(startDateDate).Days)
                .Select(offset => startDateDate.AddDays(offset))
                .ToArray();
                
                Label_Start.Text = justStartDate;
                Label_End.Text = justEndDate;
            }

            
        }

        private async void Btn_Book_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Great!", "You successfully booked the Tool from " + Label_Start.Text + "to " + Label_End.Text, "Ok");
            await Navigation.PushAsync(new LandingPage());

        }
    }
}
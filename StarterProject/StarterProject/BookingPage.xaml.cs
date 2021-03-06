﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syncfusion.SfCalendar;
using Syncfusion.SfCalendar.XForms;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using StarterProject.Model;
using System.Collections.ObjectModel;

namespace StarterProject
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BookingPage : ContentPage
	{

        DateTime startDate;
        DateTime endDate;
        string itemName;
        public BookingPage (string ToolDescription, string ToolLocation, string ToolPrice, string ToolImage, string ToolDatabaseNameSub, DateTime minDateUser, DateTime maxDateUser)
		{
			InitializeComponent ();
            Label_ToolDescription.Text = ToolDescription;
            Label_ToolLocation.Text = ToolLocation;
            Label_ToolPrice.Text = ToolPrice;

            //create calender range
            SetMinMaxRange(minDateUser, maxDateUser);
            itemName = ToolDatabaseNameSub;

            //Load all availabilities and create blackout lists
            loadAvailabilities(ToolDatabaseNameSub);
        }

        //set Range that owner published at min, max date 
        //compare when user starts sharing tool - if already started in past -> min date is today
        private void SetMinMaxRange(DateTime minDateUser, DateTime maxDateUser)
        {
            
            DateTime today = DateTime.Now;
            var value = DateTime.Compare(minDateUser, today);

            if (value > 0) // minDateUser later than today
                calendar.MinDate = minDateUser;

            else if (value < 0) // minDateUser earlier than today
                calendar.MinDate = today;

            else //minDateUser = today
                calendar.MinDate = today;

            calendar.MaxDate = maxDateUser;

        }


        private async void loadAvailabilities(string ToolDatabaseNameSub)
        { //load Availabilities
            var toolDBName = ToolDatabaseNameSub;
            string resAvailability = await httpclient.getFromFirebaseAvailability();
            JObject jsonAv = JObject.Parse(resAvailability);

            ObservableCollection<Availability> availability = new ObservableCollection<Availability>();
            IEnumerable<JToken> documentsAv = jsonAv.SelectTokens("documents[*]");


            foreach (JToken documentAv in documentsAv)
            {
                Availability availabilityTool = new Availability();
                availabilityTool.startDate = DateTime.Parse((string)documentAv.SelectToken("fields.start.timestampValue").ToString());
                availabilityTool.endDate = DateTime.Parse((string)documentAv.SelectToken("fields.end.timestampValue").ToString());
                availabilityTool.toolRef = (string)documentAv.SelectToken("fields.item.referenceValue").ToString();
                availability.Add(availabilityTool);
            }
            Console.WriteLine(availability);

            //Create List for all availabilities per Tool

            ObservableCollection<Availability> availabilityPerTool = new ObservableCollection<Availability>();

            foreach (Availability av in availability)
            {
                var toolNameRef = av.toolRef;
                Console.WriteLine("toolNameRef:" + toolNameRef);
                var toolNameRefSub = toolNameRef.Substring(55);
                if (toolNameRefSub.Equals(toolDBName))
                {
                    availabilityPerTool.Add(av);
                }
                else
                {
                    Console.WriteLine("no match");
                }
            }

            //Get DateRange between start and end Date from availabilities per Tool
            //Create Blackout List with ranges

            List<DateTime> black_dates = new List<DateTime>();
            foreach (Availability av in availabilityPerTool)
            {
                DateTime startDate = av.startDate;
                DateTime endDate = av.endDate;
                var dateRangeBooked = Enumerable.Range(0, 1 + endDate.Subtract(startDate).Days)
            .Select(offset => startDate.AddDays(offset))
            .ToArray();
                black_dates.AddRange(dateRangeBooked);
            }
            
            calendar.BlackoutDates = black_dates;

        }

        private void Calendar_SelectionChanged(Syncfusion.SfCalendar.XForms.SfCalendar sender, Syncfusion.SfCalendar.XForms.SelectionChangedEventArgs e)
        {
            
           
            if (sender.SelectedRange != null)
            {   //access to selectedRange
                var startDateObj = (Syncfusion.SfCalendar.XForms.SelectionRange) sender.SelectedRange;
                
                startDate = startDateObj.StartDate.Date;

                var endDateObj = (Syncfusion.SfCalendar.XForms.SelectionRange)sender.SelectedRange;
                endDate = endDateObj.EndDate.Date;

                var dateRange= Enumerable.Range(0, 1 + endDate.Subtract(startDate).Days)
                .Select(offset => startDate.AddDays(offset))
                .ToArray();
                
                Label_Start.Text = startDate.ToString("dd/MM/yyyy");
                Label_End.Text = endDate.ToString("dd/MM/yyyy"); 
            }

            
        }

        private async void Btn_Book_Clicked(object sender, EventArgs e)
        {
            if (string.Equals("Start", Label_Start.Text) || string.Equals("End", Label_End.Text))

            {
                await DisplayAlert("Info Missing", "Please fill out the Booking Range", "OK");
            }
            else
            {
                //Post
                string uid = (string)Application.Current.Properties["uid"];

                string jsonstring = "{'fields': {'end': { 'timestampValue': '" + endDate.Date.ToString("yyyy-MM-dd") + "T" + endDate.Date.ToString("HH:mm:ss") + "Z" + "' }, 'start': { 'timestampValue': '" + startDate.Date.ToString("yyyy-MM-dd") + "T" + startDate.Date.ToString("HH:mm:ss") + "Z" + "' }, 'item': { 'referenceValue': '" + "projects/sharezeug/databases/(default)/documents/items/" + itemName + "' }, 'uid': { 'stringValue': '" + uid + "'}}}";
                JObject mjObject = new JObject();
                mjObject = JObject.Parse(jsonstring);
                httpclient.postAvailability(mjObject);
                await DisplayAlert("Great!", "You successfully booked the Tool from " + Label_Start.Text + " to " + Label_End.Text, "Ok");
                await Navigation.PushAsync(new LandingPage());
            }

        }
    }
}
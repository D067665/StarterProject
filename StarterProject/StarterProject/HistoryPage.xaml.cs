
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using StarterProject.Model;
using StarterProject.ViewModel;
using Syncfusion.ListView.XForms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Xaml;

namespace StarterProject
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HistoryPage : Xamarin.Forms.TabbedPage
    {
        ToolViewModel tvm;
        ObservableCollection<Tool> toolsList;
        List<Availability> availabilityList;
        ObservableCollection<Tool> showAvailability;

        public HistoryPage ()
		{
			InitializeComponent ();
            this.On<Xamarin.Forms.PlatformConfiguration.Android>().SetIsSwipePagingEnabled(false);
            tvm = new ToolViewModel();

            BindingContext = tvm;
            
            loadItems();

        }

        private async void loadItems()
        {
            string res = await httpclient.getFromFirebase();
            string resAvailability = await httpclient.getFromFirebaseAvailability();
            JObject json = JObject.Parse(res);
            JObject jsonAv = JObject.Parse(resAvailability);
            // Console.WriteLine(res);
            Console.WriteLine("Json: " + json);

            List<Werkzeug> objWerkzeugliste = new List<Werkzeug>();
            toolsList = new ObservableCollection<Tool>();
            availabilityList = new List<Availability>();
            showAvailability = new ObservableCollection<Tool>();

            IEnumerable<JToken> documents = json.SelectTokens("documents[*]");
            IEnumerable<JToken> documentsAv = jsonAv.SelectTokens("documents[*]");
            string uid = (string) Xamarin.Forms.Application.Current.Properties["uid"];

            foreach (JToken document in documentsAv)
            {
                Availability availability = new Availability();

                if (document.SelectToken("fields.uid.stringValue") != null)
                {
                    availability.avUid = (string)document.SelectToken("fields.uid.stringValue").ToString();
                }
                 var refItem = (string)document.SelectToken("fields.item.referenceValue").ToString();
                availability.toolRef = refItem.Substring(55);
                if (availability.avUid != null && uid == availability.avUid)
                {
                    availabilityList.Add(availability);
                }

            }


                foreach (JToken document in documents)
            {

                Tool tool = new Tool();
               
                if (document.SelectToken("fields.uid.stringValue") != null)
                {
                    tool.ToolUid = (string)document.SelectToken("fields.uid.stringValue").ToString();
                }
                tool.ToolDescription = (string)document.SelectToken("fields.description.stringValue").ToString();
                tool.ToolLocation = (string)document.SelectToken("fields.location.stringValue").ToString();
                var dataBaseName = (string)document.SelectToken("name").ToString();
                tool.ToolDatabaseNameSub = dataBaseName.Substring(55);
                tool.ToolPriceSpan = (string)document.SelectToken("fields.priceSpan.stringValue").ToString();
                tool.OwnerPhone = (string)document.SelectToken("fields.ownerphone.stringValue").ToString();
                var minDateUser = document.SelectToken("fields.minDateUser.timestampValue").ToString();
                tool.minDateUser = DateTime.Parse(minDateUser);

                var maxDateUser = document.SelectToken("fields.maxDateUser.timestampValue").ToString();
                tool.maxDateUser = DateTime.Parse(maxDateUser);
                var price = document.SelectToken("fields.price.integerValue").ToString();
                tool.ToolPrice = Convert.ToDouble(price);
                var lat = document.SelectToken("fields.geolocation.geoPointValue.latitude").ToString();
                tool.ToolLat = Convert.ToDouble(lat);
                var longit = document.SelectToken("fields.geolocation.geoPointValue.longitude").ToString();
                tool.ToolLong = Convert.ToDouble(longit);
                tool.ToolImage = "hammer.png";

                if (tool.ToolUid != null && uid == tool.ToolUid)
                {
                    toolsList.Add(tool);
                }

                foreach (Availability avail in availabilityList)
                {
                    if (avail.toolRef == tool.ToolDatabaseNameSub)
                    {
                        showAvailability.Add(tool);
                    }
                }

            }

            historyListTool.ItemsSource = toolsList;
            LoanedView.ItemsSource = showAvailability;
        }

            private void ListView_SwipeStarted(object sender, SwipeStartedEventArgs e)
        {
            if (e.ItemIndex == 1)
                e.Cancel = true;
        }
        private void ListView_SwipeEnded(object sender, SwipeEndedEventArgs e)
        {

            var historyTool = (StarterProject.Model.Tool) e.ItemData;
            
            if (e.SwipeOffset > 70) {
                httpclient.deleteItem(historyTool.ToolDatabaseNameSub);
                historyListTool.ResetSwipe();
                toolsList.Remove(historyTool);
            }
        }

        private void ListView_Swiping(object sender, SwipingEventArgs e)
        {
            if (e.ItemIndex == 1 && e.SwipeOffSet > 70)
                e.Handled = true;
        }
    }


}
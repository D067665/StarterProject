using StarterProject.Model;
using StarterProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syncfusion.XForms.Buttons;

using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using Syncfusion.XForms.Backdrop;


using Xamarin.Forms.Xaml;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
//using Firebase.Database;
//using Firebase.Database.Query;

namespace StarterProject
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ToolOverviewPage : SfBackdropPage
    {

        //SpeakerViewModel vm;
        ToolViewModel tvm;
        public IEnumerable<Tool> searchResults;

        public ToolOverviewPage ()
		{
			InitializeComponent();
            tvm = new ToolViewModel();
            //vm = new SpeakerViewModel();
            //listSpeakers.ItemsSource = vm.Speakers;
            //BindingContext = vm;
            BindingContext = tvm;
            /*
string token = (string)Xamarin.Forms.Application.Current.Properties["token"];

HttpClient _client = new HttpClient();
_client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("OAuth", token);
_client.GetAsync()
*/
            //  FirebaseClient fbclient = new FirebaseClient("https://firestore.googleapis.com/v1/projects/sharezeug/databases/(default)/documents/");
            //  fbclient.Child("items").

            loadItems();

        }

        private async void loadItems()
        {
            string res = await httpclient.getFromFirebase();
            string resAvailability = await httpclient.getFromFirebaseAvailability();
            JObject jsonAv = JObject.Parse(resAvailability);
            JObject json = JObject.Parse(res);
            // Console.WriteLine(res);
            Console.WriteLine("Json: " + json);

            List<Werkzeug> objWerkzeugliste = new List<Werkzeug>();
            ObservableCollection<Tool> toolsList = new ObservableCollection<Tool>();

            ObservableCollection <Availability> availability = new ObservableCollection<Availability>();
            //IEnumerable<JToken> documentsAv = jsonAv.SelectTokens("documents.fields").Where(s => (string)s["test"] == "test1");
            IEnumerable<JToken> documents = json.SelectTokens("documents[*]");
            IEnumerable<JToken> documentsAv = jsonAv.SelectTokens("documents[*]");

            
           /* foreach (JToken documentAv in documentsAv)
            {
                Availability availabilityTool = new Availability();
                availabilityTool.startDate = DateTime.Parse((string)documentAv.SelectToken("fields.start.timestampValue").ToString());
                availabilityTool.endDate = DateTime.Parse((string)documentAv.SelectToken("fields.end.timestampValue").ToString());
                availabilityTool.toolRef = (string)documentAv.SelectToken("fields.item.referenceValue").ToString();
                Console.WriteLine("ToolRef: " + availabilityTool.toolRef);
                availability.Add(availabilityTool);
                Console.WriteLine("WerkzeugAvail:");
                Console.WriteLine("Avail: " + availabilityTool.startDate + availabilityTool.endDate);
                Console.WriteLine("--------");
                
            }
            Console.WriteLine(availability);*/

           
            foreach (JToken document in documents)
            {
               
                Tool tool = new Tool();
                tool.ToolDescription = (string)document.SelectToken("fields.description.stringValue").ToString();
                tool.ToolLocation = (string)document.SelectToken("fields.location.stringValue").ToString();
                var dataBaseName = (string)document.SelectToken("name").ToString();
                tool.ToolDatabaseNameSub = dataBaseName.Substring(55);               
                tool.ToolPriceSpan = (string)document.SelectToken("fields.priceSpan.stringValue").ToString();
                Console.WriteLine(tool.ToolDescription + tool.ToolLocation + tool.ToolPriceSpan);
                tool.OwnerPhone = (string)document.SelectToken("fields.ownerphone.stringValue").ToString();
                Console.WriteLine(tool.ToolDescription + tool.ToolLocation + tool.ToolPriceSpan + tool.OwnerPhone);
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
                
                

                //Werkzeug objWerkzeug = new Werkzeug();
                //objWerkzeug.Description = (string) document.SelectToken("fields.description.stringValue").ToString();
                //objWerkzeug.Location = (string)document.SelectToken("fields.location.stringValue").ToString();

                //objWerkzeugliste.Add(objWerkzeug);
                toolsList.Add(tool);
                Console.WriteLine("Werkzeug:");
                Console.WriteLine(tool.ToolDescription + tool.ToolLocation);
                Console.WriteLine("--------");
                Console.WriteLine("WerkzeugName " + tool.ToolDatabaseNameSub);
            }
            // ObjWerkzeugListe = JsonConvert.DeserializeObject<WerkzeugListe>(res);
           listTools.ItemsSource = toolsList;

           /* var toolIdTest = "projects/sharezeug/databases/(default)/documents/items/zQjXZGR8xqiJK0fD2QQ2";
            var toolIdTestSub = toolIdTest.Substring(55);
            var compareTo = availability.ElementAt(0).toolRef;
            var compareToSub = toolIdTest.Substring(55);
            Console.WriteLine("compareToSub:" + compareToSub);
            var compareToFalse = availability.ElementAt(1).toolRef;
            var compareToFalseSub = compareToFalse.Substring(55);

            if (toolIdTestSub.Equals(compareToSub))
            {
                Console.WriteLine("makes sense");
            }
            if (toolIdTestSub.Equals(compareToFalseSub))
            {
                Console.WriteLine("makes no sense");
            }
            ObservableCollection<Availability> availabilityPerTool = new ObservableCollection<Availability>();

            //das erste hat ein leerzeichen vor der id, das zweite nicht, versuch drittes anlegen
            foreach (Availability av in availability)
            {
                var toolNameRef = av.toolRef;
                Console.WriteLine("toolNameRef:" +toolNameRef);
                var toolNameRefSub = toolNameRef.Substring(55);
                if (toolNameRefSub.Equals(toolIdTestSub))
                {
                    availabilityPerTool.Add(av);
                }
                else
                {
                    Console.WriteLine("no match");
                }
            }*/

            
            

        }

        private async void ListSpeakers_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var details = e.Item as Tool;
            await Navigation.PushAsync(new ToolDetailPage(details.ToolDescription, details.ToolLocation, details.CombinedPrice, details.ToolImage, details.ToolLat, details.ToolLong, details.OwnerPhone, details.ToolDatabaseNameSub, details.minDateUser, details.maxDateUser));

        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            var container = BindingContext as ToolViewModel;
            
            listTools.BeginRefresh(); 

            if (string.IsNullOrWhiteSpace(e.NewTextValue))
                listTools.ItemsSource = container.Tools;
            else
                listTools.ItemsSource = container.Tools.Where(i => i.ToolDescription.Contains(e.NewTextValue));

            listTools.EndRefresh();

        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            //Navigation.PushAsync(new GeoPage());
            Navigation.PushAsync(new MapOverviewPage(searchResults));

        }

        private void Btn_Search_Clicked(object sender, EventArgs e)
        {
            var container = BindingContext as ToolViewModel;
             searchResults =  (IEnumerable<Tool>)listTools.ItemsSource;
            string searchValueToolDescription = SfEntry_ToolType.Text ?? "";
            var searchValueToolLocation = SfEntry_ToolLocation.Text ?? "";
            
            var searchValueToolPrice = SfEntry_ToolPrice.Text ?? "";
           

            int searchValueToolPriceInt = 0;

            if (searchValueToolPrice.Equals(""))
            {
                searchResults = container.Tools.Where(i => (i.ToolDescription).Contains(searchValueToolDescription)
            && (i.ToolLocation).Contains(searchValueToolLocation));
            

            }
            else
            {
                searchValueToolPriceInt = int.Parse(searchValueToolPrice);
                searchResults = container.Tools.Where(i => (i.ToolDescription).Contains(searchValueToolDescription)
            && (i.ToolLocation).Contains(searchValueToolLocation)
            && (i.ToolPrice <= searchValueToolPriceInt));
            }


            // listTools.BeginRefresh();
            /* listTools.ItemsSource = container.Tools.Where(i => i.ToolDescription.Contains(searchValueToolDescription));

             listTools.ItemsSource = container.Tools.Where(i => i.ToolLocation.Contains(searchValueToolLocation));*/
            


            

            listTools.ItemsSource = searchResults;


             /*  listTools.ItemsSource = container.Tools.Where(i => i.ToolDescription.Contains(searchValueToolDescription)
                && i.ToolLocation.Contains(searchValueToolLocation)
                && i.ToolPrice.Contains(searchValueToolPrice));*/

            //listTools.EndRefresh();
            IsBackLayerRevealed = Convert.ToBoolean("False");
           // var count = (listTools.ItemsSource as List<Tool>).Count;
           /* if ((listTools.ItemsSource as List<Tool>).Count == 0)
            {
                Lbl_ToolSearchIntro.Text = "Unfortunatly, there were no matches";
                Lbl_ToolSearchIntro.FontSize = 18;
            }*/
            

        }

        private void Btn_DeleteEntry_Clicked(object sender, EventArgs e)
        {
            //SfEntry_ToolType.Text = "";

        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            SfEntry_ToolType.Text = "";

        }

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            SfEntry_ToolLocation.Text = "";
        }

        private void TapGestureRecognizer_Tapped_2(object sender, EventArgs e)
        {
            SfEntry_ToolPrice.Text = "";

        }
    }
}
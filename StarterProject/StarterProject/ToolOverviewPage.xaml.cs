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
            JObject json = JObject.Parse(res);
            Console.WriteLine(res);
        }

        private async void ListSpeakers_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var details = e.Item as Tool;
            await Navigation.PushAsync(new ToolDetailPage(details.ToolDescription, details.ToolLocation, details.ToolPrice, details.ToolPriceSpan, details.ToolImage, details.ToolLat, details.ToolLong, details.OwnerPhone));

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
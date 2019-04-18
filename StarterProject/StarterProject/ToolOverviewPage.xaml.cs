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

namespace StarterProject
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ToolOverviewPage : SfBackdropPage
    {

        //SpeakerViewModel vm;
        ToolViewModel tvm;
        public ToolOverviewPage ()
		{
			InitializeComponent();
            tvm = new ToolViewModel();
            //vm = new SpeakerViewModel();
            //listSpeakers.ItemsSource = vm.Speakers;
            //BindingContext = vm;
            BindingContext = tvm;
            
		}

        private async void ListSpeakers_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var details = e.Item as Tool;
            await Navigation.PushAsync(new ToolDetailPage(details.ToolDescription, details.ToolLocation, details.ToolPrice, details.ToolImage, details.ToolLat, details.ToolLong, details.OwnerPhone));

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
            Navigation.PushAsync(new MapOverviewPage());

        }

        private void Btn_Search_Clicked(object sender, EventArgs e)
        {
            var container = BindingContext as ToolViewModel;
            var searchValueToolDescription = SfEntry_ToolType.Text;
            var searchValueToolLocation = SfEntry_ToolLocation.Text;
            var searchValueToolPrice = SfEntry_ToolPrice.Text;
            

            listTools.BeginRefresh();

            
                listTools.ItemsSource = container.Tools.Where(i => i.ToolDescription.Contains(searchValueToolDescription)
                && i.ToolLocation.Contains(searchValueToolLocation)
                && i.ToolPrice.Contains(searchValueToolPrice));

            listTools.EndRefresh();
            IsBackLayerRevealed = Convert.ToBoolean("False");

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
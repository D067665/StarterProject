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

using Xamarin.Forms.Xaml;

namespace StarterProject
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ToolOverviewPage : ContentPage
	{

        //SpeakerViewModel vm;
        ToolViewModel tvm;
        public ToolOverviewPage ()
		{
			InitializeComponent ();
            tvm = new ToolViewModel();
            //vm = new SpeakerViewModel();
            //listSpeakers.ItemsSource = vm.Speakers;
            //BindingContext = vm;
            BindingContext = tvm;
            
		}

        private async void ListSpeakers_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var details = e.Item as Tool;
            await Navigation.PushAsync(new ToolDetailPage(details.ToolDescription, details.ToolLocation, details.ToolPrice, details.ToolImage));

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
    }
}
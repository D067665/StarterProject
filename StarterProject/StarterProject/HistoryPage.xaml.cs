
using Newtonsoft.Json;
using StarterProject.Model;
using StarterProject.ViewModel;
using Syncfusion.ListView.XForms;
using System;
using System.Collections.Generic;
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
        public HistoryPage ()
		{
			InitializeComponent ();
            this.On<Xamarin.Forms.PlatformConfiguration.Android>().SetIsSwipePagingEnabled(false);
            tvm = new ToolViewModel();

            BindingContext = tvm;

            


            }
        private void ListView_SwipeStarted(object sender, SwipeStartedEventArgs e)
        {
            if (e.ItemIndex == 1)
                e.Cancel = true;
        }
        private void ListView_SwipeEnded(object sender, SwipeEndedEventArgs e)
        {
            if (e.SwipeOffset > 70)
                listView.ResetSwipe();
        }

        private void ListView_Swiping(object sender, SwipingEventArgs e)
        {
            if (e.ItemIndex == 1 && e.SwipeOffSet > 70)
                e.Handled = true;
        }
    }


}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Media;



using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StarterProject
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TakePhotoPage : ContentPage
    {
        public TakePhotoPage()
        {
            InitializeComponent();
            
            
            
            

        }
        private void MainDatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
           // MainLabel.Text = e.NewDate.ToLongDateString();
        }
        private void MainDatePicker_DateSelectedEnd(object sender, DateChangedEventArgs e)
        {
            // MainLabel.Text = e.NewDate.ToLongDateString();
        }





        private async void Btn_TakePhoto_Clicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("No Camera", ":( No camera available.", "OK");
                return;
            }

            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "Sample",
                Name = "test.jpg"
            });

            if (file == null)
                return;

            await DisplayAlert("File Location", file.Path, "OK");

            image.Source = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                return stream;
            });



        }

        private void Calendar_SelectionChanged(object sender, Syncfusion.SfCalendar.XForms.SelectionChangedEventArgs e)
        {
            var range = e.NewRangeAdded;

            Console.WriteLine(range.ToList());

        }
    }
}
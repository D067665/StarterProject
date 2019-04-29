using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Media;
using Plugin.Geolocator;



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
            Picker_PriceDetail.Items.Add("per Day");
            Picker_PriceDetail.Items.Add("per Week");
            Picker_PriceDetail.Items.Add("per Month");





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

        private async void Btn_Publish_Clicked(object sender, EventArgs e)
        {
             

            
            if(string.IsNullOrEmpty(Entry_Toolname.Text) || string.IsNullOrEmpty(Entry_Toollocation.Text) || string.IsNullOrEmpty(Entry_Toolprice.Text) || string.IsNullOrEmpty(Entry_Ownerphone.Text)
                || Picker_PriceDetail.SelectedIndex == -1 || string.IsNullOrEmpty(Editor_Comments.Text)
                )
            {
                
                await DisplayAlert("Info Missing", "Please fill out the missing information", "OK");

            }else
            {
                var locator = CrossGeolocator.Current;
                locator.DesiredAccuracy = 50;
                var position = await locator.GetPositionAsync(TimeSpan.FromSeconds(1000));
                await DisplayAlert("Thank you!", "You successfully uploaded your Tool to share it with the Community." + position.Latitude + position.Longitude, "Ok");
            }
            
           

            

           /* Console.WriteLine("Lat: " + position.Latitude + "Long: " + position.Longitude);
            await DisplayAlert("Thank you!", "You successfully uploaded your Tool to share it with the Community." + position.Latitude + position.Longitude, "Ok");
            await Navigation.PushAsync(new LandingPage());*/

        }
       

        private void Btn_RemoveImage_Clicked(object sender, EventArgs e)
        {
            image.Source = "camera.PNG";
           

        }

        private void Picker_PriceDetail_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedItem = Picker_PriceDetail.Items[Picker_PriceDetail.SelectedIndex];
            

        }
    }
}
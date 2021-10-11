using System;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace XamarinLocationApp
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        //Setup geolocation https://docs.microsoft.com/en-us/xamarin/essentials/geolocation

        private async void Button_clicked(object sender, EventArgs e)
        {
            try
            {
                Location kea = new Location("Københavns Erhvervsakademi", 55.69155,12.55466);
                var location = await Geolocation.GetLastKnownLocationAsync();
                if (location == null)
                {
                    location = await Geolocation.GetLocationAsync(new GeolocationRequest()
                    {
                        DesiredAccuracy = GeolocationAccuracy.Medium,
                        Timeout = TimeSpan.FromSeconds(30)
                    });         
                }

                if (location == null)
                {
                    labelLocation.Text = "No GPS";
                }
                else
                {
                    Location currentLocation = new Location("Current location", location.Latitude, location.Longitude);
                    var distance = DistanceCalculator.Distance(currentLocation.Latitude, kea.Latitude, currentLocation.Longitude, kea.Longitude);
                    labelDistanceToKEA.Text = $"{distance} KM.";
                    if (TimeCalculator.DistanceToMinutes(distance) > 60)
                    {
                        labelTime.Text = $"{TimeCalculator.DistanceToHours(distance)} hours {TimeCalculator.ToMinutes(distance)} minutes";
                    }
                    else
                    {
                        labelTime.Text = $"{TimeCalculator.ToMinutes(distance)} minutes";
                    }

                    labelLocation.Text = $"{currentLocation.Latitude} {currentLocation.Longitude}";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something is wrong with geolocation");
            }
        }
    }
}

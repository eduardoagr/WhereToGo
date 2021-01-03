using System.Windows.Input;

using WhereToGo.Models;

using Xamarin.Essentials;
using Xamarin.Forms;

namespace WhereToGo.ViewModels {
    public class MapNavigarionVM : ViewModelBase {

        public Address SelectedItemFrom { get; set; }
        public Address SelectedItemTo { get; set; }
        public ICommand StartNavigation { get; set; }

        public MapNavigarionVM() {

            StartNavigation = new Command(async () => {

                if (Device.RuntimePlatform == Device.Android) {
                    // opens the 'task chooser' so the user can pick Maps, Chrome or other mapping app
                    await Launcher.OpenAsync($"http://maps.google.com/?daddr={SelectedItemTo.street}&saddr={SelectedItemFrom.street}&travelmode=driving");
                } else if (Device.RuntimePlatform == Device.UWP) {
                    await Launcher.OpenAsync($"bingmaps:?rtp=adr.{SelectedItemFrom.street}~adr.{SelectedItemTo.street}{GetMode(NavigationMode.Driving)}");
                }
            });
        }

        internal static string GetMode(NavigationMode mode) {
            switch (mode) {
                case NavigationMode.Driving: return "&mode=d";
                case NavigationMode.Transit: return "&mode=t";
                case NavigationMode.Walking: return "&mode=w";
            }
            return string.Empty;
        }

    }
}
using System;
using System.Linq;
using System.Threading.Tasks;

using WhereToGo.Models;

using Xamarin.Essentials;
using Xamarin.Forms;

namespace WhereToGo.ViewModels {
    public class MapNavigarionVM : ViewModelBase {


        private Address _SelectedItemFrom;
        public Address SelectedItemFrom {
            get { return _SelectedItemFrom; }
            set
            {
                if (_SelectedItemFrom != value) {
                    _SelectedItemFrom = value;
                    RaisePropertyChanged();
                    getCoordinatesAsync("from");
                }
            }
        }


        private Address _SelectedItemTo;
        public Address SelectedItemTo {
            get { return _SelectedItemTo; }
            set
            {
                if (_SelectedItemTo != value) {
                    _SelectedItemTo = value;
                    RaisePropertyChanged();
                    getCoordinatesAsync("to");
                }
            }
        }
        public MapNavigarionVM() {

            


        }

        private async void getCoordinatesAsync(string ToOrFrom) {

            try {
                if (ToOrFrom.Equals("to")) {
                    var address = $"{SelectedItemTo.street} , {SelectedItemTo.city} , {SelectedItemTo.state}";
                    var locations = await Geocoding.GetLocationsAsync(address);
                    var location = locations?.FirstOrDefault();
                    if (location != null) {
                        Console.WriteLine($"This is TO Latitude: {location.Latitude}, Longitude: {location.Longitude}");
                    }
                } else if (ToOrFrom.Equals("from")) {
                    var address = $"{SelectedItemFrom.street} , {SelectedItemFrom.city} , {SelectedItemFrom.state}";
                    var locations = await Geocoding.GetLocationsAsync(address);
                    var location = locations?.FirstOrDefault();
                    if (location != null) {
                        Console.WriteLine($" This is FROM Latitude: {location.Latitude}, Longitude: {location.Longitude}");
                    }
                }
            }catch (Exception ex) {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
        }
    }
}

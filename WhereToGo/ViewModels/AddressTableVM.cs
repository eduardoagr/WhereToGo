using System.Windows.Input;

using WhereToGo.Models;
using WhereToGo.Views;

using Xamarin.Forms;

namespace WhereToGo.ViewModels {
    public class AddressTableVM : ViewModelBase {
        public ICommand ToInputCommand { get; set; }
        public ICommand SelectedItemChanged { get; set; }

        private Address _SelectedItem;
        public Address SelectedItem {
            get { return _SelectedItem; }
            set
            {
                if (_SelectedItem != value) {
                    _SelectedItem = value;
                    RaisePropertyChanged();
                }
            }
        }
        public AddressTableVM() {

            // Here we are using a lambda, to take us to the "Input address" when we touch the button on the toolbar

            ToInputCommand = new Command(async () => {
                await Application.Current.MainPage.Navigation.PushModalAsync(new InputAddressPage());
            });

            SelectedItemChanged = new Command(async () => {

                if (SelectedItem != null) {
                    await Application.Current.MainPage.Navigation.PushAsync(new MapNavigationPage());
                    SelectedItem = null;
                }
            });
        }
    }
}

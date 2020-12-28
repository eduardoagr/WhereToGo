using System.Windows.Input;

using WhereToGo.Views;

using Xamarin.Forms;

namespace WhereToGo.ViewModels {
    public class AddressTableVM : ViewModelBase {
        public ICommand InputCommand { get; set; }
        public ICommand NavigationCommand { get; set; }

        public AddressTableVM() {

            /* Here we are using a lambda, to take us to the "Input address",
             * when we touch the button on the toolbar
             */

            InputCommand = new Command(async () => {
                await Application
                .Current.MainPage.Navigation.PushModalAsync(new InputAddressPage());
            });

            NavigationCommand = new Command(async () => {
                await Application
                .Current.MainPage.Navigation.PushAsync(new MapNavigationPage());
            });
        }
    }
}
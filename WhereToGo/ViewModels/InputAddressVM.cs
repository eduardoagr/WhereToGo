using SQLite;

using System.Diagnostics;
using System.Windows.Input;

using WhereToGo.Models;

using Xamarin.Forms;

namespace WhereToGo.ViewModels {
    public class InputAddressVM : ViewModelBase {
        public ICommand SaveCommand { get; set; }

        private Address _Address;
        public Address Address {
            get { return _Address; }
            set
            {
                if (_Address != value) {
                    _Address = value;
                    RaisePropertyChanged();
                }
            }
        }
        public InputAddressVM() {

            Address = new Address();

            SaveCommand = new Command(async () => {
                using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation)) {

                    conn.CreateTable<Address>();
                    int row = conn.Insert(Address);

                    if (row > 0) {
                        await Application.Current.MainPage.Navigation.PopModalAsync();
                    } else {
                        await Application.Current.MainPage.DisplayAlert("Error", "Something went wrong", "OK"); 
                    }
                }
            });
        }
    }
}

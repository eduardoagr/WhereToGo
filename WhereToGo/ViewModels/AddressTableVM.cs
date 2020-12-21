using SQLite;

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

using WhereToGo.Models;
using WhereToGo.Views;

using Xamarin.Forms;

namespace WhereToGo.ViewModels {
    public class AddressTableVM : ViewModelBase {
        public ICommand ToInputCommand { get; set; }
        public ICommand SelectedItemChanged { get; set; }
        public ObservableCollection<Address> MyAdresses { get; set; }

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

            GetValues();

            // Here we are using a lambda, to take us to the "Input address" when we touch the button on the toolbar

            ToInputCommand = new Command(async () => {
                await Application.Current.MainPage.Navigation.PushModalAsync(new InputAddress());
            });

            SelectedItemChanged = new Command(async () => {

                if (SelectedItem != null) {
                    await Application.Current.MainPage.DisplayAlert("HELLO", SelectedItem.street, "");
                }
            });
        }

        private void GetValues() {

            MyAdresses = new ObservableCollection<Address>();

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation)) {

                conn.CreateTable<Address>();
                List<Address> addressesList = conn.Table<Address>().ToList();

                MyAdresses.Clear();

                foreach (var item in addressesList) {
                    MyAdresses.Add(item);
                }
            }
        }
    }
}

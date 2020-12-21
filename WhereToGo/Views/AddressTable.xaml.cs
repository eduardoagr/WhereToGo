
using SQLite;

using System.Collections.Generic;
using System.Collections.ObjectModel;

using WhereToGo.Models;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WhereToGo.Views {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddressTable : ContentPage {
        public ObservableCollection<Address> addresses { get; set; }
        public AddressTable() {
            InitializeComponent();
        }
        protected override void OnAppearing() {
            base.OnAppearing();

            addresses = new ObservableCollection<Address>();

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation)) {

                conn.CreateTable<Address>();
                List<Address> addressesList = conn.Table<Address>().ToList();

                addresses.Clear();

                foreach (var item in addressesList) {
                    addresses.Add(item);
                }

                MyCollection.ItemsSource = addresses;
            }
        }
    }
}
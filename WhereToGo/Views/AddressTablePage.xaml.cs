
using SQLite;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using WhereToGo.Models;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WhereToGo.Views {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddressTablePage : ContentPage {
        public ObservableCollection<Address> MyAdresses { get; private set; }

        public AddressTablePage() {
            InitializeComponent();

            MyAdresses = new ObservableCollection<Address>();
        }

        protected override void OnAppearing() {
            base.OnAppearing();

            GetValue();
        }

        private void GetValue() {
            MyAdresses = new ObservableCollection<Address>();

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation)) {

                conn.CreateTable<Address>();
                List<Address> addressesList = conn.Table<Address>().ToList();

                MyAdresses.Clear();

                foreach (var item in addressesList) {
                    MyAdresses.Add(item);
                }

                MyCollection.ItemsSource = MyAdresses;
            }
        }
    }
}
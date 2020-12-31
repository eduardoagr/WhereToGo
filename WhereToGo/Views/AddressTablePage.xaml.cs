﻿
using SQLite;

using System.Collections.Generic;
using System.Collections.ObjectModel;

using WhereToGo.Models;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WhereToGo.Views {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddressTablePage : ContentPage {

        public ObservableCollection<Address> addresses { get; set; }
        public AddressTablePage() {
            InitializeComponent();

            MessagingCenter.Subscribe<Address>(this, "deleted", (item) => {

                addresses.Remove(item);

                using (SQLiteConnection coon = new SQLiteConnection(App.DatabaseLocation)) {

                    coon.CreateTable<Address>();
                    var selectedItem = coon.Delete(item);

                }
            });
        }
        protected override void OnAppearing() {
            MyAddressCoolecton.ItemsSource = GetData();
        }
        public ObservableCollection<Address> GetData() {

            addresses = new ObservableCollection<Address>();

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation)) {

                conn.CreateTable<Address>();
                List<Address> addressesList = conn.Table<Address>().ToList();

                addresses.Clear();

                foreach (var item in addressesList) {
                    addresses.Add(item);
                }
            }
            return addresses;
        }

        private void ToolbarItem_Clicked(object sender, System.EventArgs e) {

            ToolbarItem nameOfControl = sender as ToolbarItem;

            switch (nameOfControl.Text) {

                case "List orientation":

                    MyAddressCoolecton.ItemsLayout = new LinearItemsLayout(ItemsLayoutOrientation.Vertical);

                    break;

                case "Grid orientation":

                    MyAddressCoolecton.ItemsLayout = new GridItemsLayout(ItemsLayoutOrientation.Vertical) {

                        Span = 2,
                        HorizontalItemSpacing = 5,
                        VerticalItemSpacing = 5,
                    };

                    break;
            }
        }
    }
}

using Syncfusion.Licensing;

using WhereToGo.Views;

using Xamarin.Forms;

namespace WhereToGo {
    public partial class App : Application {

        const string KEY = "MzcxNDUxQDMxMzgyZTM0MmUzMEpDbGNMdVdzVXcwWEoreE43Q09TOUwrcTF6OWNhZzZNOU85Y2lzaTJ5T289";

        public static string DatabaseLocation = string.Empty;

        /*"string.Empty" is more efficient than doing "", because we are not allocating an memory for that empty value.
         * Since every OS has their own way of storing, I cant declare the path here, It has to be the different platforms
         */
        public App() {
            InitializeComponent();

            MainPage = new NavigationPage(new AddressTablePage());
        }

        // I will make a constructor, that will receive the path of the database
        public App(string databaseLocation) {

            SyncfusionLicenseProvider.RegisterLicense(KEY);
            InitializeComponent();

            if (string.IsNullOrEmpty(databaseLocation)) {
                Current.MainPage.DisplayAlert("Error", "Database path not found", "OK");
            }

            MainPage = new NavigationPage(new AddressTablePage());

            // Now every OS will be responsible for declaring the path for the database

            DatabaseLocation = databaseLocation;
        }


        protected override void OnStart() {
        }

        protected override void OnSleep() {
        }

        protected override void OnResume() {
        }
    }
}

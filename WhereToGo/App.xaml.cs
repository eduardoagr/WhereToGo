
using WhereToGo.Views;

using Xamarin.Forms;

namespace WhereToGo {
    public partial class App : Application {

        public static string DatabaseLocation = string.Empty;

        /*"string.Empty" is more efficient than doing "", because we are not allocating an memory for that empty value.
         * Since every OS has their own way of storing, I cant declare the path here, It has to be the different platforms
         */

        public App() {
            InitializeComponent();

            MainPage = new NavigationPage(new AddressTable());
        }

        // I will make a constructor, that will receive the path of the database
        public App(string databaseLocation) {
            InitializeComponent();

            if (string.IsNullOrEmpty(databaseLocation)) {

                throw new System.Exception("error");
            }

            MainPage = new NavigationPage(new AddressTable());

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

using System.IO;

using Windows.Storage;

namespace WhereToGo.UWP {
    public sealed partial class MainPage {
        public MainPage() {
            InitializeComponent();

            string dbName = "MyAddresses_db.sqlite";
            var FolderPath = ApplicationData.Current.LocalFolder.Path;
            string fullPath = Path.Combine(FolderPath, dbName);

            Xamarin.FormsMaps.Init(
                "Att6Bo-Uj6G05mVrJbc3t4Y06mOOsS9i_XCVH_k_dS60rZVzunQCoquHq9Svg53R");
            LoadApplication(new WhereToGo.App(fullPath));
        }
    }
}

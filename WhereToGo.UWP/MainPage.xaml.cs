using System.IO;

using Windows.Storage;

namespace WhereToGo.UWP {
    public sealed partial class MainPage {
        public MainPage() {
            InitializeComponent();

            string dbName = "MyAddresses_db.sqlite";
            var FolderPath = ApplicationData.Current.LocalFolder.Path;
            string fullPath = Path.Combine(FolderPath, dbName);

            LoadApplication(new WhereToGo.App(fullPath));
        }
    }
}

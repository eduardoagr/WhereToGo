using WhereToGo.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WhereToGo.Views {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapNavigationPage : ContentPage {
        public MapNavigationPage() {
            InitializeComponent();
        }

        protected override void OnAppearing() {
            base.OnAppearing();

            AddressTablePage tp = new AddressTablePage();

            NavigationTo.DataSource = tp.GetData();
            NavigationFrom.DataSource = tp.GetData();

           
        }
    }
}
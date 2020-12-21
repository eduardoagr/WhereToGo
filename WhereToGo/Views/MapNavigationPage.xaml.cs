using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WhereToGo.Models;
using WhereToGo.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WhereToGo.Views {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapNavigationPage : ContentPage {

        public MapNavigationVM mapNavigationVM { get; set; }
        public MapNavigationPage() {
            InitializeComponent();
        }
        public MapNavigationPage(Address address) {
            InitializeComponent();
            mapNavigationVM = new MapNavigationVM();
            BindingContext = mapNavigationVM;
            address = new Address();
        }
    }
}
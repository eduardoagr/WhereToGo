using SQLite;

using WhereToGo.ViewModels;

namespace WhereToGo.Models {
    public class Address : ViewModelBase {

        [PrimaryKey, AutoIncrement]
        public int id { get; set; }

        private string _street;
        public string street {
            get { return _street; }
            set
            {
                if (_street != value) {
                    _street = value;
                    RaisePropertyChanged();
                    Activate();
                }
            }
        }

        private string _city;
        public string city {
            get { return _city; }
            set
            {
                if (_city != value) {
                    _city = value;
                    RaisePropertyChanged();
                    Activate();
                }
            }
        }

        private string _state;
        public string state {
            get { return _state; }
            set
            {
                if (_state != value) {
                    _state = value;
                    Activate();
                    RaisePropertyChanged();
                }
            }
        }

        private string _zipCode;
        public string zipCode {
            get { return _zipCode; }
            set
            {
                if (_zipCode != value) {
                    _zipCode = value;
                    Activate();
                    RaisePropertyChanged();
                }
            }
        }
        public double Lat { get; set; }
        public double lon { get; set; }


        private bool _isEnabled;

        public Address() { }

        public bool isEnabled {
            get { return _isEnabled; }
            set
            {
                if (_isEnabled != value) {
                    _isEnabled = value;
                    RaisePropertyChanged();
                }
            }
        }

        private void Activate() {

            if (string.IsNullOrEmpty(street) ||
               string.IsNullOrEmpty(city) ||
               string.IsNullOrEmpty(state) ||
               string.IsNullOrEmpty(zipCode)) {

               isEnabled = false;
            } else {
               isEnabled = true;
            }
        }
    }
}

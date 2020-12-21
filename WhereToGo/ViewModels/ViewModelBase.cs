using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WhereToGo.ViewModels {
    public class ViewModelBase : INotifyPropertyChanged {

        // This class is useful, when I want to tell the UI to update, since it will notify everything

        #region Notify Property Changed Members
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged([CallerMemberName] string propertyName = "") {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}

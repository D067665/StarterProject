using Syncfusion.XForms.Buttons;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace StarterProject.ViewModel
{
    class ViewModel : INotifyPropertyChanged
    {
    
        private string fromText = "";
        public string FromText
        {
            get { return fromText; }
            set { fromText = value; NotifyPropertyChanged("FromText"); }
        }
        private string toText = "";
        public string ToText
        {
            get { return toText; }
            set { toText = value; NotifyPropertyChanged("ToText"); }
        }
        public ViewModel()
        {
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}

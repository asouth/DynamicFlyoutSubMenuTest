using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace DynamicFlyoutMenuTest.ViewModels
{
    public class MainViewModel : ObservableObject
    {
        public ObservableCollection<MyCustomListItem> MyCustomListItems = new ObservableCollection<MyCustomListItem>();
        public MainViewModel()
        {

        }       
    }
    public class MyCustomListItem : INotifyPropertyChanged
    {
        public MyCustomListItem()
        {

        }

        private bool _isEditing;
        public bool isEditing
        {
            get { return _isEditing; }
            set
            {
                _isEditing = value;
                NotifyPropertyChanged(this, "isEditing");
            }
        }

        private string _itemName;
        public string ItemName
        {
            get { return _itemName; }
            set
            {
                _itemName = value;
                NotifyPropertyChanged(this, "ItemName");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void NotifyPropertyChanged(object sender, string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(sender, e);
            }
        }
    }
}

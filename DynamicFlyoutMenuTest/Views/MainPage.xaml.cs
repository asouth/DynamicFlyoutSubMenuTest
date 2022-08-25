using System;
using System.Linq;

using DynamicFlyoutMenuTest.ViewModels;

using Windows.UI.Xaml.Controls;

namespace DynamicFlyoutMenuTest.Views
{
    public sealed partial class MainPage : Page
    {
        public MainViewModel ViewModel { get; } = new MainViewModel();

        public MainPage()
        {
            InitializeComponent();
        }

        private void Action1Btn_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e){ }

        private void Action2Btn_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e){ }

        private void MenuFlyout_Opening(object sender, object e)
        {
            //make MenuFlyoutSubItem list all Items in ListView except the one triggering this function
            var menuFlyout = sender as MenuFlyout;
            // get the menu list we want to add to

            MenuFlyoutSubItem menuSubItems = menuFlyout.Items.Where(x => x.Name == "SubActionsBtn").FirstOrDefault() as MenuFlyoutSubItem;

            // get the active maplayerlistitem (that triggered this menu opening event) 
            MyCustomListItem myCustomListItem = (menuFlyout.Target as Button).DataContext as MyCustomListItem;

            menuSubItems.Items.Clear();
            foreach (var targetItem in ViewModel.MyCustomListItems)
            {
                if (myCustomListItem.ItemName != targetItem.ItemName)
                {
                    var tItem = new MenuFlyoutItem();
                    tItem.Text = targetItem.ItemName.ToString();
                    //tItem.Click += new Windows.UI.Xaml.RoutedEventHandler(DoSomethingBtn_Click);
                    menuSubItems.Items.Add(tItem);
                }
            }
        }

        private void AddCustomListItemBtn_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            // Update Layer ListView
            var newItem = new MyCustomListItem();
            newItem.ItemName = "Item " + ViewModel.MyCustomListItems.Count.ToString();
            newItem.isEditing = false;
            ViewModel.MyCustomListItems.Add(newItem);
        }
    }
}

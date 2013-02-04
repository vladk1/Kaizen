using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace modelOne
{
    public partial class PivotPage1 : PhoneApplicationPage
    {
        public PivotPage1()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            string selectedIndex = "";
            if (NavigationContext.QueryString.TryGetValue("selectedItem", out selectedIndex))
            {
                detailed_page_title.Title = selectedIndex;
                // DataContext = App.ViewModel.Items[index];
            }
        }


        private void first_track_Pressed(object sender, RoutedEventArgs e)
        {
               
        }

        private void second_track_Pressed(object sender, RoutedEventArgs e)
        {

        }

        private void third_track_Pressed(object sender, RoutedEventArgs e)
        {

        }


        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            // do some stuff ...
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
            // cancel the navigation
           //e.Cancel = true;
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

namespace BacaIN
{
    public partial class HomePage : PhoneApplicationPage
    {
        // Constructor
        public HomePage()
        {
            InitializeComponent();
        }

        
        private void buttonSmart_Click(object sender, RoutedEventArgs e)
        {
            MainPage.idChannel = 1;
            System.Diagnostics.Debug.WriteLine("Button Smart CLicked");
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }

        private void buttonInspiration_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Button Inspiration CLicked");
            MainPage.idChannel = 4;
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }

        private void buttonCommunity_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Button Community CLicked");
            MainPage.idChannel = 5;
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }

        private void buttonLeisure_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Button Leisure CLicked");
            MainPage.idChannel = 3;
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }

        private void buttonMindBodySoul_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Button Mind Body Soul CLicked");
            MainPage.idChannel = 2;
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }
    }
}
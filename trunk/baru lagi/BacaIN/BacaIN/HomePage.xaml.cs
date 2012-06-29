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
using System.Windows.Controls.Primitives;

namespace BacaIN
{
    public partial class HomePage : PhoneApplicationPage
    {
        public static String channelName;
        public static int mode = 0;
        // Constructor
        public HomePage()
        {
            InitializeComponent();
        }

        private void grMindBodyClick(object sender, System.Windows.Input.GestureEventArgs e)
        {
            mode = 0;
            channelName = "Mind, Body, and Soul";
            ArticleViewModel.offset = 0;
            System.Diagnostics.Debug.WriteLine("Button Mind Body Soul CLicked");
            MainPage.idChannel = 2;
            NavigationService.Navigate(new Uri(Uri.EscapeUriString("/MainPage.xaml?page_name=Mind Body Soul"), UriKind.Relative));
        }


        private void grLeisureClick(object sender, System.Windows.Input.GestureEventArgs e)
        {
            mode = 0;
            channelName = "Leisure";
            ArticleViewModel.offset = 0;
            System.Diagnostics.Debug.WriteLine("Button Leisure CLicked");
            MainPage.idChannel = 3;
            NavigationService.Navigate(new Uri("/MainPage.xaml?page_name=Leisure", UriKind.Relative));
        }

        private void grInspirationClick(object sender, System.Windows.Input.GestureEventArgs e)
        {
            mode = 0;
            channelName = "Inspiration";
            ArticleViewModel.offset = 0;
            System.Diagnostics.Debug.WriteLine("Button Inspiration CLicked");
            MainPage.idChannel = 4;
            NavigationService.Navigate(new Uri("/MainPage.xaml?page_name=Inspiration", UriKind.Relative));
        }

        private void grCommunityClick(object sender, System.Windows.Input.GestureEventArgs e)
        {
            mode = 0;
            channelName = "Community";
            ArticleViewModel.offset = 0;
            System.Diagnostics.Debug.WriteLine("Button Community CLicked");
            MainPage.idChannel = 5;
            NavigationService.Navigate(new Uri("/MainPage.xaml?page_name=Community", UriKind.Relative));
        }

        private void grSmartClick(object sender, System.Windows.Input.GestureEventArgs e)
        {
            mode = 0;
            channelName = "Smart";
            ArticleViewModel.offset = 0;
            MainPage.idChannel = 1;
            System.Diagnostics.Debug.WriteLine("Button Smart CLicked");
            NavigationService.Navigate(new Uri("/MainPage.xaml?page_name=Smart", UriKind.Relative));
        }

        private void btnLabel_Click(object sender, EventArgs e)
        {
            Popup popup = new Popup();
            popup.Height = 300;
            popup.Width = 400;
            popup.VerticalOffset = 100;
            FilterPopUp control = new FilterPopUp();
            popup.Child = control;
            popup.IsOpen = true;

            control.btnOK.Click += (s, args) =>
            {
                mode = 1;
                popup.IsOpen = false;
                channelName = control.tbx.Text;
                ArticleViewModel.offset = 0;
                NavigationService.Navigate(new Uri("/MainPage.xaml?page_name=Label:" + channelName, UriKind.Relative));
            };

            control.btnCancel.Click += (s, args) =>
            {
                popup.IsOpen = false;
            };
        }

    }
}
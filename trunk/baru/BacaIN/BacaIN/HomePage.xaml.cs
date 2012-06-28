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

        private void grMindBodyClick(object sender, System.Windows.Input.GestureEventArgs e)
        {
            ArticleViewModel.offset = 0;
            System.Diagnostics.Debug.WriteLine("Button Mind Body Soul CLicked");
            MainPage.idChannel = 2;
            NavigationService.Navigate(new Uri("/MainPage.xaml?page_name=Mind%20Body%Soul", UriKind.Relative));
        }


        private void grLeisureClick(object sender, System.Windows.Input.GestureEventArgs e)
        {
            ArticleViewModel.offset = 0;
            System.Diagnostics.Debug.WriteLine("Button Leisure CLicked");
            MainPage.idChannel = 3;
            NavigationService.Navigate(new Uri("/MainPage.xaml?page_name=Leisure", UriKind.Relative));
        }

        private void grInspirationClick(object sender, System.Windows.Input.GestureEventArgs e)
        {
            ArticleViewModel.offset = 0;
            System.Diagnostics.Debug.WriteLine("Button Inspiration CLicked");
            MainPage.idChannel = 4;
            NavigationService.Navigate(new Uri("/MainPage.xaml?page_name=Inspiration", UriKind.Relative));
        }

        private void grCommunityClick(object sender, System.Windows.Input.GestureEventArgs e)
        {
            ArticleViewModel.offset = 0;
            System.Diagnostics.Debug.WriteLine("Button Community CLicked");
            MainPage.idChannel = 5;
            NavigationService.Navigate(new Uri("/MainPage.xamlpage_name=Community", UriKind.Relative));
        }

        private void grSmartClick(object sender, System.Windows.Input.GestureEventArgs e)
        {
            ArticleViewModel.offset = 0;
            MainPage.idChannel = 1;
            System.Diagnostics.Debug.WriteLine("Button Smart CLicked");
            NavigationService.Navigate(new Uri("/MainPage.xaml?page_name=Smart", UriKind.Relative));
        }

        private void btnLabel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("tes");
        }

    }
}
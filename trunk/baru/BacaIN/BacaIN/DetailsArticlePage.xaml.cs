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
using System.Windows.Navigation;
using Microsoft.Phone.Controls;

namespace BacaIN
{
    public partial class DetailsPage : PhoneApplicationPage
    {
        // Constructor
        public DetailsPage()
        {
            InitializeComponent();
            DataContext = App.DetailsArticle;
            this.Loaded += new RoutedEventHandler(DetailsPage_Loaded);
        }

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            base.OnBackKeyPress(e);
            //App.DetailsArticle.SelectedArticle = null;
            App.DetailsArticle.isDataLoaded = false;
        }

        

        // When page is navigated to set data context to selected item in list
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            string selectedIndex = "";
            if (NavigationContext.QueryString.TryGetValue("selectedItem", out selectedIndex))
            {
                int index = int.Parse(selectedIndex);
                //DataContext = App.ViewModel.Items[index];
            }
        }

        // Load data for the ViewModel Items
        private void DetailsPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (!App.DetailsArticle.isDataLoaded)
            {
                App.DetailsArticle.LoadData();
            }
        }

        private void btnLabel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("tes");
        }

    }
}
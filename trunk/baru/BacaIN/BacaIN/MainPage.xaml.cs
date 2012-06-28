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
    public partial class MainPage : PhoneApplicationPage
    {
        public static int idChannel;

        // Constructor
        public MainPage()
        {
            InitializeComponent();
            System.Diagnostics.Debug.WriteLine("Main Page showed");
            // Set the data context of the listbox control to the sample data
            DataContext = App.ViewModel;
            this.Loaded += new RoutedEventHandler(MainPage_Loaded);
        }

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            base.OnBackKeyPress(e);
            App.ViewModel.articleSources.Clear();
            App.ViewModel.isDataLoaded = false;
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            // Get strId
            string str = "";
            NavigationContext.QueryString.TryGetValue("page_name", out str);
            PageTitle.Text = str;
        } 

        // Handle selection changed on ListBox
        private void MainListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // If selected index is -1 (no selection) do nothing
            if (MainListBox.SelectedIndex == -1)
                return;

            // Navigate to the new page
            ArticleViewModel.show_Article = (Article) MainListBox.SelectedItem;
            NavigationService.Navigate(new Uri("/DetailsArticlePage.xaml", UriKind.Relative));

            // Reset selected index to -1 (no selection)
            MainListBox.SelectedIndex = -1;
        }

        // Load data for the ViewModel Items
        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("ee");
            if (!App.ViewModel.isDataLoaded)
            {
                App.ViewModel.LoadData();
            }
        }
    }
}
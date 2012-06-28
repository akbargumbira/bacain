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
using Newtonsoft.Json;

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
            ListTitle.Text = HomePage.channelName;
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
        private void btnShareFB_Click(object sender, EventArgs e)
        {
            var url = string.Format("/Facebook/LoginPage.xaml");

            Dispatcher.BeginInvoke(() => NavigationService.Navigate(new Uri(url, UriKind.Relative)));
        }

        private void btnLabel_Click(object sender, EventArgs e)
        {
            String hashtag = "#okebanget"; //inputUser
            String filename = "label.dat"; //FIlename artikel yang disimpan (yg punya hashtag)
            
            //Tambah hashtag ke artikel;
            App.DetailsArticle.SelectedArticle.Hashtag = hashtag;

            //Baca FIle:
            IOHandler ioHandler = new IOHandler();
            String jsonArticles = ioHandler.ReadFile(filename);

            //Deserialisasi
            Articles articles = JsonConvert.DeserializeObject<Articles>(jsonArticles);

            //Tambah artikel yang baru ditambah hashtag:
            int length = articles.articles.Length;
            articles.articles[length] = App.DetailsArticle.SelectedArticle;

            //Serialisasi
            String output = JsonConvert.SerializeObject(articles);

            //Save ke file filename
            ioHandler.SaveFile(filename, output);

        }

    }
}
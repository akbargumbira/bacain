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
using System.Windows.Controls.Primitives;

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
            Popup popup = new Popup();
            popup.Height = 300;
            popup.Width = 400;
            popup.VerticalOffset = 100;
            PopUpUserControl control = new PopUpUserControl();
            popup.Child = control;
            popup.IsOpen = true;

            control.btnOK.Click += (s, args) =>
            {
                String hashtag = control.tbx.Text; //inputUser
                String filename = "label.dat"; //FIlename artikel yang disimpan (yg punya hashtag)
                //Tambah hashtag ke artikel;
                App.DetailsArticle.SelectedArticle.Hashtag = hashtag;

                //Baca FIle:
                IOHandler ioHandler = new IOHandler();
                String jsonArticles = ioHandler.ReadFile(filename);

                //Deserialisasi
                Articles articles = JsonConvert.DeserializeObject<Articles>(jsonArticles);

                if (articles == null)
                    articles = new Articles();

                //Tambah artikel yang baru ditambah hashtag:
                articles.articles.Add(App.DetailsArticle.SelectedArticle);

                //Serialisasi
                String output = JsonConvert.SerializeObject(articles);

                //Save ke file filename
                IOHandler ioHandler2 = new IOHandler();
                ioHandler2.SaveFile(filename, output);
                MessageBox.Show("Labeled");
                popup.IsOpen = false;
            };

            control.btnCancel.Click += (s, args) =>
            {
                popup.IsOpen = false;
            };
        }

    }
}
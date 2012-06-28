using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Newtonsoft.Json;

namespace BacaIN
{
    public class Connection
    {
        public void getRSS(int channelID, int limit, int offset)
        {
            String sitename = "intisari";
            int api_version = 1;
            String out_format = "json";
            String api_key = "39f6691756a85044995feaef17efe9f6";
            String username = "imintisari";
            String password = "12tiga";
            Uri uri = new Uri("http://api.hackonten.com/" + sitename + "/" + api_version + "/subscribe/get?output=" + out_format + "&api_key=" + api_key + "&channel_id=" + channelID + "&limit=" + limit + "&offset=" + offset);
            
            WebClient wb = new WebClient();
            wb.DownloadStringCompleted += new DownloadStringCompletedEventHandler(webClient_DownloadStringCompleted);
            wb.Credentials = new NetworkCredential(username, password);
            wb.DownloadStringAsync(uri);
        }

        private void webClient_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                Deployment.Current.Dispatcher.BeginInvoke(() =>
                {
                    // Showing the exact error message is useful for debugging. In a finalized application, 
                    // output a friendly and applicable string to the user instead. 
                    //MessageBox.Show(e.Error.Message);
                });
            }
            else
            {
                // Save the feed into the State property in case the application is tombstoned. 
                // System.Diagnostics.Debug.WriteLine(e.Result);
                //System.Diagnostics.Debug.WriteLine("Channel Name:"+jsonModelResult.channel.name);
                //System.Diagnostics.Debug.WriteLine("Total Article:" + jsonModelResult.channel.total_articles);
                //Article[] articleResult = jsonModelResult.channel.article;
                //System.Diagnostics.Debug.WriteLine("Title Article 0:" + articleResult[0].title);

                JSONModel jsonModel = JsonConvert.DeserializeObject<JSONModel>(e.Result);
                JSONModelArticle[] JSONArticles = jsonModel.channel.article;
                foreach (JSONModelArticle jsonArticle in JSONArticles)
                {
                    ((App)App.Current).RootFrame.Dispatcher.BeginInvoke(new Action<Article>(item =>
                    {
                        App.ViewModel.articleSources.Add(item);
                    }), new Article
                    {
                        Title = jsonArticle.title,
                        Description = jsonArticle.description,
                        Image = jsonArticle.image.xmedium,
                        Body = jsonArticle.body,
                        Node_id = jsonArticle.node_id,
                        Published = jsonArticle.published,
                        Url = jsonArticle.url,
                        Url_alias = jsonArticle.url_alias,
                        View_count = jsonArticle.view_count
                    });
                }

            }
        }
    }
}

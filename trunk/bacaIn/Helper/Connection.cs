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

namespace bacaIn.Helper
{
    public class Connection
    {
        public void getRSS()
        {
            String sitename = "duniasoccer";
            int api_version = 1;
            String out_format = "json";
            String api_key = "bd6b7bcb3a8a78d165c2d2615f753875";
            String channel_id = "55377";
            int limit = 10;
            int offset = 0;
            String username = "imsoccer";
            String password = "12tiga";
            String result="";

            Uri uri = new Uri("http://api.hackonten.com/" + sitename + "/" + api_version + "/subscribe/get?output=" + out_format + "&api_key=" + api_key + "&channel_id=" + channel_id + "&limit=" + limit + "&offset=" + offset);
            WebClient wb = new WebClient();
            wb.DownloadStringCompleted += new DownloadStringCompletedEventHandler(webClient_DownloadStringCompleted);
            //wb.Headers[HttpRequestHeader.Authorization] = "Basic aW1zb2NjZXI6MTJ0aWdh";
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
                    MessageBox.Show(e.Error.Message);
                });
            }
            else
            {
                // Save the feed into the State property in case the application is tombstoned. 
                System.Diagnostics.Debug.WriteLine(e.Result);
            }
        }
    }
}

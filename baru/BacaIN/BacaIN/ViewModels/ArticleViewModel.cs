﻿using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using BacaIN.WindowsPhone7Unleashed;
using System.ComponentModel;
using System.Threading;

namespace BacaIN
{
    public class ArticleViewModel : ModelBase
    {
        public static Article show_Article = null;
        private string _sampleProperty = "Sample Runtime Property Value";
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding
        /// </summary>
        /// <returns></returns>
        public string SampleProperty
        {
            get
            {
                return _sampleProperty;
            }
            set
            {
                if (value != _sampleProperty)
                {
                    _sampleProperty = value;
                    OnPropertyChanged("SampleProperty");
                }
            }
        }

        public ObservableCollection<Article> articleSources { get; private set; }

        /* public ArticleViewModel()
        {
            this.articleSources = new ObservableCollection<Article>();
            this.articleSources.Add(new Article() { Node_id = 0, Title = "Tes 1", Description = "1111", Body = "111111111111", Image="../images/France.png" });
            this.articleSources.Add(new Article() { Node_id = 1, Title = "Tes 2", Description = "2222", Body = "211111111111", Image = "../images/France.png" });
            this.articleSources.Add(new Article() { Node_id = 2, Title = "Tes 3", Description = "3333", Body = "311111111111", Image = "../images/France.png" });
        } */

        public Boolean isDataLoaded = false;

        public ArticleViewModel()
        {
            this.articleSources = new ObservableCollection<Article>();

            fetchMoreDataCommand = new DelegateCommand(
                obj =>
                {
                    if (busy)
                    {
                        return;
                    }
                    Busy = true;
                    ThreadPool.QueueUserWorkItem(
                        delegate
                        {
                            Thread.Sleep(2500);
                            Deployment.Current.Dispatcher.BeginInvoke(
                                delegate
                                {
                                    LoadData();
                                    Busy = false;
                                });
                        });

                });

        }
        public static int offset = 0;
        public void LoadData()
        {
            Connection conn = new Connection();
            System.Diagnostics.Debug.WriteLine("Channel selected:" + MainPage.idChannel);
            conn.getRSS(MainPage.idChannel, 10, offset);
            offset += 10;
            this.isDataLoaded = true;
        }

        readonly DelegateCommand fetchMoreDataCommand;

        public ICommand FetchMoreDataCommand
        {
            get
            {
                return fetchMoreDataCommand;
            }
        }

        bool busy;

        public bool Busy
        {
            get
            {
                return busy;
            }
            set
            {
                if (busy == value)
                {
                    return;
                }
                busy = value;
                OnPropertyChanged("Busy");
            }
        }
    }
}

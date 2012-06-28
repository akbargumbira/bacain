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

namespace BacaIN
{
    public class OneArticleView : ModelBase
    {
        public OneArticleView()
        {
            SelectedArticle = new Article();
        }
        private Article _article;
        public Article SelectedArticle
        {
            get
            {
                return _article;
            }
            set
            {
                if (_article != value)
                {
                    _article = value;
                }
                OnPropertyChanged("SelectedArticle");
            }
        }
        public Boolean isDataLoaded = false;
        public void LoadData()
        {
            SelectedArticle = ArticleViewModel.show_Article;
            isDataLoaded = true;
        }
    }
}

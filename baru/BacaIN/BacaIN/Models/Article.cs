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
        public class Article : ModelBase
        {
            private String body;
            public string Body
            {
                get
                {
                    return body;
                }
                set
                {
                    if (this.body != value)
                    {
                        this.body = value;
                        this.OnPropertyChanged("Body");
                    }
                }
            }
            private String description;
            public string Description
            {
                get
                {
                    return description;
                }
                set
                {
                    if (this.description != value)
                    {
                        this.description = value;
                        this.OnPropertyChanged("Description");
                    }
                }
            }
            private String image;
            public String Image
            {
                get
                {
                    return image;
                }
                set
                {
                    if (this.image != value)
                    {
                        this.image = value;
                        this.OnPropertyChanged("Image");
                    }
                }
            }
            private int node_id;
            public int Node_id
            {
                get
                {
                    return node_id;
                }
                set
                {
                    if (this.node_id != value)
                    {
                        this.node_id = value;
                        this.OnPropertyChanged("Node_id");
                    }
                }
            }
            private int published;
            public int Published
            {
                get
                {
                    return published;
                }
                set
                {
                    if (this.published != value)
                    {
                        this.published = value;
                        this.OnPropertyChanged("Published");
                    }
                }
            }
            private String title;
            public String Title
            {
                get
                {
                    return title;
                }
                set
                {
                    if (this.title != value)
                    {
                        this.title = value;
                        this.OnPropertyChanged("Title");
                    }
                }
            }
            private String url;
            public String Url
            {
                get
                {
                    return url;
                }
                set
                {
                    if (this.url != value)
                    {
                        this.url = value;
                        this.OnPropertyChanged("Url");
                    }
                }
            }
            private String url_alias;
            public String Url_alias
            {
                get
                {
                    return url_alias;
                }
                set
                {
                    if (this.url_alias != value)
                    {
                        this.url_alias = value;
                        this.OnPropertyChanged("Url_alias");
                    }
                }
            }
            private int view_count;
            public int View_count
            {
                get
                {
                    return view_count;
                }
                set
                {
                    if (this.view_count != value)
                    {
                        this.view_count = value;
                        this.OnPropertyChanged("View_count");
                    }
                }
            }

            public Article()
            {
            }

            public Article(Article a)
            {
                this.title = a.title;
                this.description = a.description;
                this.body = a.body;
                this.image = a.image;
                this.node_id = a.node_id;
                this.published = a.published;
                this.url = a.url;
                this.view_count = a.view_count;
            }
        }
}

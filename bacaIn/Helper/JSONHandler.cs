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
using bacaIn.Model;
using Newtonsoft.Json;

namespace bacaIn.Helper
{
    public class JSONHandler
    {
        public Channel Deserialize(String JSON)
        {
            return JsonConvert.DeserializeObject<Channel>(JSON);
        }

        public String Serialize(Channel Object)
        {
            return JsonConvert.SerializeObject(Object);
        }
    }
}

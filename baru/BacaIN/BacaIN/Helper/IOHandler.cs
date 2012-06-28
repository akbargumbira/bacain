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
using System.IO;
using System.IO.IsolatedStorage;

namespace BacaIN
{
    public class IOHandler
    {
        public void SaveFile(String Filename, String FileContent)
        {
            IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication();

            //create new file
            using (StreamWriter writeFile = new StreamWriter(new IsolatedStorageFileStream(Filename, FileMode.Create, FileAccess.Write, myIsolatedStorage)))
            {
                writeFile.WriteLine(FileContent);
                writeFile.Close();
            }
        }

        public String ReadFile(String Filename)
        {
            IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication();
            IsolatedStorageFileStream fileStream = myIsolatedStorage.OpenFile(Filename, FileMode.Open, FileAccess.Read);
            using (StreamReader reader = new StreamReader(fileStream))
            {
                return reader.ReadLine();
            }
        }
    }
}

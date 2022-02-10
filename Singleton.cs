using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;

namespace KalkulatorSingleton
{
    class Singleton
    {
        private static Singleton _instance;
        private Singleton() { }

        private static readonly object _lock = new object();

        public static Singleton getInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new Singleton();
                    }
                }
            }
            return _instance;
        }

        private string path = @"C:\Users\tomek\source\repos\KalkulatorSingleton\KalkulatorSingleton\log.txt";

        public async void Write(string writeValue)
        {
            using (StreamWriter writer = File.CreateText(path))
            {
                await writer.WriteAsync(writeValue);
            }
        }

        public void WriteToFile(string str)
        {
            using(StreamWriter fw = File.AppendText(path))
            {
                fw.WriteLine(str);
                fw.Close();
            }
        }

        public void ReadFromFile(RichTextBox LogDisplay)
        {
            if(File.Exists(path)&&new FileInfo(path).Length > 0)
            {
                string tmp = File.ReadAllText(path);
                LogDisplay.Document.Blocks.Clear();
                LogDisplay.Document.Blocks.Add(new Paragraph(new Run(tmp)));
                
            }
        }
    }
}

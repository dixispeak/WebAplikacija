using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace WebAplikacija.Models
{
    public class PirkiniuSarasas
    {
        private Dictionary<int, string> pirkiniuDictionary = new Dictionary<int, string>();

        public Dictionary<int, string> PirkiniuDictionary { get; set; }

        public string Name { get; set; }
        public decimal Price { get; set; }

        public Dictionary<int, string> ReadDocument()
        {
            Dictionary<int, string> dictionary = new Dictionary<int, string>();

            string path = @"C:\Users\Monika\Desktop\Test.txt";
            if (!File.Exists(path))
            {
                return null;
            }
            else
            {
                StreamReader file = new StreamReader(path);
                using (file)
                {
                    string line;
                    while ((line = file.ReadLine()) != null)
                    {
                        string[] dictionaryparts = line.Split('$');
                        int count = Convert.ToInt32(dictionaryparts[0]);
                        string nameprice =dictionaryparts[1];
                        dictionary.Add(count, nameprice);
                    }
                }
                return dictionary;
            }
        }

        public void WriteToDocument(string name, decimal price)
        {
            decimal _price = Math.Round(price, 2);

            string path = @"C:\Users\Monika\Desktop\Test.txt";
            if (!File.Exists(path))
            {
                using (File.Create(path)) ;
            }
            var lineCount = File.ReadLines(path).Count();

            StreamWriter file = new StreamWriter(path, true);
            using (file)
            {
                file.WriteLine((lineCount + 1) + "$" + name + " - " + string.Format("{0:0.00}", _price) + "Lt");
            }
        }
    }
}
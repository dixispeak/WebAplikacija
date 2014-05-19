using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace WebAplikacija.Models
{
    public class PirkiniuSarasas
    {
        private Dictionary<string, decimal> pirkiniuDictionary = new Dictionary<string, decimal>();

        public Dictionary<string, decimal> PirkiniuDictionary { get; set; }

        public string Name { get; set; }
        public decimal Price { get; set; }

        public Dictionary<string, decimal> ReadDocument()
        {
            Dictionary<string, decimal> dictionary = new Dictionary<string, decimal>();

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
                        string name = dictionaryparts[0];
                        decimal price = Convert.ToDecimal(dictionaryparts[1]);
                        dictionary.Add(name, price);
                    }
                }
                return dictionary;
            }
        }

        public void WriteToDocument(string name, decimal price)
        {
            string path = @"C:\Users\Monika\Desktop\Test.txt";
            if (!File.Exists(path))
            {
                using (File.Create(path)) ;
            }
            StreamWriter file = new StreamWriter(path, true);
            using (file)
            {
                file.WriteLine(name + "$ " + price);
            }
        }
    }
}
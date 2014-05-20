using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace WebAplikacija.Models
{
    public class PirkiniuSarasas
    {
        public Pirkinys Pirkinys {get; set;}
        public Dictionary<int, Pirkinys> PirkiniuDictionary { get; set; }

        //private Dictionary<int, Pirkinys> pirkiniuDictionary = new Dictionary<int, Pirkinys>();
        //private Pirkinys pirkinys = new Pirkinys();

        public void ReadDocument()
        {
            string path = @"C:\Users\Monika\Desktop\Test.txt";
            if (!File.Exists(path))
            {
                using (File.Create(path));
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
                        Pirkinys _pirkinys = new Pirkinys();
                        _pirkinys.Name = dictionaryparts[1];
                        _pirkinys.Price = Convert.ToDecimal(dictionaryparts[2]);
                        PirkiniuDictionary.Add(count, _pirkinys);
                    }
                }
            }
        }

        public void WriteToDocument(string name, decimal price)
        {
            decimal _price = Math.Round(price, 2);

            string path = @"C:\Users\Monika\Desktop\Test.txt";
            
            var lineCount = File.ReadLines(path).Count();

            StreamWriter file = new StreamWriter(path, true);
            using (file)
            {
                file.WriteLine((lineCount + 1) + "$" + name + "$" + string.Format("{0:0.00}", _price));
            }
        }

        //public void Delete {
    }
}
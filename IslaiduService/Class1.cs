using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IslaiduService
{
    public class Class1
    {
        public Dictionary<int, Pirkinys> ReadDocument()
        {
            Dictionary<int, Pirkinys> _pirkiniuDictionary = new Dictionary<int, Pirkinys>();

            string path = @"C:\Users\Monika\Desktop\Test.txt";
            if (!File.Exists(path))
            {
                using (File.Create(path)) ;
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
                        Pirkinys _pirkinys = new Pirkinys();
                        _pirkinys.Name = dictionaryparts[1];
                        _pirkinys.Price = Convert.ToDecimal(dictionaryparts[2]);
                        _pirkiniuDictionary.Add(count, _pirkinys);
                    }
                }
                return _pirkiniuDictionary;
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

        public void Delete(int id)
        {
            Dictionary<int, Pirkinys> _pirkiniuDictionary = new Dictionary<int, Pirkinys>();
            _pirkiniuDictionary = ReadDocument();
            _pirkiniuDictionary.Remove(id);

            string path = @"C:\Users\Monika\Desktop\Test.txt";

            int lineCount = _pirkiniuDictionary.Count;
            if (lineCount != 0)
            {
                StreamWriter file = new StreamWriter(path, false);
                using (file)
                {
                    lineCount = 0;
                    foreach (var el in _pirkiniuDictionary)
                    {
                        file.WriteLine((lineCount + 1) + "$" + el.Value.Name + "$" + el.Value.Price);
                    }
                }
            }
            else
            {
                StreamWriter file = new StreamWriter(path, false);
                file.Close();
            }
        }
    }
}

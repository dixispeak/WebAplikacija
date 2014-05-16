using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace WebAplikacija.Models
{
    public class Pirkiniai
    {
        public string Name {  get; set; }
        public List<string> PirkiniuSarasas { get; set; }

        public void WriteToDocument(string name)
        {
            string path = @"C:\Users\Monika\Desktop\Test.txt";
            if(!File.Exists(path)) 
            {
                using (File.Create(path));
            } 
            StreamWriter file = new StreamWriter(path, true);
            using (file)
            {
                file.WriteLine(name);
            }
        }

        public List<string> ReadDocument()
        {
            List<string> list = new List<string>();

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
                        list.Add(line);
                    }
                }
                return list;
            }
        }
    }
}
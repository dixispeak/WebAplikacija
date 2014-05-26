using DataService.Klases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Interface
{
    public interface IIslaiduInterface
    {
        public Dictionary<int, Pirkinys> ReadDocument();
        public void WriteToDocument(string name, decimal price);
        public void Delete(int id);

    }
}

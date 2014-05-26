using DataService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Klases
{
    class PirkiniuSarasas : IIslaiduInterface
    {
        public Dictionary<int, Pirkinys> ReadDocument()
        {
            throw new NotImplementedException();
        }

        public void WriteToDocument(string name, decimal price)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}

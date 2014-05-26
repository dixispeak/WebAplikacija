using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpendingsBL.Entities;
using SpendingsBL.Interfaces;

namespace SpendingsBL.Services
{
    public class SpendingsService : ISpendingsService
    {

        public Dictionary<int, PurchaseEntity> GetSpendings()
        {
            Dictionary<int, PurchaseEntity> purchaseDictionary = new Dictionary<int, PurchaseEntity>();

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
                        PurchaseEntity purchase = new PurchaseEntity();
                        purchase.Name = dictionaryparts[1];
                        purchase.Price = Convert.ToDecimal(dictionaryparts[2]);
                        purchaseDictionary.Add(count, purchase);
                    }
                }
                return purchaseDictionary;
            }
        }

        public void DeleteSpending(int id)
        {
            Dictionary<int, PurchaseEntity> purchaseDictionary = new Dictionary<int, PurchaseEntity>();
            purchaseDictionary = GetSpendings();
            purchaseDictionary.Remove(id);

            string path = @"C:\Users\Monika\Desktop\Test.txt";

            int lineCount = purchaseDictionary.Count;
            if (lineCount != 0)
            {
                StreamWriter file = new StreamWriter(path, false);
                using (file)
                {
                    lineCount = 0;
                    foreach (var el in purchaseDictionary)
                    {
                        file.WriteLine((lineCount + 1) + "$" + el.Value.Name + "$" + el.Value.Price);
                        lineCount++;
                    }
                }
            }
            else
            {
                StreamWriter file = new StreamWriter(path, false);
                file.Close();
            }
        }

        public void AddSpending(string name, decimal price)
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
    }
}

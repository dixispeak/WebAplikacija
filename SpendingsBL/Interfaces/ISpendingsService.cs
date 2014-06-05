using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpendingsBL.Entities;
using SpendingsDAL;

namespace SpendingsBL.Interfaces
{
    public interface ISpendingsService
    {
        List<Purchase> GetSpendings();
        void DeleteSpending(int id);
        void AddSpending(Purchase purchase);
        void EditSpendings(Purchase purchase);
        Purchase FindSpending(int id);
    }
}

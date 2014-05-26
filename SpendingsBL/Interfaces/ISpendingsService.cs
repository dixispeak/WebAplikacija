using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpendingsBL.Entities;

namespace SpendingsBL.Interfaces
{
    public interface ISpendingsService
    {
        Dictionary<int, PurchaseEntity> GetSpendings();
        void DeleteSpending(int id);
        void AddSpending(string name, decimal price);

    }
}

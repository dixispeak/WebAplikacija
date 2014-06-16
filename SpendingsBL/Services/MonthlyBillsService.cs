using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpendingsBL.Interfaces;
using SpendingsDAL;

namespace SpendingsBL.Services
{
    public class MonthlyBillsService : IMonthlyBillsService
    {
        private MonthlyBillsEntities monthlyBillsContext = new MonthlyBillsEntities();

        public List<MonthlyBill> GetMonthlyBills()
        {
            List<MonthlyBill> monthlyBillsList = monthlyBillsContext.MonthlyBills.ToList();

            return monthlyBillsList;
        }

        public void DeleteBill(int id)
        {
            MonthlyBill bill = FindBill(id);

            monthlyBillsContext.MonthlyBills.Remove(bill);

            monthlyBillsContext.SaveChanges();
        }

        public void AddBill(MonthlyBill bill)
        {
            monthlyBillsContext.MonthlyBills.Add(bill);
            monthlyBillsContext.SaveChanges();
        }

        public void EditBill(MonthlyBill bill)
        {
            monthlyBillsContext.Entry(bill).State = EntityState.Modified;
            monthlyBillsContext.SaveChanges();
        }

        public MonthlyBill FindBill(int id)
        {
            MonthlyBill bill = monthlyBillsContext.MonthlyBills.Find(id);
            return bill;
        }


        public bool IsPayedBill(int id, DateTime time)
        {
            MonthlyBill bill = monthlyBillsContext.MonthlyBills.Find(id);
            bool isDone = false;

            foreach (PayedBillsMonth payedBillMonth in bill.PayedBillsMonths)
            {
                if (payedBillMonth.PayedBillMonth == time)
                {
                    isDone = true;
                }
            }
            return isDone;
        }

        public List<MonthlyBill> GetNotPayedMonthlyBills(DateTime time)
        {
            List<MonthlyBill> monthlyBillsList = GetMonthlyBills();
            List<MonthlyBill> notPayedMonthlyBillsList = new List<MonthlyBill>();

            foreach (MonthlyBill monthlyBill in monthlyBillsList)
            {
                if (monthlyBill.PayedBillsMonths.Count != 0)
                {
                    foreach (PayedBillsMonth payedBillMonth in monthlyBill.PayedBillsMonths)
                    {
                        if (payedBillMonth.PayedBillMonth != time)
                        {
                            notPayedMonthlyBillsList.Add(monthlyBill);
                        }
                    }
                }
                else
                {
                    notPayedMonthlyBillsList.Add(monthlyBill);
                }
            }

            return notPayedMonthlyBillsList;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpendingsBL.Entities
{
    public class MonthlyBillEntity
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public bool IsDone { get; set; }
    }
}

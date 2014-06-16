using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SpendingsBL.Entities
{
    public class MonthlyBillEntity
    {
        public int BillDescriptionID { get; set; }
        public string BillDescription { get; set; }

        public virtual ICollection<PayedBillsMonthEntity> PayedBillsMonths { get; set; }
    }

     public partial class PayedBillsMonthEntity
    {
        public int PayedBillMonthID { get; set; }
        public int BillDescriptionID { get; set; }
        public Nullable<System.DateTime> PayedBillMonth { get; set; }
    }
}

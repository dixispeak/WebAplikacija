//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SpendingsDAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class MonthlyBill
    {
        public MonthlyBill()
        {
            this.PayedBillsMonths = new HashSet<PayedBillsMonth>();
        }
    
        public int BillDescriptionID { get; set; }
        public string BillDescription { get; set; }
    
        public virtual ICollection<PayedBillsMonth> PayedBillsMonths { get; set; }
    }
}

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
    
    public partial class PayedBillsMonth
    {
        public int PayedBillMonthID { get; set; }
        public int BillDescriptionID { get; set; }
        public Nullable<System.DateTime> PayedBillMonth { get; set; }
    
        public virtual MonthlyBill MonthlyBill { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace WebAplikacija.ViewModels
{
	public class MonthlyBillViewModel
	{
		public int BillId { get; set; }
		public string BillDescription { get; set; }

		public virtual ICollection<PayedBillsMonthViewModel> PayedBillsMonths { get; set; }
	}

	public class PayedBillsMonthViewModel
	{
		public int PayedBillMonthId { get; set; }
		public int BillId { get; set; }
		public DateTime? PayedBillMonth { get; set; }
	}
}
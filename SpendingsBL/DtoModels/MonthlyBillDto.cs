using System;
using System.Collections.Generic;
namespace SpendingsBL.DtoModels
{
	public class MonthlyBillDto
	{
		public int BillId { get; set; }
		public string BillDescription { get; set; }

		public virtual ICollection<PayedBillsMonthDto> PayedBillsMonths { get; set; }
	}

	public class PayedBillsMonthDto
	{
		public int PayedBillMonthId { get; set; }
		public int BillId { get; set; }
		public DateTime? PayedBillMonth { get; set; }
	}
}

using System.Collections.Generic;

namespace WebAplikacija.ViewModels
{
	public class PurchasesViewModel
	{
		public PurchaseViewModel Purchase { get; set; }
		public List<PurchaseViewModel> PurchasesList { get; set; }
	}

	public class PurchaseViewModel
	{
		public int PurchaseId { get; set; }
		public string Name { get; set; }
		public decimal Price { get; set; }
	}
}
using System.Collections.Generic;
using SpendingsBL.DtoModels;

namespace SpendingsBL.Services.Interfaces
{
    public interface ISpendingsService
    {
		IEnumerable<PurchaseDto> GetAllSpendings();
        void DeleteSpending(int id);
		void AddSpending(PurchaseDto purchasesDto);
		void UpdateSpending(PurchaseDto purchasesDto);
		PurchaseDto GetById(int id);
    }
}

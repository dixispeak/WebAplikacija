using System.Collections.Generic;
using System.Linq;
using DomainModel;
using SpendingsBL.DtoModels;
using SpendingsBL.Services.Interfaces;
using SpendingsDAL.Repositories.EntitiesRepositories;

namespace SpendingsBL.Services
{
    public class SpendingsService : ISpendingsService
    {
		private readonly IPurchaseRepository _purchaseRepository;

	    public SpendingsService()
	    {
			_purchaseRepository = new PurchaseRepository();	
	    }
		public IEnumerable<PurchaseDto> GetAllSpendings()
        {
			var purchasesEntities = _purchaseRepository.GetAll().ToList();

			return purchasesEntities.Select(purchaseEntity => new PurchaseDto
			{
				PurchaseId = purchaseEntity.PurchaseId, Name = purchaseEntity.Name, Price = purchaseEntity.Price
			});
        }

        public void DeleteSpending(int id)
        {
			_purchaseRepository.Delete(id);
        }

		public void AddSpending(PurchaseDto purchasesDto)
		{
			var purchaseEntity = new Purchase
			{
				Name = purchasesDto.Name,
				Price = purchasesDto.Price
			};
			_purchaseRepository.Add(purchaseEntity);
        }

		public void UpdateSpending(PurchaseDto purchasesDto)
        {
			var purchaseEntity = new Purchase
			{
				PurchaseId = purchasesDto.PurchaseId,
				Name = purchasesDto.Name,
				Price = purchasesDto.Price
			};
			_purchaseRepository.Update(purchaseEntity);
        }

		public PurchaseDto GetById(int id)
		{
			var purchaseEntity = _purchaseRepository.GetById(id);
			var purchaseDto = new PurchaseDto
			{
				PurchaseId = purchaseEntity.PurchaseId,
				Name = purchaseEntity.Name,
				Price = purchaseEntity.Price
			};
            return purchaseDto;
        }
    }
}

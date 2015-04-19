using DomainModel;

namespace SpendingsDAL.Repositories.EntitiesRepositories
{
	public interface IPurchaseRepository : IRepository<Purchase>
	{
	}

	public class PurchaseRepository : Repository<Purchase>, IPurchaseRepository
	{
	}
}

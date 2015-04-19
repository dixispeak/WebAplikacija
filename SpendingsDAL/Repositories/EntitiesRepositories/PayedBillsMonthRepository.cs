using DomainModel;

namespace SpendingsDAL.Repositories.EntitiesRepositories
{
	public interface IPayedBillsMonthRepository : IRepository<PayedBillsMonth>
	{
	}

	public class PayedBilldMonthRepository : Repository<PayedBillsMonth>, IPayedBillsMonthRepository
	{
	}
}

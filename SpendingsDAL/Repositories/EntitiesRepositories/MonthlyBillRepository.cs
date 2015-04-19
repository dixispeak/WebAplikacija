using DomainModel;

namespace SpendingsDAL.Repositories.EntitiesRepositories
{
	public interface IMonthlyBillRepository: IRepository<MonthlyBill>
	{
	}

	public class MonthlyBillRepository : Repository<MonthlyBill>, IMonthlyBillRepository
	{
	}
}

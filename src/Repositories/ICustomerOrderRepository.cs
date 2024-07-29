using System.Linq.Expressions;
using KanzwayCron.Data.Entities;

namespace KanzwayCron.Repositories;

public interface ICustomerOrderRepository
{
    IEnumerable<CustomerOrder> GetCustomerOrders(Expression<Func<CustomerOrder, bool>> predicate);

    void UpdateCustomerOrders(IEnumerable<CustomerOrder> customerOrders);
}
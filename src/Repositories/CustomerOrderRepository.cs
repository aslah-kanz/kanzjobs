using System.Linq.Expressions;
using KanzwayCron.Data.Context;
using KanzwayCron.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace KanzwayCron.Repositories;

public class CustomerOrderRepository(KanzDbContext kanzDb) : ICustomerOrderRepository
{
    private readonly KanzDbContext _kanzDb = kanzDb;

    public IEnumerable<CustomerOrder> GetCustomerOrders(Expression<Func<CustomerOrder, bool>> predicate)
    {
        var result = _kanzDb.CustomerOrders.Where(predicate).ToList();
        return result;
    }

    public void UpdateCustomerOrders(IEnumerable<CustomerOrder> customerOrders)
    {
        if (customerOrders == null || !customerOrders.Any()) return;
        
        foreach (var customerOrder in customerOrders)
        {
            _kanzDb.Entry(customerOrder).CurrentValues.SetValues(customerOrder);
        }

        _kanzDb.SaveChanges();
    }
}
using System.Linq.Expressions;
using KanzwayCron.Data.Context;
using KanzwayCron.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.SqlClient;

namespace KanzwayCron.Repositories
{
    public class CustomerOrderRepository : ICustomerOrderRepository
    {
        private readonly KanzDbContext _kanzDb;

        public CustomerOrderRepository(KanzDbContext kanzDb)
        {
            _kanzDb = kanzDb;
        }

        public IEnumerable<CustomerOrder> GetCustomerOrders(Expression<Func<CustomerOrder, bool>> predicate)
        {
            return _kanzDb.CustomerOrders.Where(predicate).ToList();
        }

        public void UpdateCustomerOrders(IEnumerable<CustomerOrder> customerOrders)
        {
            if (customerOrders == null || !customerOrders.Any()) return;

            foreach (var customerOrder in customerOrders)
            {
                var sql = "UPDATE [Transaction].[CustomerOrder] " +
                          "SET [Status] = @status, [UpdatedAt] = @updatedAt " +
                          "WHERE [Id] = @id";

                _kanzDb.Database.ExecuteSqlRaw(sql,
                    new SqlParameter("@status", customerOrder.Status),
                    new SqlParameter("@updatedAt", customerOrder.UpdatedAt),
                    new SqlParameter("@id", customerOrder.Id));
            }
        }
    }
}

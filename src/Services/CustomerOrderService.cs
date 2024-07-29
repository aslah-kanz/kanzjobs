
using KanzwayCron.Constants;
using KanzwayCron.Models;
using KanzwayCron.Repositories;
using Microsoft.EntityFrameworkCore;

namespace KanzwayCron.Services;

public class CustomerOrderService(
    ICustomerOrderRepository customerOrderRepository,
    IConfiguration configuration,
    IHttpRequestRepository httpRequestRepository
    ) : ICustomerOrderService
{
    private readonly ICustomerOrderRepository _customerOrderRepository = customerOrderRepository;
    
    private readonly IHttpRequestRepository _httpRequestRepository = httpRequestRepository;

    private readonly int _expireInHours = configuration.GetValue<int>("KanzwaySetting:ExpirePendingPaymentInHours");

    public void CleanupExpiredPendingPayments()
    {
        var expiredPayments = _customerOrderRepository
            .GetCustomerOrders(p => p.Status == CustomerOrderStatus.InPayment && EF.Functions.DateDiffHour(p.CreatedAt, DateTime.UtcNow) > _expireInHours);
        
        if (!expiredPayments.Any()) return;

        foreach (var expired in expiredPayments)
        {
            expired.Status = CustomerOrderStatus.Canceled;
            expired.UpdatedAt = DateTime.UtcNow;
        }

        _customerOrderRepository.UpdateCustomerOrders(expiredPayments);
    }

    public void SendPendingPaymentNotification()
    {
        var pendingPayments = _customerOrderRepository
            .GetCustomerOrders(p => p.Status == CustomerOrderStatus.InPayment && EF.Functions.DateDiffHour(p.CreatedAt, DateTime.UtcNow) < _expireInHours);

        if (!pendingPayments.Any()) return;

        var pendingPaymentsPayload = pendingPayments.Select(p => new PendingPaymentItem
        {
            CustomerOrderId = p.Id,
            CustomerPrincipalId = p.PrincipalId
        }).ToList();

        var request = new PendingPaymentRequest
        {
            CustomerOrders = pendingPaymentsPayload
        };

        _httpRequestRepository.Post(request);
    }
}
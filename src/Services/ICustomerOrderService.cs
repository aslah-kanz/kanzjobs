namespace KanzwayCron.Services;

public interface ICustomerOrderService
{
    void SendPendingPaymentNotification();

    void CleanupExpiredPendingPayments();
}
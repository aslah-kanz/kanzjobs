using Hangfire;
using KanzwayCron.Services;
using Microsoft.Extensions.DependencyInjection;

namespace KanzwayCron.Jobs;

public class KanzwayRecurrentJob(WebApplication? app)
{
    public void SetupJobs()
    {
        if (app == null) return;
        using var scope = app.Services.CreateScope();

        var customerOrderService = scope.ServiceProvider.GetRequiredService<ICustomerOrderService>();

        var recurringJobManager = scope.ServiceProvider.GetRequiredService<IRecurringJobManager>();

        var configuration = scope.ServiceProvider.GetRequiredService<IConfiguration>();

        var cronCleanupMinute = configuration.GetValue<int>("KanzwaySetting:CronCleanupMinute");

        var cronPendingPayment = configuration.GetValue<int>("KanzwaySetting:CronPendingPayment");

        var cronCleanupFormatted = $"*/{cronCleanupMinute} * * * *";

        var cronPendingPaymentFormatted = $"*/{cronPendingPayment} * * * *";

        recurringJobManager.AddOrUpdate("Cleanup", () => customerOrderService.CleanupExpiredPendingPayments(), cronCleanupFormatted);
        recurringJobManager.AddOrUpdate("PendingPayments", () => customerOrderService.SendPendingPaymentNotification(), cronPendingPaymentFormatted);
    }
}
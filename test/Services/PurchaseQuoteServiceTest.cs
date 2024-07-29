using System.Linq;
using System.Linq.Expressions;
using System.Text.Json;
using KanzwayCron.Constants;
using KanzwayCron.Data.Entities;
using KanzwayCron.Models;
using KanzwayCron.Repositories;
using KanzwayCron.Services;
using Microsoft.Extensions.Configuration;
using Moq;
using Xunit;

namespace KanzwayCron.Test.Services;

public class PurchaseQuoteServiceTest
{
    private readonly Mock<ICustomerOrderRepository> _purchaseQuoteRepository = new();
    private readonly Mock<IHttpRequestRepository> _httpRequestRepository = new();

    [Fact]
    public void CleanupExpiredPendingPayments_ShouldUpdateStatusAndUpdatedAt()
    {
        // Arrange
        var inMemory = new List<KeyValuePair<string, string>>()
        {
            new("KanzwaySetting:ExpirePendingPaymentInHours", "24")
        };

        IConfiguration _configuration = new ConfigurationBuilder().AddInMemoryCollection(inMemory!).Build();

        var now =  new DateTime(2024, 1, 1, 2, 0, 0);

        var datetime = new DateTime(2024, 1, 2, 0, 0, 0);

        var expiredPendingPayments = new List<CustomerOrder>
        {
            new()
            {
                Id = Guid.NewGuid(),
                Status = CustomerOrderStatus.InPayment,
                CreatedAt = now,
                UpdatedAt = now
            },
            new()
            {
                Id = Guid.NewGuid(),
                Status = CustomerOrderStatus.InPayment,
                CreatedAt = now,
                UpdatedAt = now
            }
        };

        _purchaseQuoteRepository.Setup(x => x.GetCustomerOrders(
            It.IsAny<Expression<Func<CustomerOrder, bool>>>()
        ))
        .Returns(expiredPendingPayments);

        var resultService = new List<CustomerOrder>();
        _purchaseQuoteRepository
            .Setup(x => 
                x.UpdateCustomerOrders(It.IsAny<IEnumerable<CustomerOrder>>()))
                .Callback<IEnumerable<CustomerOrder>>((quotes) =>
                {
                    resultService = quotes.ToList();
                });

        var service = new CustomerOrderService(_purchaseQuoteRepository.Object, _configuration, _httpRequestRepository.Object);

        // Act
        service.CleanupExpiredPendingPayments();

        // Assert
        Assert.All(resultService, q => Assert.Equal(CustomerOrderStatus.Canceled, q.Status));
        Assert.All(resultService, q => Assert.NotEqual(now, q.UpdatedAt));
    }

    [Fact]
    public void CleanupExpiredPendingPayments_ShouldDoNothingIfRepoReturnNull()
    {
        // Arrange
        var inMemory = new List<KeyValuePair<string, string>>()
        {
            new("KanzwaySetting:ExpirePendingPaymentInHours", "24")
        };

        IConfiguration _configuration = new ConfigurationBuilder().AddInMemoryCollection(inMemory!).Build();

        _purchaseQuoteRepository.Setup(x => x.GetCustomerOrders(
            It.IsAny<Expression<Func<CustomerOrder, bool>>>()
        )).Returns([]);
        var service = new CustomerOrderService(_purchaseQuoteRepository.Object, _configuration, _httpRequestRepository.Object);
        
        var datetime = DateTime.UtcNow;

        // Act
        service.CleanupExpiredPendingPayments();
        
        // Assert
        _purchaseQuoteRepository.Verify(x => x.UpdateCustomerOrders(It.IsAny<IEnumerable<CustomerOrder>>()), Times.Never);
    }

    [Fact]
    public void SendPendingPaymentNotification_ShouldSendIfRepoReturnsNotNull()
    {
        // Arrange
        var now =  new DateTime(2024, 1, 1, 2, 0, 0);

        var pendingPayments = new List<CustomerOrder>
        {
            new()
            {
                Id = Guid.NewGuid(),
                Status = CustomerOrderStatus.InPayment,
                CreatedAt = now,
                UpdatedAt = now,
                PrincipalId = 1
            },
            new()
            {
                Id = Guid.NewGuid(),
                Status = CustomerOrderStatus.InPayment,
                CreatedAt = now,
                UpdatedAt = now,
                PrincipalId = 2
            }
        };

        var inMemory = new List<KeyValuePair<string, string>>()
        {
            new("KanzwaySetting:ExpirePendingPaymentInHours", "24")
        };

        IConfiguration _configuration = new ConfigurationBuilder().AddInMemoryCollection(inMemory!).Build();
        
        _purchaseQuoteRepository.Setup(x => x.GetCustomerOrders(
            It.IsAny<Expression<Func<CustomerOrder, bool>>>()
        ))
        .Returns(pendingPayments);

        var service = new CustomerOrderService(_purchaseQuoteRepository.Object, _configuration, _httpRequestRepository.Object);
        
        object? jsonObject = null;

        _httpRequestRepository.Setup(x => x.Post(It.IsAny<object>()))
            .Callback<object>((obj) => {
                jsonObject = obj;
            });

        // Act
        service.SendPendingPaymentNotification();

        // Assert
        _httpRequestRepository.Verify(_ => _.Post(It.IsAny<object>()), Times.Once());

        var payload = jsonObject as PendingPaymentRequest;
        
        Assert.Equal(2, payload!.CustomerOrders!.Count);
    }

    [Fact]
    public void SendPendingPaymentNotification_ShouldNotSendIfRepoReturnsNull()
    {
        // Arrange
        var inMemory = new List<KeyValuePair<string, string>>()
        {
            new("KanzwaySetting:ExpirePendingPaymentInHours", "24")
        };

        IConfiguration _configuration = new ConfigurationBuilder().AddInMemoryCollection(inMemory!).Build();
        
        _purchaseQuoteRepository.Setup(x => x.GetCustomerOrders(
            It.IsAny<Expression<Func<CustomerOrder, bool>>>()
        ))
        .Returns([]);

        var service = new CustomerOrderService(_purchaseQuoteRepository.Object, _configuration, _httpRequestRepository.Object);

        // Act
        service.SendPendingPaymentNotification();

        // Assert
        _httpRequestRepository.Verify(_ => _.Post(It.IsAny<object>()), Times.Never);
    }
}
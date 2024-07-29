using System;
using System.Collections.Generic;

namespace KanzwayCron.Data.Entities;

public partial class CustomerOrder
{
    public Guid Id { get; set; }

    public string? Code { get; set; }

    public string? InvoiceNumber { get; set; }

    public string? PaymentTrackId { get; set; }

    public string? PaymentTransactionId { get; set; }

    public int PrincipalId { get; set; }

    public int? PrincipalDetailId { get; set; }

    public int AddressId { get; set; }

    public int? PaymentMethodId { get; set; }

    public decimal SubTotal { get; set; }

    public string? PromoCode { get; set; }

    public decimal? DiscountPrice { get; set; }

    public decimal GrandTotal { get; set; }

    public string Status { get; set; } = null!;

    public int HiglightedProductId { get; set; }

    public int? DeliveryOptionId { get; set; }

    public decimal? EstimatedDeliveryCost { get; set; }

    public string DeliveryOptions { get; set; } = null!;

    public string? Comment { get; set; }

    public DateTime CreatedAt { get; set; }

    public int CreatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public int UpdatedBy { get; set; }

    public virtual PrincipalAddress Address { get; set; } = null!;

    public virtual ICollection<CustomerOrderItem> CustomerOrderItems { get; set; } = new List<CustomerOrderItem>();

    public virtual Product HiglightedProduct { get; set; } = null!;

    public virtual PaymentMethod? PaymentMethod { get; set; }

    public virtual Principal Principal { get; set; } = null!;

    public virtual PrincipalDetail? PrincipalDetail { get; set; }

    public virtual ICollection<PurchaseQuote> PurchaseQuotes { get; set; } = new List<PurchaseQuote>();

    public virtual ICollection<Shipping> Shippings { get; set; } = new List<Shipping>();

    public virtual ICollection<StoreOrder> StoreOrders { get; set; } = new List<StoreOrder>();
}

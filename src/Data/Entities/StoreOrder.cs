using System;
using System.Collections.Generic;

namespace KanzwayCron.Data.Entities;

public partial class StoreOrder
{
    public Guid Id { get; set; }

    public string InvoiceNumber { get; set; } = null!;

    public int? DeliveryId { get; set; }

    public Guid CustomerOrderId { get; set; }

    public int StoreId { get; set; }

    public int? PackageCount { get; set; }

    public decimal DeliveryCost { get; set; }

    public int ProductCount { get; set; }

    public DateTime CreatedAt { get; set; }

    public int CreatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public int UpdatedBy { get; set; }

    public string PurchaseQuoteStatus { get; set; } = null!;

    public virtual CustomerOrder CustomerOrder { get; set; } = null!;

    public virtual ICollection<PurchaseQuote> PurchaseQuotes { get; set; } = new List<PurchaseQuote>();

    public virtual Store Store { get; set; } = null!;
}

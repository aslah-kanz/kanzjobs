using System;
using System.Collections.Generic;

namespace KanzwayCron.Data.Entities;

public partial class CustomerOrderItem
{
    public Guid Id { get; set; }

    public Guid CustomerOrderId { get; set; }

    public int? CartId { get; set; }

    public int ProductId { get; set; }

    public int Quantity { get; set; }

    public decimal? Price { get; set; }

    public decimal SubTotal { get; set; }

    public string? Comment { get; set; }

    public string? Status { get; set; }

    public DateTime CreatedAt { get; set; }

    public int CreatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public int UpdatedBy { get; set; }

    public virtual CustomerOrder CustomerOrder { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;

    public virtual ICollection<PurchaseQuote> PurchaseQuotes { get; set; } = new List<PurchaseQuote>();
}

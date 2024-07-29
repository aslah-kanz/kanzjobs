using System;
using System.Collections.Generic;

namespace KanzwayCron.Data.Entities;

public partial class PurchaseQuote
{
    public Guid Id { get; set; }

    public string? Code { get; set; }

    public string? VendorSku { get; set; }

    public Guid CustomerOrderId { get; set; }

    public Guid CustomerOrderItemId { get; set; }

    public Guid StoreOrderId { get; set; }

    public int? CartId { get; set; }

    public long? SaleItemId { get; set; }

    public int StoreId { get; set; }

    public int ProductId { get; set; }

    public int RequestedQuantity { get; set; }

    public int? ConfirmedQuantity { get; set; }

    public int TotalRequestedQuantity { get; set; }

    public decimal Price { get; set; }

    public decimal? MinPrice { get; set; }

    public decimal? MaxPrice { get; set; }

    public decimal? DiscountPrice { get; set; }

    public int Stock { get; set; }

    public int? MinOrderQuantity { get; set; }

    public int? MaxOrderQuantity { get; set; }

    public decimal? SubTotal { get; set; }

    public decimal? Tax { get; set; }

    public decimal? PlatformCommission { get; set; }

    public string? Comment { get; set; }

    public string Status { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public int CreatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public int UpdatedBy { get; set; }

    public virtual CustomerOrder CustomerOrder { get; set; } = null!;

    public virtual CustomerOrderItem CustomerOrderItem { get; set; } = null!;

    public virtual ICollection<Exchange> Exchanges { get; set; } = new List<Exchange>();

    public virtual Product Product { get; set; } = null!;

    public virtual ICollection<ProductReview> ProductReviews { get; set; } = new List<ProductReview>();

    public virtual ICollection<Refund> Refunds { get; set; } = new List<Refund>();

    public virtual Store Store { get; set; } = null!;

    public virtual StoreOrder StoreOrder { get; set; } = null!;
}

using System;
using System.Collections.Generic;

namespace KanzwayCron.Data.Entities;

public partial class Refund
{
    public Guid Id { get; set; }

    public string? Number { get; set; }

    public Guid PurchaseQuoteId { get; set; }

    public int ProductId { get; set; }

    public int StoreId { get; set; }

    public int PrincipalId { get; set; }

    public int? PrincipalDetailId { get; set; }

    public int Quantity { get; set; }

    public decimal? Price { get; set; }

    public decimal SubTotal { get; set; }

    public string? Status { get; set; }

    public string? AdminComment { get; set; }

    public string? VendorComment { get; set; }

    public string? Comment { get; set; }

    public DateTime CreatedAt { get; set; }

    public int CreatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public int UpdatedBy { get; set; }

    public virtual Principal Principal { get; set; } = null!;

    public virtual PrincipalDetail? PrincipalDetail { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual PurchaseQuote PurchaseQuote { get; set; } = null!;

    public virtual Store Store { get; set; } = null!;

    public virtual ICollection<Image> Images { get; set; } = new List<Image>();
}

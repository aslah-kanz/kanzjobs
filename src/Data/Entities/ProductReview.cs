using System;
using System.Collections.Generic;

namespace KanzwayCron.Data.Entities;

public partial class ProductReview
{
    public Guid Id { get; set; }

    public string? Code { get; set; }

    public int ProductId { get; set; }

    public int PrincipalId { get; set; }

    public Guid PurchaseQuoteId { get; set; }

    public int? Rating { get; set; }

    public string? Comment { get; set; }

    public DateTime CreatedAt { get; set; }

    public int CreatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public int UpdatedBy { get; set; }

    public virtual Principal Principal { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;

    public virtual PurchaseQuote PurchaseQuote { get; set; } = null!;

    public virtual ICollection<Image> Images { get; set; } = new List<Image>();
}

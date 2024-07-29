using System;
using System.Collections.Generic;

namespace KanzwayCron.Data.Entities;

public partial class Cart
{
    public int Id { get; set; }

    public int PrincipalId { get; set; }

    public int ProductId { get; set; }

    public decimal Price { get; set; }

    public int Quantity { get; set; }

    public int Stock { get; set; }

    public string? Comment { get; set; }

    public DateTime CreatedAt { get; set; }

    public int CreatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public int UpdatedBy { get; set; }

    public virtual ICollection<CartSaleItem> CartSaleItems { get; set; } = new List<CartSaleItem>();

    public virtual Principal Principal { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}

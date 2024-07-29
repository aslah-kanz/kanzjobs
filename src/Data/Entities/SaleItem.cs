using System;
using System.Collections.Generic;

namespace KanzwayCron.Data.Entities;

public partial class SaleItem
{
    public long Id { get; set; }

    public string? Code { get; set; }

    public int ProductId { get; set; }

    public string? VendorSku { get; set; }

    public string? BcId { get; set; }

    public int Stock { get; set; }

    public int ReservedStock { get; set; }

    public decimal? MinPrice { get; set; }

    public decimal? MaxPrice { get; set; }

    public decimal? DiscountPrice { get; set; }

    public decimal Price { get; set; }

    public decimal? OriginalPrice { get; set; }

    public int? MinOrderQuantity { get; set; }

    public int? MaxOrderQuantity { get; set; }

    public int StoreId { get; set; }

    public bool Enabled { get; set; }

    public string Status { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public int CreatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public int UpdatedBy { get; set; }

    public virtual ICollection<CartSaleItem> CartSaleItems { get; set; } = new List<CartSaleItem>();

    public virtual Product Product { get; set; } = null!;

    public virtual Store Store { get; set; } = null!;
}

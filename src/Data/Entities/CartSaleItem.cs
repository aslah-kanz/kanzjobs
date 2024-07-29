using System;
using System.Collections.Generic;

namespace KanzwayCron.Data.Entities;

public partial class CartSaleItem
{
    public int Id { get; set; }

    public int CartId { get; set; }

    public long SaleItemId { get; set; }

    public int StoreId { get; set; }

    public int ProductId { get; set; }

    public decimal? MinPrice { get; set; }

    public decimal? MaxPrice { get; set; }

    public decimal? DiscountPrice { get; set; }

    public int Stock { get; set; }

    public int? MinOrderQuantity { get; set; }

    public int? MaxOrderQuantity { get; set; }

    public string? VendorSku { get; set; }

    public DateTime CreatedAt { get; set; }

    public int CreatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public int UpdatedBy { get; set; }

    public virtual Cart Cart { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;

    public virtual SaleItem SaleItem { get; set; } = null!;

    public virtual Store Store { get; set; } = null!;
}

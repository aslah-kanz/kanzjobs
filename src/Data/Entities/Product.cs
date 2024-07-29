using System;
using System.Collections.Generic;

namespace KanzwayCron.Data.Entities;

public partial class Product
{
    public int Id { get; set; }

    public string? Code { get; set; }

    public string? Mpn { get; set; }

    public string? Slug { get; set; }

    public string? FamilyCode { get; set; }

    public string? GroupCode { get; set; }

    public long? IconId { get; set; }

    public long? ImageId { get; set; }

    public int BrandId { get; set; }

    public int? PrincipalDetailId { get; set; }

    public double Length { get; set; }

    public double Width { get; set; }

    public double Height { get; set; }

    public double Weight { get; set; }

    public string? MetaKeyword { get; set; }

    public string? MetaDescription { get; set; }

    public decimal? OriginalPrice { get; set; }

    public decimal? LowestPrice { get; set; }

    public decimal? HighestPrice { get; set; }

    public bool Sellable { get; set; }

    public string Status { get; set; } = null!;

    public string? Comment { get; set; }

    public int? SortOrder { get; set; }

    public DateTime CreatedAt { get; set; }

    public int CreatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public int UpdatedBy { get; set; }

    public string? Description { get; set; }

    public string? Gtin { get; set; }

    public string Name { get; set; } = null!;

    public virtual Brand Brand { get; set; } = null!;

    public virtual ICollection<CartSaleItem> CartSaleItems { get; set; } = new List<CartSaleItem>();

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual ICollection<CustomerOrderItem> CustomerOrderItems { get; set; } = new List<CustomerOrderItem>();

    public virtual ICollection<CustomerOrder> CustomerOrders { get; set; } = new List<CustomerOrder>();

    public virtual ICollection<Exchange> Exchanges { get; set; } = new List<Exchange>();

    public virtual Image? Icon { get; set; }

    public virtual Image? Image { get; set; }

    public virtual ICollection<Inquiry> Inquiries { get; set; } = new List<Inquiry>();

    public virtual PrincipalDetail? PrincipalDetail { get; set; }

    public virtual ICollection<ProductAttribute> ProductAttributes { get; set; } = new List<ProductAttribute>();

    public virtual ICollection<ProductImage> ProductImages { get; set; } = new List<ProductImage>();

    public virtual ICollection<ProductReview> ProductReviews { get; set; } = new List<ProductReview>();

    public virtual ICollection<PurchaseQuote> PurchaseQuotes { get; set; } = new List<PurchaseQuote>();

    public virtual ICollection<Refund> Refunds { get; set; } = new List<Refund>();

    public virtual ICollection<SaleItem> SaleItems { get; set; } = new List<SaleItem>();

    public virtual ICollection<WishList> WishLists { get; set; } = new List<WishList>();

    public virtual ICollection<Category> Categories { get; set; } = new List<Category>();
}

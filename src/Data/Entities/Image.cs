using System;
using System.Collections.Generic;

namespace KanzwayCron.Data.Entities;

public partial class Image
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public string Url { get; set; } = null!;

    public int Width { get; set; }

    public int Height { get; set; }

    public string Type { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public int CreatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public int UpdatedBy { get; set; }

    public virtual ICollection<Banner> Banners { get; set; } = new List<Banner>();

    public virtual ICollection<Blog> Blogs { get; set; } = new List<Blog>();

    public virtual ICollection<Brand> BrandBwImages { get; set; } = new List<Brand>();

    public virtual ICollection<Brand> BrandImages { get; set; } = new List<Brand>();

    public virtual ICollection<Catalogue> Catalogues { get; set; } = new List<Catalogue>();

    public virtual ICollection<Category> Categories { get; set; } = new List<Category>();

    public virtual ICollection<Certificate> Certificates { get; set; } = new List<Certificate>();

    public virtual ICollection<Country> Countries { get; set; } = new List<Country>();

    public virtual ICollection<Language> Languages { get; set; } = new List<Language>();

    public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();

    public virtual ICollection<PaymentMethod> PaymentMethodImageArs { get; set; } = new List<PaymentMethod>();

    public virtual ICollection<PaymentMethod> PaymentMethodImages { get; set; } = new List<PaymentMethod>();

    public virtual ICollection<Principal> Principals { get; set; } = new List<Principal>();

    public virtual ICollection<ProductAttribute> ProductAttributes { get; set; } = new List<ProductAttribute>();

    public virtual ICollection<Product> ProductIcons { get; set; } = new List<Product>();

    public virtual ICollection<Product> ProductImages { get; set; } = new List<Product>();

    public virtual ICollection<ProductImage> ProductImagesNavigation { get; set; } = new List<ProductImage>();

    public virtual ICollection<WebPage> WebPages { get; set; } = new List<WebPage>();

    public virtual ICollection<WebsiteProfile> WebsiteProfileFavicons { get; set; } = new List<WebsiteProfile>();

    public virtual ICollection<WebsiteProfile> WebsiteProfileImages { get; set; } = new List<WebsiteProfile>();

    public virtual ICollection<Withdraw> Withdraws { get; set; } = new List<Withdraw>();

    public virtual ICollection<Exchange> Exchanges { get; set; } = new List<Exchange>();

    public virtual ICollection<ProductReview> ProductReviews { get; set; } = new List<ProductReview>();

    public virtual ICollection<Refund> Refunds { get; set; } = new List<Refund>();
}

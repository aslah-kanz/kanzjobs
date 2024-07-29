using System;
using System.Collections.Generic;

namespace KanzwayCron.Data.Entities;

public partial class Category
{
    public int Id { get; set; }

    public int? ParentId { get; set; }

    public string? Code { get; set; }

    public string Slug { get; set; } = null!;

    public long? ImageId { get; set; }

    public string? MetaKeyword { get; set; }

    public string? MetaDescription { get; set; }

    public bool ShowAtHomePage { get; set; }

    public string Status { get; set; } = null!;

    public string Path { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public int CreatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public int UpdatedBy { get; set; }

    public string? Description { get; set; }

    public string Name { get; set; } = null!;

    public virtual Image? Image { get; set; }

    public virtual ICollection<Category> InverseParent { get; set; } = new List<Category>();

    public virtual Category? Parent { get; set; }

    public virtual ICollection<Brand> Brands { get; set; } = new List<Brand>();

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}

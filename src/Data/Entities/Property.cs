using System;
using System.Collections.Generic;

namespace KanzwayCron.Data.Entities;

public partial class Property
{
    public int Id { get; set; }

    public string? Code { get; set; }

    public string NameEn { get; set; } = null!;

    public string? NameAr { get; set; }

    public string FieldsEn { get; set; } = null!;

    public string FieldsAr { get; set; } = null!;

    public string Type { get; set; } = null!;

    public int? SortOrder { get; set; }

    public DateTime CreatedAt { get; set; }

    public int CreatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public int UpdatedBy { get; set; }

    public virtual ICollection<ProductAttribute> ProductAttributes { get; set; } = new List<ProductAttribute>();
}

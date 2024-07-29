using System;
using System.Collections.Generic;

namespace KanzwayCron.Data.Entities;

public partial class Attribute
{
    public int Id { get; set; }

    public int SortOrder { get; set; }

    public int GroupOrder { get; set; }

    public DateTime CreatedAt { get; set; }

    public int CreatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public int UpdatedBy { get; set; }

    public string GroupEn { get; set; } = null!;

    public string? Code { get; set; }

    public string? GroupAr { get; set; }

    public string? NameAr { get; set; }

    public string NameEn { get; set; } = null!;

    public string? Unit1Ar { get; set; }

    public string? Unit1En { get; set; }

    public string? Unit2Ar { get; set; }

    public string? Unit2En { get; set; }

    public string? Unit3Ar { get; set; }

    public string? Unit3En { get; set; }

    public virtual ICollection<ProductAttribute> ProductAttributes { get; set; } = new List<ProductAttribute>();
}

using System;
using System.Collections.Generic;

namespace KanzwayCron.Data.Entities;

public partial class ProductAttributeBackupfromDev
{
    public Guid Id { get; set; }

    public int ProductId { get; set; }

    public int PropertyId { get; set; }

    public int AttributeId { get; set; }

    public string? Value1En { get; set; }

    public string? Value1Ar { get; set; }

    public string? Value2En { get; set; }

    public string? Value2Ar { get; set; }

    public string? Value3En { get; set; }

    public string? Value3Ar { get; set; }

    public long? ImageId { get; set; }

    public DateTime CreatedAt { get; set; }

    public int CreatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public int UpdatedBy { get; set; }
}

using System;
using System.Collections.Generic;

namespace KanzwayCron.Data.Entities;

public partial class ProductProductproperty
{
    public long? ProductId { get; set; }

    public string? Type { get; set; }

    public string? Fields { get; set; }

    public string? Name { get; set; }

    public string? NameEn { get; set; }

    public long? SortOrder { get; set; }

    public DateTime? CreatedAt { get; set; }

    public long? CreatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public long? UpdatedBy { get; set; }
}

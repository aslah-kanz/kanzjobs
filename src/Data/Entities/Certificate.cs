using System;
using System.Collections.Generic;

namespace KanzwayCron.Data.Entities;

public partial class Certificate
{
    public int Id { get; set; }

    public string? Code { get; set; }

    public string? Slug { get; set; }

    public long? ImageId { get; set; }

    public string Status { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public int CreatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public int UpdatedBy { get; set; }

    public string Title { get; set; } = null!;

    public virtual Image? Image { get; set; }
}

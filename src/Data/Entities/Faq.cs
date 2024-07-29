using System;
using System.Collections.Generic;

namespace KanzwayCron.Data.Entities;

public partial class Faq
{
    public int Id { get; set; }

    public string? Code { get; set; }

    public int FaqGroupId { get; set; }

    public string Status { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public int CreatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public int UpdatedBy { get; set; }

    public string? Answer { get; set; }

    public string Question { get; set; } = null!;

    public virtual FaqGroup FaqGroup { get; set; } = null!;
}

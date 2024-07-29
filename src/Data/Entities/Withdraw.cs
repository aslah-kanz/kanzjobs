using System;
using System.Collections.Generic;

namespace KanzwayCron.Data.Entities;

public partial class Withdraw
{
    public int Id { get; set; }

    public int PrincipalId { get; set; }

    public long? ImageId { get; set; }

    public decimal? Amount { get; set; }

    public string? Comment { get; set; }

    public string Status { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public int CreatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public int UpdatedBy { get; set; }

    public virtual Image? Image { get; set; }

    public virtual Principal Principal { get; set; } = null!;
}

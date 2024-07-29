using System;
using System.Collections.Generic;

namespace KanzwayCron.Data.Entities;

public partial class Notification
{
    public Guid Id { get; set; }

    public int PrincipalId { get; set; }

    public string Title { get; set; } = null!;

    public string Message { get; set; } = null!;

    public string? MessageArgs { get; set; }

    public long? ImageId { get; set; }

    public string? Type { get; set; }

    public string? ReferenceId { get; set; }

    public DateTime? ReadAt { get; set; }

    public DateTime CreatedAt { get; set; }

    public int CreatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public int UpdatedBy { get; set; }

    public virtual Image? Image { get; set; }

    public virtual Principal Principal { get; set; } = null!;
}

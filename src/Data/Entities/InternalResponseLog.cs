using System;
using System.Collections.Generic;

namespace KanzwayCron.Data.Entities;

public partial class InternalResponseLog
{
    public long Id { get; set; }

    public long? RequestId { get; set; }

    public string Headers { get; set; } = null!;

    public string? Content { get; set; }

    public DateTime CreatedAt { get; set; }

    public int CreatedBy { get; set; }
}

using System;
using System.Collections.Generic;

namespace KanzwayCron.Data.Entities;

public partial class InternalRequestLog
{
    public long Id { get; set; }

    public string Method { get; set; } = null!;

    public string Path { get; set; } = null!;

    public string? QueryString { get; set; }

    public string Headers { get; set; } = null!;

    public string? Content { get; set; }

    public DateTime CreatedAt { get; set; }

    public int CreatedBy { get; set; }
}

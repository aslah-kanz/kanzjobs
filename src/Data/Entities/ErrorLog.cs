using System;
using System.Collections.Generic;

namespace KanzwayCron.Data.Entities;

public partial class ErrorLog
{
    public long Id { get; set; }

    public string Type { get; set; } = null!;

    public string? Message { get; set; }

    public string Details { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public int CreatedBy { get; set; }
}

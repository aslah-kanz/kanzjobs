using System;
using System.Collections.Generic;

namespace KanzwayCron.Data.Entities;

public partial class Subscriber
{
    public int Id { get; set; }

    public string? Code { get; set; }

    public string Email { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public int CreatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public int UpdatedBy { get; set; }
}

using System;
using System.Collections.Generic;

namespace KanzwayCron.Data.Entities;

public partial class JobField
{
    public int Id { get; set; }

    public string? Code { get; set; }

    public DateTime CreatedAt { get; set; }

    public int CreatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public int UpdatedBy { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Job> Jobs { get; set; } = new List<Job>();
}

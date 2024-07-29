using System;
using System.Collections.Generic;

namespace KanzwayCron.Data.Entities;

public partial class JobApplicant
{
    public int Id { get; set; }

    public string? Code { get; set; }

    public int JobId { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public long? DocumentId { get; set; }

    public string Status { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public int CreatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public int UpdatedBy { get; set; }

    public virtual Document? Document { get; set; }

    public virtual Job Job { get; set; } = null!;
}

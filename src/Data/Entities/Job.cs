using System;
using System.Collections.Generic;

namespace KanzwayCron.Data.Entities;

public partial class Job
{
    public int Id { get; set; }

    public string? Code { get; set; }

    public string? Slug { get; set; }

    public string? Requirement { get; set; }

    public int JobFieldId { get; set; }

    public string Status { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public int CreatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public int UpdatedBy { get; set; }

    public string Experience { get; set; } = null!;

    public string JobLocation { get; set; } = null!;

    public string JobType { get; set; } = null!;

    public string Responsibility { get; set; } = null!;

    public string Title { get; set; } = null!;

    public virtual ICollection<JobApplicant> JobApplicants { get; set; } = new List<JobApplicant>();

    public virtual JobField JobField { get; set; } = null!;
}

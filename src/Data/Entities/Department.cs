using System;
using System.Collections.Generic;

namespace KanzwayCron.Data.Entities;

public partial class Department
{
    public int Id { get; set; }

    public int PrincipalDetailId { get; set; }

    public string? Code { get; set; }

    public string Name { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public int CreatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public int UpdatedBy { get; set; }

    public virtual PrincipalDetail PrincipalDetail { get; set; } = null!;

    public virtual ICollection<Principal> Principals { get; set; } = new List<Principal>();
}

using System;
using System.Collections.Generic;

namespace KanzwayCron.Data.Entities;

public partial class Role
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public int CreatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public int UpdatedBy { get; set; }

    public virtual ICollection<Principal> Principals { get; set; } = new List<Principal>();

    public virtual ICollection<Privilege> Privileges { get; set; } = new List<Privilege>();
}

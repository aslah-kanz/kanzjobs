using System;
using System.Collections.Generic;

namespace KanzwayCron.Data.Entities;

public partial class Privilege
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public int CreatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public int UpdatedBy { get; set; }

    public virtual ICollection<Role> Roles { get; set; } = new List<Role>();
}

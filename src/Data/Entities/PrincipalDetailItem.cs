using System;
using System.Collections.Generic;

namespace KanzwayCron.Data.Entities;

public partial class PrincipalDetailItem
{
    public int Id { get; set; }

    public int PrincipalDetailId { get; set; }

    public string Description { get; set; } = null!;

    public string Value { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public int CreatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public int UpdatedBy { get; set; }

    public virtual PrincipalDetail PrincipalDetail { get; set; } = null!;
}

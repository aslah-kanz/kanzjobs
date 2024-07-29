using System;
using System.Collections.Generic;

namespace KanzwayCron.Data.Entities;

public partial class Currency
{
    public int Id { get; set; }

    public string Code { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Country { get; set; } = null!;

    public string Symbol { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public int CreatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public int UpdatedBy { get; set; }

    public virtual ICollection<PrincipalBank> PrincipalBanks { get; set; } = new List<PrincipalBank>();
}

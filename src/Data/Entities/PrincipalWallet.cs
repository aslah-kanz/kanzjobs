using System;
using System.Collections.Generic;

namespace KanzwayCron.Data.Entities;

public partial class PrincipalWallet
{
    public int Id { get; set; }

    public string? Code { get; set; }

    public int PrincipalId { get; set; }

    public string Type { get; set; } = null!;

    public string? ReferenceId { get; set; }

    public decimal? Amount { get; set; }

    public DateTime CreatedAt { get; set; }

    public int CreatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public int UpdatedBy { get; set; }

    public virtual Principal Principal { get; set; } = null!;
}

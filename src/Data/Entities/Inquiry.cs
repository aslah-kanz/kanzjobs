using System;
using System.Collections.Generic;

namespace KanzwayCron.Data.Entities;

public partial class Inquiry
{
    public int Id { get; set; }

    public int PrincipalId { get; set; }

    public int ProductId { get; set; }

    public decimal? TotalPrice { get; set; }

    public int Quantity { get; set; }

    public string? Comment { get; set; }

    public string? Status { get; set; }

    public DateTime CreatedAt { get; set; }

    public int CreatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public int UpdatedBy { get; set; }

    public virtual Principal Principal { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}

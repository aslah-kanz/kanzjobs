using System;
using System.Collections.Generic;

namespace KanzwayCron.Data.Entities;

public partial class ShippingMethod
{
    public int Id { get; set; }

    public string? Code { get; set; }

    public string ProviderName { get; set; } = null!;

    public string DeliveryCompanyName { get; set; } = null!;

    public string DeliveryEstimateTime { get; set; } = null!;

    public string? Detail { get; set; }

    public DateTime CreatedAt { get; set; }

    public int CreatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public int UpdatedBy { get; set; }

    public virtual ICollection<Shipping> Shippings { get; set; } = new List<Shipping>();
}

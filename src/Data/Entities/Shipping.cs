using System;
using System.Collections.Generic;

namespace KanzwayCron.Data.Entities;

public partial class Shipping
{
    public Guid Id { get; set; }

    public Guid CustomerOrderId { get; set; }

    public int ShippingMethodId { get; set; }

    public decimal Cost { get; set; }

    public DateTime CreatedAt { get; set; }

    public int CreatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public int UpdatedBy { get; set; }

    public virtual CustomerOrder CustomerOrder { get; set; } = null!;

    public virtual ShippingMethod ShippingMethod { get; set; } = null!;
}

using System;
using System.Collections.Generic;

namespace KanzwayCron.Data.Entities;

public partial class PaymentMethod
{
    public int Id { get; set; }

    public string? Code { get; set; }

    public long? ImageId { get; set; }

    public long? ImageArId { get; set; }

    public DateTime CreatedAt { get; set; }

    public int CreatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public int UpdatedBy { get; set; }

    public string? Description { get; set; }

    public string? Instruction { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<CustomerOrder> CustomerOrders { get; set; } = new List<CustomerOrder>();

    public virtual Image? Image { get; set; }

    public virtual Image? ImageAr { get; set; }
}

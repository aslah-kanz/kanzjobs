using System;
using System.Collections.Generic;

namespace KanzwayCron.Data.Entities;

public partial class PrincipalAddress
{
    public int Id { get; set; }

    public string? Code { get; set; }

    public int PrincipalId { get; set; }

    public string Name { get; set; } = null!;

    public string RecipientName { get; set; } = null!;

    public string? CountryCode { get; set; }

    public string? PhoneNumber { get; set; }

    public string Address { get; set; } = null!;

    public string City { get; set; } = null!;

    public string Country { get; set; } = null!;

    public decimal Latitude { get; set; }

    public decimal Longitude { get; set; }

    public bool DefaultAddress { get; set; }

    public DateTime CreatedAt { get; set; }

    public int CreatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public int UpdatedBy { get; set; }

    public virtual ICollection<CustomerOrder> CustomerOrders { get; set; } = new List<CustomerOrder>();

    public virtual Principal Principal { get; set; } = null!;
}

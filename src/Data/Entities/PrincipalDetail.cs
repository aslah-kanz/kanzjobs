using System;
using System.Collections.Generic;

namespace KanzwayCron.Data.Entities;

public partial class PrincipalDetail
{
    public int Id { get; set; }

    public int PrincipalId { get; set; }

    public int CountryId { get; set; }

    public string City { get; set; } = null!;

    public string CompanyNumber { get; set; } = null!;

    public string CompanyNameEn { get; set; } = null!;

    public string CompanyNameAr { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public int CreatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public int UpdatedBy { get; set; }

    public virtual Country Country { get; set; } = null!;

    public virtual ICollection<CustomerOrder> CustomerOrders { get; set; } = new List<CustomerOrder>();

    public virtual ICollection<Department> Departments { get; set; } = new List<Department>();

    public virtual ICollection<Exchange> Exchanges { get; set; } = new List<Exchange>();

    public virtual ICollection<PrincipalDetailItem> PrincipalDetailItems { get; set; } = new List<PrincipalDetailItem>();

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    public virtual ICollection<Refund> Refunds { get; set; } = new List<Refund>();

    public virtual ICollection<Principal> Principals { get; set; } = new List<Principal>();
}

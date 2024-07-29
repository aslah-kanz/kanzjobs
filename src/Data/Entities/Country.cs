using System;
using System.Collections.Generic;

namespace KanzwayCron.Data.Entities;

public partial class Country
{
    public int Id { get; set; }

    public string Code { get; set; } = null!;

    public int PhoneCode { get; set; }

    public int PhoneStartNumber { get; set; }

    public int PhoneMinLength { get; set; }

    public int PhoneMaxLength { get; set; }

    public long? ImageId { get; set; }

    public DateTime CreatedAt { get; set; }

    public int CreatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public int UpdatedBy { get; set; }

    public string Name { get; set; } = null!;

    public virtual Image? Image { get; set; }

    public virtual ICollection<PrincipalDetail> PrincipalDetails { get; set; } = new List<PrincipalDetail>();
}

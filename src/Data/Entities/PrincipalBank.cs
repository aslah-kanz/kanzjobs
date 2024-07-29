using System;
using System.Collections.Generic;

namespace KanzwayCron.Data.Entities;

public partial class PrincipalBank
{
    public int Id { get; set; }

    public string? Code { get; set; }

    public int PrincipalId { get; set; }

    public long? DocumentId { get; set; }

    public int? CurrencyId { get; set; }

    public string Name { get; set; } = null!;

    public string City { get; set; } = null!;

    public string PaymentMode { get; set; } = null!;

    public string BeneficiaryName { get; set; } = null!;

    public string Iban { get; set; } = null!;

    public string AccountNumber { get; set; } = null!;

    public string SwiftCode { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public int CreatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public int UpdatedBy { get; set; }

    public virtual Currency? Currency { get; set; }

    public virtual Document? Document { get; set; }

    public virtual Principal Principal { get; set; } = null!;
}

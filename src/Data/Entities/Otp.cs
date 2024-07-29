using System;
using System.Collections.Generic;

namespace KanzwayCron.Data.Entities;

public partial class Otp
{
    public int Id { get; set; }

    public string Code { get; set; } = null!;

    public int PrincipalId { get; set; }

    public int AttemptCount { get; set; }

    public DateTime ExpiredAt { get; set; }

    public DateTime CreatedAt { get; set; }

    public int CreatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public int UpdatedBy { get; set; }

    public virtual Principal Principal { get; set; } = null!;
}

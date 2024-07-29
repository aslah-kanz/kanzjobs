using System;
using System.Collections.Generic;

namespace KanzwayCron.Data.Entities;

public partial class RefreshToken
{
    public int Id { get; set; }

    public string Token { get; set; } = null!;

    public string AccessTokenId { get; set; } = null!;

    public int PrincipalId { get; set; }

    public DateTime ExpiredAt { get; set; }

    public DateTime CreatedAt { get; set; }

    public int CreatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public int UpdatedBy { get; set; }

    public virtual Principal Principal { get; set; } = null!;
}

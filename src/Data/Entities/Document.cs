using System;
using System.Collections.Generic;

namespace KanzwayCron.Data.Entities;

public partial class Document
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public string Url { get; set; } = null!;

    public string Type { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public int CreatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public int UpdatedBy { get; set; }

    public virtual ICollection<Catalogue> Catalogues { get; set; } = new List<Catalogue>();

    public virtual ICollection<JobApplicant> JobApplicants { get; set; } = new List<JobApplicant>();

    public virtual ICollection<PrincipalBank> PrincipalBanks { get; set; } = new List<PrincipalBank>();
}

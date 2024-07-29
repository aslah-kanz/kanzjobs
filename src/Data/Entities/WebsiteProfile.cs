using System;
using System.Collections.Generic;

namespace KanzwayCron.Data.Entities;

public partial class WebsiteProfile
{
    public int Id { get; set; }

    public string? Code { get; set; }

    public string? Name { get; set; }

    public string? MetaKeyword { get; set; }

    public string? MetaDescription { get; set; }

    public long? ImageId { get; set; }

    public long? FaviconId { get; set; }

    public string? Instagram { get; set; }

    public string? Twitter { get; set; }

    public string? Facebook { get; set; }

    public string? Linkedin { get; set; }

    public string? Youtube { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Email { get; set; }

    public string? Address { get; set; }

    public DateTime CreatedAt { get; set; }

    public int CreatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public int UpdatedBy { get; set; }

    public virtual Image? Favicon { get; set; }

    public virtual Image? Image { get; set; }
}

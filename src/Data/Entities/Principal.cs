using System;
using System.Collections.Generic;

namespace KanzwayCron.Data.Entities;

public partial class Principal
{
    public int Id { get; set; }

    public long? ImageId { get; set; }

    public string Username { get; set; } = null!;

    public string? Password { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? CountryCode { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Type { get; set; }

    public string? Gender { get; set; }

    public DateOnly? BirthDate { get; set; }

    public bool AcceptNewsLetter { get; set; }

    public string? Comment { get; set; }

    public string Status { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public int CreatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public int UpdatedBy { get; set; }

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual ICollection<CustomerOrder> CustomerOrders { get; set; } = new List<CustomerOrder>();

    public virtual ICollection<Exchange> Exchanges { get; set; } = new List<Exchange>();

    public virtual Image? Image { get; set; }

    public virtual ICollection<Inquiry> Inquiries { get; set; } = new List<Inquiry>();

    public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();

    public virtual ICollection<OneTimeToken> OneTimeTokens { get; set; } = new List<OneTimeToken>();

    public virtual ICollection<Otp> Otps { get; set; } = new List<Otp>();

    public virtual ICollection<PrincipalAddress> PrincipalAddresses { get; set; } = new List<PrincipalAddress>();

    public virtual ICollection<PrincipalBank> PrincipalBanks { get; set; } = new List<PrincipalBank>();

    public virtual ICollection<PrincipalWallet> PrincipalWallets { get; set; } = new List<PrincipalWallet>();

    public virtual ICollection<ProductReview> ProductReviews { get; set; } = new List<ProductReview>();

    public virtual RefreshToken? RefreshToken { get; set; }

    public virtual ICollection<Refund> Refunds { get; set; } = new List<Refund>();

    public virtual ICollection<Store> StoresNavigation { get; set; } = new List<Store>();

    public virtual ICollection<WishList> WishLists { get; set; } = new List<WishList>();

    public virtual ICollection<Withdraw> Withdraws { get; set; } = new List<Withdraw>();

    public virtual ICollection<Department> Departments { get; set; } = new List<Department>();

    public virtual ICollection<PrincipalDetail> PrincipalDetails { get; set; } = new List<PrincipalDetail>();

    public virtual ICollection<Role> Roles { get; set; } = new List<Role>();

    public virtual ICollection<Store> Stores { get; set; } = new List<Store>();
}

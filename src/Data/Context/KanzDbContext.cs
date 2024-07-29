using System;
using System.Collections.Generic;
using KanzwayCron.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace KanzwayCron.Data.Context;

public partial class KanzDbContext : DbContext
{
    public KanzDbContext(DbContextOptions<KanzDbContext> options, IConfiguration configuration)
        : base(options)
    {
        _configuration = configuration;
    }

    private readonly IConfiguration _configuration;

    public virtual DbSet<Entities.Attribute> Attributes { get; set; }

    public virtual DbSet<Banner> Banners { get; set; }

    public virtual DbSet<Blog> Blogs { get; set; }

    public virtual DbSet<Brand> Brands { get; set; }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<CartSaleItem> CartSaleItems { get; set; }

    public virtual DbSet<Catalogue> Catalogues { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Certificate> Certificates { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Currency> Currencies { get; set; }

    public virtual DbSet<CustomerOrder> CustomerOrders { get; set; }

    public virtual DbSet<CustomerOrderItem> CustomerOrderItems { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Document> Documents { get; set; }

    public virtual DbSet<ErrorLog> ErrorLogs { get; set; }

    public virtual DbSet<Exchange> Exchanges { get; set; }

    public virtual DbSet<Faq> Faqs { get; set; }

    public virtual DbSet<FaqGroup> FaqGroups { get; set; }

    public virtual DbSet<Image> Images { get; set; }

    public virtual DbSet<Inquiry> Inquiries { get; set; }

    public virtual DbSet<InternalRequestLog> InternalRequestLogs { get; set; }

    public virtual DbSet<InternalResponseLog> InternalResponseLogs { get; set; }

    public virtual DbSet<Job> Jobs { get; set; }

    public virtual DbSet<JobApplicant> JobApplicants { get; set; }

    public virtual DbSet<JobField> JobFields { get; set; }

    public virtual DbSet<Language> Languages { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<OneTimeToken> OneTimeTokens { get; set; }

    public virtual DbSet<Otp> Otps { get; set; }

    public virtual DbSet<PaymentMethod> PaymentMethods { get; set; }

    public virtual DbSet<Principal> Principals { get; set; }

    public virtual DbSet<PrincipalAddress> PrincipalAddresses { get; set; }

    public virtual DbSet<PrincipalBank> PrincipalBanks { get; set; }

    public virtual DbSet<PrincipalDetail> PrincipalDetails { get; set; }

    public virtual DbSet<PrincipalDetailItem> PrincipalDetailItems { get; set; }

    public virtual DbSet<PrincipalWallet> PrincipalWallets { get; set; }

    public virtual DbSet<Privilege> Privileges { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductAttribute> ProductAttributes { get; set; }

    public virtual DbSet<ProductAttributeBackupfromDev> ProductAttributeBackupfromDevs { get; set; }

    public virtual DbSet<ProductImage> ProductImages { get; set; }

    public virtual DbSet<ProductProductproperty> ProductProductproperties { get; set; }

    public virtual DbSet<ProductProductproperty1> ProductProductproperties1 { get; set; }

    public virtual DbSet<ProductReview> ProductReviews { get; set; }

    public virtual DbSet<Property> Properties { get; set; }

    public virtual DbSet<PurchaseQuote> PurchaseQuotes { get; set; }

    public virtual DbSet<RefreshToken> RefreshTokens { get; set; }

    public virtual DbSet<Refund> Refunds { get; set; }

    public virtual DbSet<RequestLog> RequestLogs { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<SaleItem> SaleItems { get; set; }

    public virtual DbSet<Shipping> Shippings { get; set; }

    public virtual DbSet<ShippingMethod> ShippingMethods { get; set; }

    public virtual DbSet<Store> Stores { get; set; }

    public virtual DbSet<StoreOrder> StoreOrders { get; set; }

    public virtual DbSet<Subscriber> Subscribers { get; set; }

    public virtual DbSet<Suggestion> Suggestions { get; set; }

    public virtual DbSet<WebPage> WebPages { get; set; }

    public virtual DbSet<WebsiteProfile> WebsiteProfiles { get; set; }

    public virtual DbSet<WishList> WishLists { get; set; }

    public virtual DbSet<Withdraw> Withdraws { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(_configuration.GetConnectionString("KanzwayConnection"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Entities.Attribute>(entity =>
        {
            entity.ToTable("Attribute", "Product");

            entity.HasIndex(e => new { e.GroupEn, e.NameEn, e.Unit1En, e.Unit2En, e.Unit3En }, "IX_Attribute_GroupEn_NameEn_Unit1En_Unit2En_Unit3En").IsUnique();

            entity.Property(e => e.Code).HasMaxLength(100);
        });

        modelBuilder.Entity<Banner>(entity =>
        {
            entity.ToTable("Banner", "Common");

            entity.HasIndex(e => e.ImageId, "IX_Banner_ImageId");

            entity.Property(e => e.Code).HasMaxLength(20);
            entity.Property(e => e.Status).HasMaxLength(10);
            entity.Property(e => e.Url).HasMaxLength(255);

            entity.HasOne(d => d.Image).WithMany(p => p.Banners).HasForeignKey(d => d.ImageId);
        });

        modelBuilder.Entity<Blog>(entity =>
        {
            entity.ToTable("Blog", "Common");

            entity.HasIndex(e => e.ImageId, "IX_Blog_ImageId");

            entity.Property(e => e.Code).HasMaxLength(20);
            entity.Property(e => e.MetaDescription).HasMaxLength(160);
            entity.Property(e => e.MetaKeyword).HasMaxLength(65);
            entity.Property(e => e.Slug).HasMaxLength(100);
            entity.Property(e => e.Status).HasMaxLength(10);

            entity.HasOne(d => d.Image).WithMany(p => p.Blogs).HasForeignKey(d => d.ImageId);
        });

        modelBuilder.Entity<Brand>(entity =>
        {
            entity.ToTable("Brand", "Product");

            entity.HasIndex(e => e.BwImageId, "IX_Brand_BwImageId");

            entity.HasIndex(e => e.ImageId, "IX_Brand_ImageId");

            entity.HasIndex(e => e.NameEn, "IX_Brand_NameEn").IsUnique();

            entity.HasIndex(e => e.Slug, "IX_Brand_Slug").IsUnique();

            entity.Property(e => e.Code).HasMaxLength(20);
            entity.Property(e => e.MetaDescription).HasMaxLength(160);
            entity.Property(e => e.MetaKeyword).HasMaxLength(65);
            entity.Property(e => e.NameEn).HasMaxLength(100);
            entity.Property(e => e.Slug).HasMaxLength(100);
            entity.Property(e => e.Status).HasMaxLength(10);

            entity.HasOne(d => d.BwImage).WithMany(p => p.BrandBwImages).HasForeignKey(d => d.BwImageId);

            entity.HasOne(d => d.Image).WithMany(p => p.BrandImages).HasForeignKey(d => d.ImageId);

            entity.HasMany(d => d.Categories).WithMany(p => p.Brands)
                .UsingEntity<Dictionary<string, object>>(
                    "BrandCategory",
                    r => r.HasOne<Category>().WithMany().HasForeignKey("CategoryId"),
                    l => l.HasOne<Brand>().WithMany().HasForeignKey("BrandId"),
                    j =>
                    {
                        j.HasKey("BrandId", "CategoryId");
                        j.ToTable("BrandCategory", "Product");
                        j.HasIndex(new[] { "CategoryId" }, "IX_BrandCategory_CategoryId");
                    });
        });

        modelBuilder.Entity<Cart>(entity =>
        {
            entity.ToTable("Cart", "Transaction");

            entity.HasIndex(e => new { e.PrincipalId, e.ProductId, e.Price }, "IX_Cart_PrincipalId_ProductId_Price").IsUnique();

            entity.HasIndex(e => e.ProductId, "IX_Cart_ProductId");

            entity.Property(e => e.Comment).HasMaxLength(255);
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Principal).WithMany(p => p.Carts).HasForeignKey(d => d.PrincipalId);

            entity.HasOne(d => d.Product).WithMany(p => p.Carts)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<CartSaleItem>(entity =>
        {
            entity.ToTable("CartSaleItem", "Transaction");

            entity.HasIndex(e => e.CartId, "IX_CartSaleItem_CartId");

            entity.HasIndex(e => e.ProductId, "IX_CartSaleItem_ProductId");

            entity.HasIndex(e => e.SaleItemId, "IX_CartSaleItem_SaleItemId");

            entity.HasIndex(e => e.StoreId, "IX_CartSaleItem_StoreId");

            entity.Property(e => e.DiscountPrice).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.MaxPrice).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.MinPrice).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Cart).WithMany(p => p.CartSaleItems).HasForeignKey(d => d.CartId);

            entity.HasOne(d => d.Product).WithMany(p => p.CartSaleItems)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.SaleItem).WithMany(p => p.CartSaleItems).HasForeignKey(d => d.SaleItemId);

            entity.HasOne(d => d.Store).WithMany(p => p.CartSaleItems)
                .HasForeignKey(d => d.StoreId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Catalogue>(entity =>
        {
            entity.ToTable("Catalogue", "Common");

            entity.HasIndex(e => e.DocumentId, "IX_Catalogue_DocumentId");

            entity.HasIndex(e => e.ImageId, "IX_Catalogue_ImageId");

            entity.Property(e => e.Code).HasMaxLength(20);
            entity.Property(e => e.MetaDescription).HasMaxLength(160);
            entity.Property(e => e.MetaKeyword).HasMaxLength(65);
            entity.Property(e => e.Slug).HasMaxLength(100);
            entity.Property(e => e.Status).HasMaxLength(10);

            entity.HasOne(d => d.Document).WithMany(p => p.Catalogues).HasForeignKey(d => d.DocumentId);

            entity.HasOne(d => d.Image).WithMany(p => p.Catalogues).HasForeignKey(d => d.ImageId);
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.ToTable("Category", "Product");

            entity.HasIndex(e => e.ImageId, "IX_Category_ImageId");

            entity.HasIndex(e => e.ParentId, "IX_Category_ParentId");

            entity.HasIndex(e => e.Slug, "IX_Category_Slug").IsUnique();

            entity.Property(e => e.Code).HasMaxLength(8);
            entity.Property(e => e.MetaDescription).HasMaxLength(160);
            entity.Property(e => e.MetaKeyword).HasMaxLength(65);
            entity.Property(e => e.Path).HasMaxLength(255);
            entity.Property(e => e.Slug).HasMaxLength(100);
            entity.Property(e => e.Status).HasMaxLength(10);

            entity.HasOne(d => d.Image).WithMany(p => p.Categories).HasForeignKey(d => d.ImageId);

            entity.HasOne(d => d.Parent).WithMany(p => p.InverseParent).HasForeignKey(d => d.ParentId);

            entity.HasMany(d => d.Products).WithMany(p => p.Categories)
                .UsingEntity<Dictionary<string, object>>(
                    "ProductCategory",
                    r => r.HasOne<Product>().WithMany().HasForeignKey("ProductId"),
                    l => l.HasOne<Category>().WithMany().HasForeignKey("CategoryId"),
                    j =>
                    {
                        j.HasKey("CategoryId", "ProductId");
                        j.ToTable("ProductCategory", "Product");
                        j.HasIndex(new[] { "ProductId" }, "IX_ProductCategory_ProductId");
                    });
        });

        modelBuilder.Entity<Certificate>(entity =>
        {
            entity.ToTable("Certificate", "Common");

            entity.HasIndex(e => e.ImageId, "IX_Certificate_ImageId");

            entity.Property(e => e.Code).HasMaxLength(20);
            entity.Property(e => e.Slug).HasMaxLength(100);
            entity.Property(e => e.Status).HasMaxLength(10);

            entity.HasOne(d => d.Image).WithMany(p => p.Certificates).HasForeignKey(d => d.ImageId);
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.ToTable("Country", "Common");

            entity.HasIndex(e => e.ImageId, "IX_Country_ImageId");

            entity.HasIndex(e => e.PhoneCode, "IX_Country_PhoneCode").IsUnique();

            entity.Property(e => e.Code).HasMaxLength(2);

            entity.HasOne(d => d.Image).WithMany(p => p.Countries).HasForeignKey(d => d.ImageId);
        });

        modelBuilder.Entity<Currency>(entity =>
        {
            entity.ToTable("Currency", "Common");

            entity.HasIndex(e => e.Code, "IX_Currency_Code").IsUnique();

            entity.Property(e => e.Code).HasMaxLength(10);
            entity.Property(e => e.Country).HasMaxLength(125);
            entity.Property(e => e.Description).HasMaxLength(125);
            entity.Property(e => e.Symbol).HasMaxLength(20);
        });

        modelBuilder.Entity<CustomerOrder>(entity =>
        {
            entity.ToTable("CustomerOrder", "Transaction");

            entity.HasIndex(e => e.AddressId, "IX_CustomerOrder_AddressId");

            entity.HasIndex(e => e.HiglightedProductId, "IX_CustomerOrder_HiglightedProductId");

            entity.HasIndex(e => e.PaymentMethodId, "IX_CustomerOrder_PaymentMethodId");

            entity.HasIndex(e => e.PrincipalDetailId, "IX_CustomerOrder_PrincipalDetailId");

            entity.HasIndex(e => e.PrincipalId, "IX_CustomerOrder_PrincipalId");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Code).HasMaxLength(100);
            entity.Property(e => e.Comment).HasMaxLength(255);
            entity.Property(e => e.DiscountPrice).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.EstimatedDeliveryCost).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.GrandTotal).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.InvoiceNumber).HasMaxLength(100);
            entity.Property(e => e.PaymentTrackId).HasMaxLength(30);
            entity.Property(e => e.PaymentTransactionId).HasMaxLength(30);
            entity.Property(e => e.PromoCode).HasMaxLength(100);
            entity.Property(e => e.Status).HasMaxLength(20);
            entity.Property(e => e.SubTotal).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Address).WithMany(p => p.CustomerOrders)
                .HasForeignKey(d => d.AddressId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.HiglightedProduct).WithMany(p => p.CustomerOrders)
                .HasForeignKey(d => d.HiglightedProductId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.PaymentMethod).WithMany(p => p.CustomerOrders).HasForeignKey(d => d.PaymentMethodId);

            entity.HasOne(d => d.PrincipalDetail).WithMany(p => p.CustomerOrders).HasForeignKey(d => d.PrincipalDetailId);

            entity.HasOne(d => d.Principal).WithMany(p => p.CustomerOrders).HasForeignKey(d => d.PrincipalId);
        });

        modelBuilder.Entity<CustomerOrderItem>(entity =>
        {
            entity.ToTable("CustomerOrderItem", "Transaction");

            entity.HasIndex(e => e.CustomerOrderId, "IX_CustomerOrderItem_CustomerOrderId");

            entity.HasIndex(e => e.ProductId, "IX_CustomerOrderItem_ProductId");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Comment).HasMaxLength(255);
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Status).HasMaxLength(20);
            entity.Property(e => e.SubTotal).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.CustomerOrder).WithMany(p => p.CustomerOrderItems).HasForeignKey(d => d.CustomerOrderId);

            entity.HasOne(d => d.Product).WithMany(p => p.CustomerOrderItems)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.ToTable("Department", "Account");

            entity.HasIndex(e => e.PrincipalDetailId, "IX_Department_PrincipalDetailId");

            entity.Property(e => e.Code).HasMaxLength(20);
            entity.Property(e => e.Name).HasMaxLength(255);

            entity.HasOne(d => d.PrincipalDetail).WithMany(p => p.Departments).HasForeignKey(d => d.PrincipalDetailId);

            entity.HasMany(d => d.Principals).WithMany(p => p.Departments)
                .UsingEntity<Dictionary<string, object>>(
                    "PrincipalDepartment",
                    r => r.HasOne<Principal>().WithMany().HasForeignKey("PrincipalId"),
                    l => l.HasOne<Department>().WithMany().HasForeignKey("DepartmentId"),
                    j =>
                    {
                        j.HasKey("DepartmentId", "PrincipalId");
                        j.ToTable("PrincipalDepartment", "Account");
                        j.HasIndex(new[] { "PrincipalId" }, "IX_PrincipalDepartment_PrincipalId");
                    });
        });

        modelBuilder.Entity<Document>(entity =>
        {
            entity.ToTable("Document", "Common");

            entity.HasIndex(e => e.Name, "IX_Document_Name").IsUnique();

            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Type).HasMaxLength(100);
            entity.Property(e => e.Url).HasMaxLength(255);
        });

        modelBuilder.Entity<ErrorLog>(entity =>
        {
            entity.ToTable("ErrorLog", "Logging");

            entity.Property(e => e.Message).HasMaxLength(255);
            entity.Property(e => e.Type).HasMaxLength(255);
        });

        modelBuilder.Entity<Exchange>(entity =>
        {
            entity.ToTable("Exchange", "Transaction");

            entity.HasIndex(e => e.PrincipalDetailId, "IX_Exchange_PrincipalDetailId");

            entity.HasIndex(e => e.PrincipalId, "IX_Exchange_PrincipalId");

            entity.HasIndex(e => e.ProductId, "IX_Exchange_ProductId");

            entity.HasIndex(e => e.PurchaseQuoteId, "IX_Exchange_PurchaseQuoteId");

            entity.HasIndex(e => e.StoreId, "IX_Exchange_StoreId");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.AdminComment).HasMaxLength(255);
            entity.Property(e => e.Comment).HasMaxLength(255);
            entity.Property(e => e.Number).HasMaxLength(100);
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Status).HasMaxLength(20);
            entity.Property(e => e.SubTotal).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.VendorComment).HasMaxLength(255);

            entity.HasOne(d => d.PrincipalDetail).WithMany(p => p.Exchanges).HasForeignKey(d => d.PrincipalDetailId);

            entity.HasOne(d => d.Principal).WithMany(p => p.Exchanges)
                .HasForeignKey(d => d.PrincipalId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Product).WithMany(p => p.Exchanges).HasForeignKey(d => d.ProductId);

            entity.HasOne(d => d.PurchaseQuote).WithMany(p => p.Exchanges)
                .HasForeignKey(d => d.PurchaseQuoteId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Store).WithMany(p => p.Exchanges).HasForeignKey(d => d.StoreId);

            entity.HasMany(d => d.Images).WithMany(p => p.Exchanges)
                .UsingEntity<Dictionary<string, object>>(
                    "ExchangeImage",
                    r => r.HasOne<Image>().WithMany().HasForeignKey("ImageId"),
                    l => l.HasOne<Exchange>().WithMany().HasForeignKey("ExchangeId"),
                    j =>
                    {
                        j.HasKey("ExchangeId", "ImageId");
                        j.ToTable("ExchangeImage", "Transaction");
                        j.HasIndex(new[] { "ImageId" }, "IX_ExchangeImage_ImageId");
                    });
        });

        modelBuilder.Entity<Faq>(entity =>
        {
            entity.ToTable("Faq", "Common");

            entity.HasIndex(e => e.FaqGroupId, "IX_Faq_FaqGroupId");

            entity.Property(e => e.Code).HasMaxLength(20);
            entity.Property(e => e.Status).HasMaxLength(10);

            entity.HasOne(d => d.FaqGroup).WithMany(p => p.Faqs).HasForeignKey(d => d.FaqGroupId);
        });

        modelBuilder.Entity<FaqGroup>(entity =>
        {
            entity.ToTable("FaqGroup", "Common");

            entity.Property(e => e.Code).HasMaxLength(20);
            entity.Property(e => e.Status).HasMaxLength(10);
        });

        modelBuilder.Entity<Image>(entity =>
        {
            entity.ToTable("Image", "Common");

            entity.HasIndex(e => e.Name, "IX_Image_Name").IsUnique();

            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Type).HasMaxLength(20);
            entity.Property(e => e.Url).HasMaxLength(255);

            entity.HasMany(d => d.ProductReviews).WithMany(p => p.Images)
                .UsingEntity<Dictionary<string, object>>(
                    "ProductReviewImage",
                    r => r.HasOne<ProductReview>().WithMany().HasForeignKey("ProductReviewId"),
                    l => l.HasOne<Image>().WithMany().HasForeignKey("ImageId"),
                    j =>
                    {
                        j.HasKey("ImageId", "ProductReviewId");
                        j.ToTable("ProductReviewImage", "Transaction");
                        j.HasIndex(new[] { "ProductReviewId" }, "IX_ProductReviewImage_ProductReviewId");
                    });

            entity.HasMany(d => d.Refunds).WithMany(p => p.Images)
                .UsingEntity<Dictionary<string, object>>(
                    "RefundImage",
                    r => r.HasOne<Refund>().WithMany().HasForeignKey("RefundId"),
                    l => l.HasOne<Image>().WithMany().HasForeignKey("ImageId"),
                    j =>
                    {
                        j.HasKey("ImageId", "RefundId");
                        j.ToTable("RefundImage", "Transaction");
                        j.HasIndex(new[] { "RefundId" }, "IX_RefundImage_RefundId");
                    });
        });

        modelBuilder.Entity<Inquiry>(entity =>
        {
            entity.ToTable("Inquiry", "Transaction");

            entity.HasIndex(e => e.PrincipalId, "IX_Inquiry_PrincipalId");

            entity.HasIndex(e => e.ProductId, "IX_Inquiry_ProductId");

            entity.Property(e => e.Comment).HasMaxLength(255);
            entity.Property(e => e.Status).HasMaxLength(20);
            entity.Property(e => e.TotalPrice).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Principal).WithMany(p => p.Inquiries).HasForeignKey(d => d.PrincipalId);

            entity.HasOne(d => d.Product).WithMany(p => p.Inquiries)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<InternalRequestLog>(entity =>
        {
            entity.ToTable("InternalRequestLog", "Logging");

            entity.Property(e => e.Method).HasMaxLength(10);
            entity.Property(e => e.Path).HasMaxLength(255);
            entity.Property(e => e.QueryString).HasMaxLength(255);
        });

        modelBuilder.Entity<InternalResponseLog>(entity =>
        {
            entity.ToTable("InternalResponseLog", "Logging");
        });

        modelBuilder.Entity<Job>(entity =>
        {
            entity.ToTable("Job", "Common");

            entity.HasIndex(e => e.JobFieldId, "IX_Job_JobFieldId");

            entity.Property(e => e.Code).HasMaxLength(20);
            entity.Property(e => e.Requirement).HasMaxLength(255);
            entity.Property(e => e.Slug).HasMaxLength(100);
            entity.Property(e => e.Status).HasMaxLength(10);

            entity.HasOne(d => d.JobField).WithMany(p => p.Jobs).HasForeignKey(d => d.JobFieldId);
        });

        modelBuilder.Entity<JobApplicant>(entity =>
        {
            entity.ToTable("JobApplicant", "Common");

            entity.HasIndex(e => e.DocumentId, "IX_JobApplicant_DocumentId");

            entity.HasIndex(e => e.JobId, "IX_JobApplicant_JobId");

            entity.Property(e => e.Code).HasMaxLength(20);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.PhoneNumber).HasMaxLength(65);
            entity.Property(e => e.Status).HasMaxLength(20);

            entity.HasOne(d => d.Document).WithMany(p => p.JobApplicants).HasForeignKey(d => d.DocumentId);

            entity.HasOne(d => d.Job).WithMany(p => p.JobApplicants).HasForeignKey(d => d.JobId);
        });

        modelBuilder.Entity<JobField>(entity =>
        {
            entity.ToTable("JobField", "Common");

            entity.Property(e => e.Code).HasMaxLength(20);
        });

        modelBuilder.Entity<Language>(entity =>
        {
            entity.ToTable("Language", "Common");

            entity.HasIndex(e => e.Code, "IX_Language_Code").IsUnique();

            entity.HasIndex(e => e.ImageId, "IX_Language_ImageId");

            entity.Property(e => e.Code).HasMaxLength(20);

            entity.HasOne(d => d.Image).WithMany(p => p.Languages).HasForeignKey(d => d.ImageId);
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.ToTable("Notification", "Account");

            entity.HasIndex(e => e.ImageId, "IX_Notification_ImageId");

            entity.HasIndex(e => e.PrincipalId, "IX_Notification_PrincipalId");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.ReadAt).HasColumnType("datetime");
            entity.Property(e => e.ReferenceId).HasMaxLength(65);
            entity.Property(e => e.Type).HasMaxLength(20);

            entity.HasOne(d => d.Image).WithMany(p => p.Notifications).HasForeignKey(d => d.ImageId);

            entity.HasOne(d => d.Principal).WithMany(p => p.Notifications)
                .HasForeignKey(d => d.PrincipalId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<OneTimeToken>(entity =>
        {
            entity.ToTable("OneTimeToken", "Security");

            entity.HasIndex(e => e.PrincipalId, "IX_OneTimeToken_PrincipalId");

            entity.HasIndex(e => e.Token, "IX_OneTimeToken_Token").IsUnique();

            entity.HasIndex(e => new { e.Type, e.PrincipalId }, "IX_OneTimeToken_Type_PrincipalId").IsUnique();

            entity.Property(e => e.Token).HasMaxLength(255);
            entity.Property(e => e.Type).HasMaxLength(20);

            entity.HasOne(d => d.Principal).WithMany(p => p.OneTimeTokens).HasForeignKey(d => d.PrincipalId);
        });

        modelBuilder.Entity<Otp>(entity =>
        {
            entity.ToTable("Otp", "Security");

            entity.HasIndex(e => e.Code, "IX_Otp_Code").IsUnique();

            entity.HasIndex(e => e.PrincipalId, "IX_Otp_PrincipalId");

            entity.Property(e => e.Code).HasMaxLength(10);

            entity.HasOne(d => d.Principal).WithMany(p => p.Otps).HasForeignKey(d => d.PrincipalId);
        });

        modelBuilder.Entity<PaymentMethod>(entity =>
        {
            entity.ToTable("PaymentMethod", "Transaction");

            entity.HasIndex(e => e.ImageArId, "IX_PaymentMethod_ImageArId");

            entity.HasIndex(e => e.ImageId, "IX_PaymentMethod_ImageId");

            entity.Property(e => e.Code).HasMaxLength(100);

            entity.HasOne(d => d.ImageAr).WithMany(p => p.PaymentMethodImageArs).HasForeignKey(d => d.ImageArId);

            entity.HasOne(d => d.Image).WithMany(p => p.PaymentMethodImages).HasForeignKey(d => d.ImageId);
        });

        modelBuilder.Entity<Principal>(entity =>
        {
            entity.ToTable("Principal", "Account");

            entity.HasIndex(e => e.ImageId, "IX_Principal_ImageId");

            entity.HasIndex(e => e.Username, "IX_Principal_Username").IsUnique();

            entity.Property(e => e.Comment).HasMaxLength(255);
            entity.Property(e => e.CountryCode).HasMaxLength(4);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.Gender).HasMaxLength(6);
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.PhoneNumber).HasMaxLength(15);
            entity.Property(e => e.Status).HasMaxLength(30);
            entity.Property(e => e.Type).HasMaxLength(20);
            entity.Property(e => e.Username).HasMaxLength(100);

            entity.HasOne(d => d.Image).WithMany(p => p.Principals).HasForeignKey(d => d.ImageId);

            entity.HasMany(d => d.Roles).WithMany(p => p.Principals)
                .UsingEntity<Dictionary<string, object>>(
                    "PrincipalRole",
                    r => r.HasOne<Role>().WithMany().HasForeignKey("RoleId"),
                    l => l.HasOne<Principal>().WithMany().HasForeignKey("PrincipalId"),
                    j =>
                    {
                        j.HasKey("PrincipalId", "RoleId");
                        j.ToTable("PrincipalRole", "Account");
                        j.HasIndex(new[] { "RoleId" }, "IX_PrincipalRole_RoleId");
                    });

            entity.HasMany(d => d.Stores).WithMany(p => p.Principals)
                .UsingEntity<Dictionary<string, object>>(
                    "PrincipalStore",
                    r => r.HasOne<Store>().WithMany().HasForeignKey("StoreId"),
                    l => l.HasOne<Principal>().WithMany().HasForeignKey("PrincipalId"),
                    j =>
                    {
                        j.HasKey("PrincipalId", "StoreId");
                        j.ToTable("PrincipalStore", "Account");
                        j.HasIndex(new[] { "StoreId" }, "IX_PrincipalStore_StoreId");
                    });
        });

        modelBuilder.Entity<PrincipalAddress>(entity =>
        {
            entity.ToTable("PrincipalAddress", "Account");

            entity.HasIndex(e => new { e.PrincipalId, e.Name }, "IX_PrincipalAddress_PrincipalId_Name").IsUnique();

            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.City).HasMaxLength(125);
            entity.Property(e => e.Code).HasMaxLength(100);
            entity.Property(e => e.Country).HasMaxLength(125);
            entity.Property(e => e.CountryCode).HasMaxLength(4);
            entity.Property(e => e.Latitude).HasColumnType("decimal(12, 8)");
            entity.Property(e => e.Longitude).HasColumnType("decimal(13, 8)");
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.PhoneNumber).HasMaxLength(15);
            entity.Property(e => e.RecipientName).HasMaxLength(255);

            entity.HasOne(d => d.Principal).WithMany(p => p.PrincipalAddresses).HasForeignKey(d => d.PrincipalId);
        });

        modelBuilder.Entity<PrincipalBank>(entity =>
        {
            entity.ToTable("PrincipalBank", "Account");

            entity.HasIndex(e => e.CurrencyId, "IX_PrincipalBank_CurrencyId");

            entity.HasIndex(e => e.DocumentId, "IX_PrincipalBank_DocumentId");

            entity.HasIndex(e => e.Iban, "IX_PrincipalBank_Iban").IsUnique();

            entity.HasIndex(e => e.PrincipalId, "IX_PrincipalBank_PrincipalId");

            entity.Property(e => e.AccountNumber).HasMaxLength(125);
            entity.Property(e => e.BeneficiaryName).HasMaxLength(125);
            entity.Property(e => e.City).HasMaxLength(125);
            entity.Property(e => e.Code).HasMaxLength(100);
            entity.Property(e => e.Iban).HasMaxLength(125);
            entity.Property(e => e.Name).HasMaxLength(125);
            entity.Property(e => e.PaymentMode).HasMaxLength(125);
            entity.Property(e => e.SwiftCode).HasMaxLength(125);

            entity.HasOne(d => d.Currency).WithMany(p => p.PrincipalBanks).HasForeignKey(d => d.CurrencyId);

            entity.HasOne(d => d.Document).WithMany(p => p.PrincipalBanks).HasForeignKey(d => d.DocumentId);

            entity.HasOne(d => d.Principal).WithMany(p => p.PrincipalBanks).HasForeignKey(d => d.PrincipalId);
        });

        modelBuilder.Entity<PrincipalDetail>(entity =>
        {
            entity.ToTable("PrincipalDetail", "Account");

            entity.HasIndex(e => e.CountryId, "IX_PrincipalDetail_CountryId");

            entity.HasIndex(e => e.PrincipalId, "IX_PrincipalDetail_PrincipalId").IsUnique();

            entity.Property(e => e.City).HasMaxLength(125);
            entity.Property(e => e.CompanyNameAr).HasMaxLength(125);
            entity.Property(e => e.CompanyNameEn).HasMaxLength(125);
            entity.Property(e => e.CompanyNumber).HasMaxLength(125);

            entity.HasOne(d => d.Country).WithMany(p => p.PrincipalDetails)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasMany(d => d.Principals).WithMany(p => p.PrincipalDetails)
                .UsingEntity<Dictionary<string, object>>(
                    "CompanyMember",
                    r => r.HasOne<Principal>().WithMany().HasForeignKey("PrincipalId"),
                    l => l.HasOne<PrincipalDetail>().WithMany().HasForeignKey("PrincipalDetailId"),
                    j =>
                    {
                        j.HasKey("PrincipalDetailId", "PrincipalId");
                        j.ToTable("CompanyMember", "Account");
                        j.HasIndex(new[] { "PrincipalId" }, "IX_CompanyMember_PrincipalId");
                    });
        });

        modelBuilder.Entity<PrincipalDetailItem>(entity =>
        {
            entity.ToTable("PrincipalDetailItem", "Account");

            entity.HasIndex(e => e.PrincipalDetailId, "IX_PrincipalDetailItem_PrincipalDetailId");

            entity.HasOne(d => d.PrincipalDetail).WithMany(p => p.PrincipalDetailItems).HasForeignKey(d => d.PrincipalDetailId);
        });

        modelBuilder.Entity<PrincipalWallet>(entity =>
        {
            entity.ToTable("PrincipalWallet", "Account");

            entity.HasIndex(e => e.PrincipalId, "IX_PrincipalWallet_PrincipalId");

            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Code).HasMaxLength(100);
            entity.Property(e => e.ReferenceId).HasMaxLength(65);
            entity.Property(e => e.Type).HasMaxLength(6);

            entity.HasOne(d => d.Principal).WithMany(p => p.PrincipalWallets).HasForeignKey(d => d.PrincipalId);
        });

        modelBuilder.Entity<Privilege>(entity =>
        {
            entity.ToTable("Privilege", "Account");

            entity.HasIndex(e => e.Name, "IX_Privilege_Name").IsUnique();

            entity.Property(e => e.Name).HasMaxLength(100);

            entity.HasMany(d => d.Roles).WithMany(p => p.Privileges)
                .UsingEntity<Dictionary<string, object>>(
                    "RolePrivilege",
                    r => r.HasOne<Role>().WithMany().HasForeignKey("RoleId"),
                    l => l.HasOne<Privilege>().WithMany().HasForeignKey("PrivilegeId"),
                    j =>
                    {
                        j.HasKey("PrivilegeId", "RoleId");
                        j.ToTable("RolePrivilege", "Account");
                        j.HasIndex(new[] { "RoleId" }, "IX_RolePrivilege_RoleId");
                    });
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Product", "Product");

            entity.HasIndex(e => e.BrandId, "IX_Product_BrandId");

            entity.HasIndex(e => e.IconId, "IX_Product_IconId");

            entity.HasIndex(e => e.ImageId, "IX_Product_ImageId");

            entity.HasIndex(e => e.PrincipalDetailId, "IX_Product_PrincipalDetailId");

            entity.HasIndex(e => e.Slug, "IX_Product_Slug").IsUnique();

            entity.Property(e => e.Code).HasMaxLength(100);
            entity.Property(e => e.Comment).HasMaxLength(255);
            entity.Property(e => e.FamilyCode).HasMaxLength(60);
            entity.Property(e => e.GroupCode).HasMaxLength(60);
            entity.Property(e => e.HighestPrice).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.LowestPrice).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.MetaDescription).HasMaxLength(160);
            entity.Property(e => e.MetaKeyword).HasMaxLength(65);
            entity.Property(e => e.Mpn).HasMaxLength(100);
            entity.Property(e => e.OriginalPrice).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Slug).HasMaxLength(100);
            entity.Property(e => e.Status).HasMaxLength(20);

            entity.HasOne(d => d.Brand).WithMany(p => p.Products)
                .HasForeignKey(d => d.BrandId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Icon).WithMany(p => p.ProductIcons).HasForeignKey(d => d.IconId);

            entity.HasOne(d => d.Image).WithMany(p => p.ProductImages).HasForeignKey(d => d.ImageId);

            entity.HasOne(d => d.PrincipalDetail).WithMany(p => p.Products).HasForeignKey(d => d.PrincipalDetailId);
        });

        modelBuilder.Entity<ProductAttribute>(entity =>
        {
            entity.ToTable("ProductAttribute", "Product");

            entity.HasIndex(e => e.AttributeId, "IX_ProductAttribute_AttributeId");

            entity.HasIndex(e => e.ImageId, "IX_ProductAttribute_ImageId");

            entity.HasIndex(e => new { e.ProductId, e.AttributeId }, "IX_ProductAttribute_ProductId_AttributeId").IsUnique();

            entity.HasIndex(e => e.PropertyId, "IX_ProductAttribute_PropertyId");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Attribute).WithMany(p => p.ProductAttributes)
                .HasForeignKey(d => d.AttributeId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Image).WithMany(p => p.ProductAttributes).HasForeignKey(d => d.ImageId);

            entity.HasOne(d => d.Product).WithMany(p => p.ProductAttributes).HasForeignKey(d => d.ProductId);

            entity.HasOne(d => d.Property).WithMany(p => p.ProductAttributes)
                .HasForeignKey(d => d.PropertyId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<ProductAttributeBackupfromDev>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ProductAttributeBackupfromDev");
        });

        modelBuilder.Entity<ProductImage>(entity =>
        {
            entity.ToTable("ProductImage", "Product");

            entity.HasIndex(e => e.ImageId, "IX_ProductImage_ImageId");

            entity.HasIndex(e => new { e.ProductId, e.ImageId }, "IX_ProductImage_ProductId_ImageId").IsUnique();

            entity.HasOne(d => d.Image).WithMany(p => p.ProductImagesNavigation).HasForeignKey(d => d.ImageId);

            entity.HasOne(d => d.Product).WithMany(p => p.ProductImages).HasForeignKey(d => d.ProductId);
        });

        modelBuilder.Entity<ProductProductproperty>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("[product].[productproperty]");

            entity.HasIndex(e => e.ProductId, "ix_[product].[productproperty]_ProductId");

            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.Fields).IsUnicode(false);
            entity.Property(e => e.Name).IsUnicode(false);
            entity.Property(e => e.NameEn).IsUnicode(false);
            entity.Property(e => e.Type).IsUnicode(false);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
        });

        modelBuilder.Entity<ProductProductproperty1>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("product.productproperty");

            entity.HasIndex(e => e.Index, "ix_product.productproperty_index");

            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.Fields).IsUnicode(false);
            entity.Property(e => e.Index).HasColumnName("index");
            entity.Property(e => e.Name).IsUnicode(false);
            entity.Property(e => e.NameEn).IsUnicode(false);
            entity.Property(e => e.Type).IsUnicode(false);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
        });

        modelBuilder.Entity<ProductReview>(entity =>
        {
            entity.ToTable("ProductReview", "Transaction");

            entity.HasIndex(e => e.PrincipalId, "IX_ProductReview_PrincipalId");

            entity.HasIndex(e => e.ProductId, "IX_ProductReview_ProductId");

            entity.HasIndex(e => e.PurchaseQuoteId, "IX_ProductReview_PurchaseQuoteId");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Code).HasMaxLength(20);
            entity.Property(e => e.Comment).HasMaxLength(255);

            entity.HasOne(d => d.Principal).WithMany(p => p.ProductReviews)
                .HasForeignKey(d => d.PrincipalId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Product).WithMany(p => p.ProductReviews).HasForeignKey(d => d.ProductId);

            entity.HasOne(d => d.PurchaseQuote).WithMany(p => p.ProductReviews)
                .HasForeignKey(d => d.PurchaseQuoteId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Property>(entity =>
        {
            entity.ToTable("Property", "Product");

            entity.HasIndex(e => e.NameEn, "IX_Property_NameEn").IsUnique();

            entity.Property(e => e.Code).HasMaxLength(100);
            entity.Property(e => e.Type).HasMaxLength(10);
        });

        modelBuilder.Entity<PurchaseQuote>(entity =>
        {
            entity.ToTable("PurchaseQuote", "Transaction");

            entity.HasIndex(e => e.CustomerOrderId, "IX_PurchaseQuote_CustomerOrderId");

            entity.HasIndex(e => e.CustomerOrderItemId, "IX_PurchaseQuote_CustomerOrderItemId");

            entity.HasIndex(e => e.ProductId, "IX_PurchaseQuote_ProductId");

            entity.HasIndex(e => e.StoreId, "IX_PurchaseQuote_StoreId");

            entity.HasIndex(e => e.StoreOrderId, "IX_PurchaseQuote_StoreOrderId");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Code).HasMaxLength(100);
            entity.Property(e => e.Comment).HasMaxLength(255);
            entity.Property(e => e.DiscountPrice).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.MaxPrice).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.MinPrice).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.PlatformCommission).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Status).HasMaxLength(20);
            entity.Property(e => e.SubTotal).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Tax).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.CustomerOrder).WithMany(p => p.PurchaseQuotes)
                .HasForeignKey(d => d.CustomerOrderId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.CustomerOrderItem).WithMany(p => p.PurchaseQuotes).HasForeignKey(d => d.CustomerOrderItemId);

            entity.HasOne(d => d.Product).WithMany(p => p.PurchaseQuotes)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Store).WithMany(p => p.PurchaseQuotes)
                .HasForeignKey(d => d.StoreId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.StoreOrder).WithMany(p => p.PurchaseQuotes)
                .HasForeignKey(d => d.StoreOrderId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<RefreshToken>(entity =>
        {
            entity.ToTable("RefreshToken", "Security");

            entity.HasIndex(e => e.PrincipalId, "IX_RefreshToken_PrincipalId").IsUnique();

            entity.HasIndex(e => e.Token, "IX_RefreshToken_Token").IsUnique();

            entity.Property(e => e.AccessTokenId).HasMaxLength(255);
            entity.Property(e => e.Token).HasMaxLength(255);

            entity.HasOne(d => d.Principal).WithOne(p => p.RefreshToken).HasForeignKey<RefreshToken>(d => d.PrincipalId);
        });

        modelBuilder.Entity<Refund>(entity =>
        {
            entity.ToTable("Refund", "Transaction");

            entity.HasIndex(e => e.PrincipalDetailId, "IX_Refund_PrincipalDetailId");

            entity.HasIndex(e => e.PrincipalId, "IX_Refund_PrincipalId");

            entity.HasIndex(e => e.ProductId, "IX_Refund_ProductId");

            entity.HasIndex(e => e.PurchaseQuoteId, "IX_Refund_PurchaseQuoteId");

            entity.HasIndex(e => e.StoreId, "IX_Refund_StoreId");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.AdminComment).HasMaxLength(255);
            entity.Property(e => e.Comment).HasMaxLength(255);
            entity.Property(e => e.Number).HasMaxLength(100);
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Status).HasMaxLength(20);
            entity.Property(e => e.SubTotal).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.VendorComment).HasMaxLength(255);

            entity.HasOne(d => d.PrincipalDetail).WithMany(p => p.Refunds).HasForeignKey(d => d.PrincipalDetailId);

            entity.HasOne(d => d.Principal).WithMany(p => p.Refunds)
                .HasForeignKey(d => d.PrincipalId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Product).WithMany(p => p.Refunds).HasForeignKey(d => d.ProductId);

            entity.HasOne(d => d.PurchaseQuote).WithMany(p => p.Refunds)
                .HasForeignKey(d => d.PurchaseQuoteId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Store).WithMany(p => p.Refunds).HasForeignKey(d => d.StoreId);
        });

        modelBuilder.Entity<RequestLog>(entity =>
        {
            entity.ToTable("RequestLog", "Logging");

            entity.Property(e => e.IpAddress).HasMaxLength(15);
            entity.Property(e => e.Method).HasMaxLength(10);
            entity.Property(e => e.Path).HasMaxLength(255);
            entity.Property(e => e.QueryString).HasMaxLength(255);
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.ToTable("Role", "Account");

            entity.HasIndex(e => e.Name, "IX_Role_Name").IsUnique();

            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<SaleItem>(entity =>
        {
            entity.ToTable("SaleItem", "Product");

            entity.HasIndex(e => new { e.ProductId, e.StoreId }, "IX_SaleItem_ProductId_StoreId").IsUnique();

            entity.HasIndex(e => e.StoreId, "IX_SaleItem_StoreId");

            entity.Property(e => e.Code).HasMaxLength(100);
            entity.Property(e => e.DiscountPrice).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.MaxPrice).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.MinPrice).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.OriginalPrice).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Status).HasMaxLength(30);

            entity.HasOne(d => d.Product).WithMany(p => p.SaleItems).HasForeignKey(d => d.ProductId);

            entity.HasOne(d => d.Store).WithMany(p => p.SaleItems)
                .HasForeignKey(d => d.StoreId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Shipping>(entity =>
        {
            entity.ToTable("Shipping", "Transaction");

            entity.HasIndex(e => e.CustomerOrderId, "IX_Shipping_CustomerOrderId");

            entity.HasIndex(e => e.ShippingMethodId, "IX_Shipping_ShippingMethodId");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Cost).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.CustomerOrder).WithMany(p => p.Shippings).HasForeignKey(d => d.CustomerOrderId);

            entity.HasOne(d => d.ShippingMethod).WithMany(p => p.Shippings)
                .HasForeignKey(d => d.ShippingMethodId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<ShippingMethod>(entity =>
        {
            entity.ToTable("ShippingMethod", "Transaction");

            entity.Property(e => e.Code).HasMaxLength(100);
            entity.Property(e => e.DeliveryCompanyName).HasMaxLength(100);
            entity.Property(e => e.DeliveryEstimateTime).HasMaxLength(100);
            entity.Property(e => e.ProviderName).HasMaxLength(100);
        });

        modelBuilder.Entity<Store>(entity =>
        {
            entity.ToTable("Store", "Account");

            entity.HasIndex(e => e.PrincipalId, "IX_Store_PrincipalId");

            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.City).HasMaxLength(100);
            entity.Property(e => e.Code).HasMaxLength(100);
            entity.Property(e => e.Country).HasMaxLength(100);
            entity.Property(e => e.Latitude).HasColumnType("decimal(12, 8)");
            entity.Property(e => e.Longitude).HasColumnType("decimal(13, 8)");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Status).HasMaxLength(30);
            entity.Property(e => e.Type).HasMaxLength(20);
            entity.Property(e => e.WarehouseId).HasMaxLength(20);

            entity.HasOne(d => d.Principal).WithMany(p => p.StoresNavigation)
                .HasForeignKey(d => d.PrincipalId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<StoreOrder>(entity =>
        {
            entity.ToTable("StoreOrder", "Transaction");

            entity.HasIndex(e => e.CustomerOrderId, "IX_StoreOrder_CustomerOrderId");

            entity.HasIndex(e => e.InvoiceNumber, "IX_StoreOrder_InvoiceNumber").IsUnique();

            entity.HasIndex(e => e.StoreId, "IX_StoreOrder_StoreId");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.DeliveryCost).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.InvoiceNumber).HasMaxLength(100);
            entity.Property(e => e.PurchaseQuoteStatus).HasMaxLength(20);

            entity.HasOne(d => d.CustomerOrder).WithMany(p => p.StoreOrders).HasForeignKey(d => d.CustomerOrderId);

            entity.HasOne(d => d.Store).WithMany(p => p.StoreOrders)
                .HasForeignKey(d => d.StoreId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Subscriber>(entity =>
        {
            entity.ToTable("Subscriber", "Common");

            entity.Property(e => e.Code).HasMaxLength(20);
            entity.Property(e => e.Email).HasMaxLength(100);
        });

        modelBuilder.Entity<Suggestion>(entity =>
        {
            entity.ToTable("Suggestion", "Common");

            entity.Property(e => e.Code).HasMaxLength(20);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Message).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.PhoneNumber).HasMaxLength(65);
            entity.Property(e => e.Status).HasMaxLength(10);
            entity.Property(e => e.Subject).HasMaxLength(255);
        });

        modelBuilder.Entity<WebPage>(entity =>
        {
            entity.ToTable("WebPage", "Common");

            entity.HasIndex(e => e.ImageId, "IX_WebPage_ImageId");

            entity.HasIndex(e => e.Slug, "IX_WebPage_Slug").IsUnique();

            entity.Property(e => e.Code).HasMaxLength(20);
            entity.Property(e => e.MetaDescription).HasMaxLength(160);
            entity.Property(e => e.MetaKeyword).HasMaxLength(65);
            entity.Property(e => e.Slug).HasMaxLength(100);
            entity.Property(e => e.Status).HasMaxLength(10);

            entity.HasOne(d => d.Image).WithMany(p => p.WebPages).HasForeignKey(d => d.ImageId);
        });

        modelBuilder.Entity<WebsiteProfile>(entity =>
        {
            entity.ToTable("WebsiteProfile", "Common");

            entity.HasIndex(e => e.FaviconId, "IX_WebsiteProfile_FaviconId");

            entity.HasIndex(e => e.ImageId, "IX_WebsiteProfile_ImageId");

            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.Code).HasMaxLength(20);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Facebook).HasMaxLength(160);
            entity.Property(e => e.Instagram).HasMaxLength(160);
            entity.Property(e => e.Linkedin).HasMaxLength(160);
            entity.Property(e => e.MetaDescription).HasMaxLength(160);
            entity.Property(e => e.MetaKeyword).HasMaxLength(65);
            entity.Property(e => e.Name).HasMaxLength(65);
            entity.Property(e => e.PhoneNumber).HasMaxLength(15);
            entity.Property(e => e.Twitter).HasMaxLength(160);
            entity.Property(e => e.Youtube).HasMaxLength(160);

            entity.HasOne(d => d.Favicon).WithMany(p => p.WebsiteProfileFavicons).HasForeignKey(d => d.FaviconId);

            entity.HasOne(d => d.Image).WithMany(p => p.WebsiteProfileImages).HasForeignKey(d => d.ImageId);
        });

        modelBuilder.Entity<WishList>(entity =>
        {
            entity.ToTable("WishList", "Transaction");

            entity.HasIndex(e => e.PrincipalId, "IX_WishList_PrincipalId");

            entity.HasIndex(e => new { e.ProductId, e.PrincipalId }, "IX_WishList_ProductId_PrincipalId").IsUnique();

            entity.HasOne(d => d.Principal).WithMany(p => p.WishLists)
                .HasForeignKey(d => d.PrincipalId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Product).WithMany(p => p.WishLists)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Withdraw>(entity =>
        {
            entity.ToTable("Withdraw", "Transaction");

            entity.HasIndex(e => e.ImageId, "IX_Withdraw_ImageId");

            entity.HasIndex(e => e.PrincipalId, "IX_Withdraw_PrincipalId");

            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Comment).HasMaxLength(255);
            entity.Property(e => e.Status).HasMaxLength(10);

            entity.HasOne(d => d.Image).WithMany(p => p.Withdraws).HasForeignKey(d => d.ImageId);

            entity.HasOne(d => d.Principal).WithMany(p => p.Withdraws).HasForeignKey(d => d.PrincipalId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

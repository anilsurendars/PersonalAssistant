using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace PersonalAssistant.Data.Context;

public partial class PersonalAssistantDatabaseContext : IdentityDbContext<ApiUser>
{
    public PersonalAssistantDatabaseContext()
    {
    }

    public PersonalAssistantDatabaseContext(DbContextOptions<PersonalAssistantDatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Contact> Contacts { get; set; }

    public virtual DbSet<ContactAudit> ContactAudits { get; set; }

    public virtual DbSet<ContactType> ContactTypes { get; set; }

    public virtual DbSet<IntervalType> IntervalTypes { get; set; }

    public virtual DbSet<Investment> Investments { get; set; }

    public virtual DbSet<InvestmentAudit> InvestmentAudits { get; set; }

    public virtual DbSet<InvestmentType> InvestmentTypes { get; set; }

    public virtual DbSet<UserAction> UserActions { get; set; }

    public virtual DbSet<Website> Websites { get; set; }

    public virtual DbSet<WebsiteAudit> WebsiteAudits { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Contact>(entity =>
        {
            entity.ToTable("Contact");

            entity.Property(e => e.ContactNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.EmailAddress)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.MemberName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PersonalContactNumber)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.ContactType).WithMany(p => p.Contacts)
                .HasForeignKey(d => d.ContactTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Contact_ContactType");
        });

        modelBuilder.Entity<ContactAudit>(entity =>
        {
            entity.ToTable("ContactAudit");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.ContactNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.EmailAddress)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.LogDateTime).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.MemberName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PersonalContactNumber)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Action).WithMany(p => p.ContactAudits)
                .HasForeignKey(d => d.ActionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ContactAudit_Action");
        });

        modelBuilder.Entity<ContactType>(entity =>
        {
            entity.ToTable("ContactType");

            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Name");
        });

        modelBuilder.Entity<IntervalType>(entity =>
        {
            entity.ToTable("IntervalType");

            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Investment>(entity =>
        {
            entity.ToTable("Investment");

            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PaymentMode)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.IntervalType).WithMany(p => p.Investments)
                .HasForeignKey(d => d.IntervalTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Investment_IntervalType");

            entity.HasOne(d => d.InvestementType).WithMany(p => p.Investments)
                .HasForeignKey(d => d.InvestementTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Investment_InvestmentType");

            entity.HasOne(d => d.Website).WithMany(p => p.Investments)
                .HasForeignKey(d => d.WebsiteId)
                .HasConstraintName("FK_Investment_Website");
        });

        modelBuilder.Entity<InvestmentAudit>(entity =>
        {
            entity.ToTable("InvestmentAudit");

            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.LogDateTime).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PaymentMode)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<InvestmentType>(entity =>
        {
            entity.ToTable("InvestmentType");

            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Name");
        });

        modelBuilder.Entity<UserAction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Action");

            entity.ToTable("UserAction");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Website>(entity =>
        {
            entity.ToTable("Website");

            entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Password)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Url)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.WebsiteName)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WebsiteAudit>(entity =>
        {
            entity.ToTable("WebsiteAudit");

            entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.LogDateTime).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Password)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Url)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.WebsiteName)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Action).WithMany(p => p.WebsiteAudits)
                .HasForeignKey(d => d.ActionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WebsiteAudit_Action");
        });

        modelBuilder.Entity<IdentityRole>().HasData(
            new IdentityRole()
            {
                Name = "User",
                NormalizedName = "USER",
                Id = "f55c973f-1c66-4439-a698-7c4cb5d5c816"
            },
            new IdentityRole()
            {
                Name = "Administrator",
                NormalizedName = "ADMINISTRATOR",
                Id = "06fdfe3b-86b9-475e-a5ba-96528429bbc2"
            });

        var hasher = new PasswordHasher<ApiUser>();

        modelBuilder.Entity<ApiUser>().HasData(
            new ApiUser()
            {
                Id = "b9d866a5-b316-448c-a07f-969dce564b10",
                Email = "admin@pa.mail.com",
                NormalizedEmail = "ADMIN@PA.MAIL.COM",
                UserName = "admin@pa.mail.com",
                NormalizedUserName = "ADMIN@PA.MAIL.COM",
                FirstName = "System",
                LastName = "Administrator",
                PasswordHash = hasher.HashPassword(null, "P@ssword1")
            },
           new ApiUser()
           {
               Id = "c908badf-9b09-43dd-b814-a016623c75d8",
               Email = "user@pa.mail.com",
               NormalizedEmail = "USER@PA.MAIL.COM",
               UserName = "user@pa.mail.com",
               NormalizedUserName = "USER@PA.MAIL.COM",
               FirstName = "System",
               LastName = "User",
               PasswordHash = hasher.HashPassword(null, "P@ssword1")
           });

        modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "f55c973f-1c66-4439-a698-7c4cb5d5c816",
                    UserId = "c908badf-9b09-43dd-b814-a016623c75d8"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "06fdfe3b-86b9-475e-a5ba-96528429bbc2",
                    UserId = "b9d866a5-b316-448c-a07f-969dce564b10"
                }
            );

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

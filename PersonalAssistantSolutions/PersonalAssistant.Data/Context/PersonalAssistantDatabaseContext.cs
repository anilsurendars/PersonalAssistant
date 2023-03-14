using Microsoft.EntityFrameworkCore;
using PersonalAssistant.Data.Entities;

namespace PersonalAssistant.Data.Context;

public partial class PersonalAssistantDatabaseContext : DbContext
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

            entity.Property(e => e.ContactType1)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ContactType");
        });

        modelBuilder.Entity<IntervalType>(entity =>
        {
            entity.ToTable("IntervalType");

            entity.Property(e => e.InteralType)
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

            entity.Property(e => e.InvestmentType1)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("InvestmentType");
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

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

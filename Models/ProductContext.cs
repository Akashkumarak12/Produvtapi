using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Produvtapi.Models
{
    public partial class ProductContext : DbContext
    {
        public ProductContext()
        {
        }

        public ProductContext(DbContextOptions<ProductContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cuss> Cusses { get; set; } = null!;
        public virtual DbSet<Green> Greens { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<Red> Reds { get; set; } = null!;
        public virtual DbSet<Supplier> Suppliers { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserId> UserIds { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=Product;User Id=sa;Password=!Morning1;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cuss>(entity =>
            {
                entity.HasKey(e => e.CusId);

                entity.ToTable("Cuss");

                entity.Property(e => e.Doj).HasColumnName("doj");
            });

            modelBuilder.Entity<Green>(entity =>
            {
                entity.HasKey(e => e.Sid);

                entity.ToTable("Green");

                entity.Property(e => e.Sid).ValueGeneratedNever();

                entity.Property(e => e.Brand)
                    .HasMaxLength(50)
                    .HasColumnName("brand");

                entity.Property(e => e.Location)
                    .HasMaxLength(50)
                    .HasColumnName("location");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Pid);

                entity.HasIndex(e => e.SupplierId, "IX_Products_SupplierId");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.SupplierId);
            });

            modelBuilder.Entity<Red>(entity =>
            {
                entity.HasKey(e => e.Pid)
                    .HasName("PK__red__DD37D91A0F7481E0");

                entity.ToTable("red");

                entity.Property(e => e.Pid).HasColumnName("pid");

                entity.Property(e => e.Pname)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("pname");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Qty).HasColumnName("qty");

                entity.Property(e => e.Sid).HasColumnName("sid");

                entity.HasOne(d => d.SidNavigation)
                    .WithMany(p => p.Reds)
                    .HasForeignKey(d => d.Sid)
                    .HasConstraintName("FK__red__sid__398D8EEE");
            });

            modelBuilder.Entity<UserId>(entity =>
            {
                entity.HasKey(e => e.UserId1)
                    .HasName("PK_User");

                entity.ToTable("UserId");

                entity.Property(e => e.UserId1)
                    .HasMaxLength(50)
                    .HasColumnName("UserID");

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.UserName).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
